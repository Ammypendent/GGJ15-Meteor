Shader "Custom/Background Screen Projection"
{
	Properties
	{
		_Color ("Color", Color) = (1, 1, 1, 1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		Pass
		{
			CGPROGRAM
			#pragma vertex vert  
			#pragma fragment frag 
	 
			#include "UnityCG.cginc"

			sampler2D _MainTex;
			fixed4 _MainTex_ST;
			fixed4 _Color;

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
	            float3 normalDir : TEXCOORD0;
	            float3 viewDir : TEXCOORD1;
				float4 tex : TEXCOORD2;
			};

			vertexOutput vert(vertexInput input) 
			{
				vertexOutput output;
				
				float2 outCoord = input.texcoord.xy;
				
				float4x4 modelMatrix = _Object2World;
				float4x4 modelMatrixInverse = _World2Object;
				
				output.viewDir = mul(modelMatrix, input.vertex).xyz - _WorldSpaceCameraPos;
				output.normalDir = normalize(mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
				output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
				
				output.tex = mul(UNITY_MATRIX_MVP, input.vertex);
					
				return output;
			}
	 
			float4 frag(vertexOutput input) : COLOR
			{
				float4 clipSpace = input.tex;
				clipSpace.xy /= clipSpace.w;
				clipSpace.x *= _ScreenParams.x / _ScreenParams.y;
				clipSpace.xy = clipSpace.xy * 0.5 + 0.5;
				
				fixed4 tex = tex2D(_MainTex, _MainTex_ST.xy * clipSpace.xy + _MainTex_ST.zw) * _Color;
				
				return tex;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
