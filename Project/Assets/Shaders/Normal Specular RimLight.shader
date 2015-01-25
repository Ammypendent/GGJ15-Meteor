Shader "Texture Palette Specular"
{
	Properties
	{
		_MainTex("Main Texture", 2D) = "white" {}
		_Bump("Normal Map", 2D) = "bump" {}
		_Spec("Specular Map", 2D) = "white" {}
		_Shininess("Specular Power", float) = 5
		_RimColor("Rim Color", Color) = (1, 1, 1, 1)
		_RimPower("Rim Power", Range(0.5, 8.0)) = 3.0
	}
	SubShader
	{
		Pass
		{
			Tags { "LightMode" = "ForwardBase" }
			
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0

			#include "UnityCG.cginc"
			
			uniform float4 _LightColor0;

			// User-specified uniforms
			uniform sampler2D _MainTex;
			uniform sampler2D _Bump;
			uniform sampler2D _Spec;
			fixed4 _MainTex_ST;
			fixed4 _Bump_ST;
			fixed4 _Spec_ST;
			fixed4 _RimColor;
			float _Shininess;
			float _RimPower;

			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord: TEXCOORD0;
				float4 tangent: TANGENT;
			};
			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 posWorld: TEXCOORD0;
				float2 tex : TEXCOORD1;
				float3 normalWorld : TEXCOORD2;
				float3 tangentWorld : TEXCOORD3;
				float3 binormalWorld : TEXCOORD4;
			};

			vertexOutput vert(vertexInput input)
			{
				vertexOutput output;

				float2 outCoord = input.texcoord.xy;

				float4x4 modelMatrix = _Object2World;
				float4x4 modelMatrixInverse = _World2Object;
				output.posWorld = mul(modelMatrix, input.vertex);
				
				output.pos = mul(UNITY_MATRIX_MVP, input.vertex);

				output.tangentWorld = normalize(mul(_Object2World, input.tangent).xyz);
				output.normalWorld = normalize(mul(float4(input.normal, 0.0), _World2Object).xyz);
				output.binormalWorld = normalize(cross(output.normalWorld, output.tangentWorld) * input.tangent.w);

				output.tex = outCoord;
					
				return output;
			}

			float4 frag(vertexOutput input) : COLOR
			{
				float3 viewDirection = normalize(_WorldSpaceCameraPos - input.posWorld.xyz);
				float3 lightDirection;
				float attenuation;
				
				float4 encodedNormal = tex2D(_Bump, _Bump_ST.xy * input.tex.xy + _Bump_ST.zw);
				float3 localCoords = float3(2.0 * encodedNormal.ag - float2(1.0, 1.0), 0.0);
				localCoords.z = sqrt(1.0 - dot(localCoords, localCoords));
				
				float3x3 local2WorldTranspose = float3x3(input.tangentWorld, input.binormalWorld, input.normalWorld);
				float3 normalDirection = normalize(mul(localCoords, local2WorldTranspose));
				
				if (0.0 == _WorldSpaceLightPos0.w) // directional light?
				{
					attenuation = 1.0; // no attenuation
					lightDirection = normalize(_WorldSpaceLightPos0.xyz);
				} 
				else // point or spot light
				{
					float4 vertexToLightSource = _WorldSpaceLightPos0 - input.posWorld;
					float distance = length(vertexToLightSource);
					attenuation = 1.0 / distance; // linear attenuation 
					lightDirection = normalize(vertexToLightSource.xyz);
				}
				
				float3 ambientLighting = UNITY_LIGHTMODEL_AMBIENT.rgb;
				
				float3 diffuseReflection = attenuation * _LightColor0.rgb * max(0.0, dot(normalDirection, lightDirection));
				
				float3 specularReflection;
				
				fixed4 specTex = tex2D(_Spec, _Spec_ST.xy * input.tex.xy + _Spec_ST.zw);
				if(dot(normalDirection, lightDirection) < 0.0) // light source on the wrong side?
				{
					specularReflection = float3(0.0, 0.0, 0.0); // no specular reflection
				}
				else // light source on the right side
				{
					specularReflection = attenuation * specTex.rgb * _LightColor0.rgb * pow(max(0.0, dot(reflect(-lightDirection, normalDirection), viewDirection)), _Shininess);
				}
				
				float rim = 1.0 - saturate(dot(normalize(viewDirection), normalDirection));
				rim = pow(rim, _RimPower);
				float4 rimColor = float4(_RimColor.rgb * rim, 1.0);

				float4 tex = tex2D(_MainTex, _MainTex_ST.xy * input.tex.xy + _MainTex_ST.zw);
				return float4(ambientLighting + (tex.rgb * diffuseReflection) + specularReflection + rimColor, 1.0);
			}

			ENDCG
		}
		
		Pass
		{
			Tags { "LightMode" = "ForwardAdd" }
			Blend One One
			
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0

			#include "UnityCG.cginc"
			
			uniform float4 _LightColor0;

			// User-specified uniforms
			uniform sampler2D _MainTex;
			uniform sampler2D _Bump;
			uniform sampler2D _Spec;
			fixed4 _MainTex_ST;
			fixed4 _Bump_ST;
			fixed4 _Spec_ST;
			fixed4 _RimColor;
			float _Shininess;
			float _RimPower;

			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord: TEXCOORD0;
				float4 tangent: TANGENT;
			};
			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 posWorld: TEXCOORD0;
				float2 tex : TEXCOORD1;
				float3 normalWorld : TEXCOORD2;
				float3 tangentWorld : TEXCOORD3;
				float3 binormalWorld : TEXCOORD4;
			};

			vertexOutput vert(vertexInput input)
			{
				vertexOutput output;

				float2 outCoord = input.texcoord.xy;

				float4x4 modelMatrix = _Object2World;
				float4x4 modelMatrixInverse = _World2Object;
				output.posWorld = mul(modelMatrix, input.vertex);
				
				output.pos = mul(UNITY_MATRIX_MVP, input.vertex);

				output.tangentWorld = normalize(mul(_Object2World, input.tangent).xyz);
				output.normalWorld = normalize(mul(float4(input.normal, 0.0), _World2Object).xyz);
				output.binormalWorld = normalize(cross(output.normalWorld, output.tangentWorld) * input.tangent.w);

				output.tex = outCoord;
					
				return output;
			}

			float4 frag(vertexOutput input) : COLOR
			{
				
				float3 viewDirection = normalize(_WorldSpaceCameraPos - input.posWorld.xyz);
				float3 lightDirection;
				float attenuation;
				
				float4 encodedNormal = tex2D(_Bump, _Bump_ST.xy * input.tex.xy + _Bump_ST.zw);
				float3 localCoords = float3(2.0 * encodedNormal.ag - float2(1.0, 1.0), 0.0);
				localCoords.z = sqrt(1.0 - dot(localCoords, localCoords));
				
				float3x3 local2WorldTranspose = float3x3(input.tangentWorld, input.binormalWorld, input.normalWorld);
				float3 normalDirection = normalize(mul(localCoords, local2WorldTranspose));
				
				if (0.0 == _WorldSpaceLightPos0.w) // directional light?
				{
					attenuation = 1.0; // no attenuation
					lightDirection = normalize(_WorldSpaceLightPos0.xyz);
				} 
				else // point or spot light
				{
					float4 vertexToLightSource = _WorldSpaceLightPos0 - input.posWorld;
					float distance = length(vertexToLightSource);
					attenuation = 1.0 / distance; // linear attenuation 
					lightDirection = normalize(vertexToLightSource.xyz);
				}
				
				float3 diffuseReflection = attenuation * _LightColor0.rgb * max(0.0, dot(normalDirection, lightDirection));
				
				float3 specularReflection;
				
				fixed4 specTex = tex2D(_Spec, _Spec_ST.xy * input.tex.xy + _Spec_ST.zw);
				if(dot(normalDirection, lightDirection) < 0.0) // light source on the wrong side?
				{
					specularReflection = float3(0.0, 0.0, 0.0); // no specular reflection
				}
				else // light source on the right side
				{
					specularReflection = attenuation * specTex.rgb * _LightColor0.rgb * pow(max(0.0, dot(reflect(-lightDirection, normalDirection), viewDirection)), _Shininess);
				}
				
				float rim = 1.0 - saturate(dot(normalize(viewDirection), normalDirection));
				rim = pow(rim, _RimPower);
				float4 rimColor = float4(_RimColor.rgb * rim, 1.0);

				float4 tex = tex2D(_MainTex, _MainTex_ST.xy * input.tex.xy + _MainTex_ST.zw);
				
				return float4((tex.rgb * diffuseReflection) + specularReflection + rimColor, 1.0);
			}

			ENDCG
		}
	}
}