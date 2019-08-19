// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Detailed Texture" 
{

	Properties
	{
		_Tint ("Tint", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_DetailedTex ("Detailed Texture", 2D) = "gray" {}
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM

			#pragma vertex VertexProgram
			#pragma fragment FragmentProgram

			#include "UnityCG.cginc"

			float4 _Tint;
			sampler2D _MainTex, _DetailTex;
			float4 _MainTex_ST, _DetailTex_ST;

			struct Interpolators
			{
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
				float2 uvDetail: TEXCOORD1;

				//float3 localPosition : TEXCOORD0;
			};	

			struct VertexData
			{
				float4 position : POSITION;
				float2 uv : TEXCOORD0;
			};

			Interpolators VertexProgram(VertexData v)
		 	{
		 		Interpolators i;

		 		//i.localPosition = v.position.xyz;
		 		i.position = UnityObjectToClipPos(v.position);	
			 	i.uv = TRANSFORM_TEX(v.uv, _MainTex);
			 	i.uvDetail = TRANSFORM_TEX(v.uv, _DetailTex);

			 	return i;
			}

		 	float4 FragmentProgram(Interpolators i) : SV_TARGET
		 	{
		 		float4 colour = tex2D(_MainTex, i.uv) * _Tint;
		 		colour *= tex2D(_DetailTex, i.uvDetail) * unity_ColorSpaceDouble;

		 		return colour;
		 	} 	 	

			ENDCG
		}
	}
}