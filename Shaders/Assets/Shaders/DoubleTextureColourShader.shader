// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/DoubleTextureColourShader" 
{

	Properties
	{
		_Tint ("Tint", Color) = (1,1,1,1)
		_AuxColour("Secondary Colour", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_AuxTex ("Secondary Texture", 2D) = "white" {}
		_SpeedU ("U Speed", Float) = 1
		_SpeedV ("V Speed", Float) = 1
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
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _AuxColour;
			sampler2D _AuxTex;
			float4 _AuxTex_ST;
			float _SpeedU;
			float _SpeedV;

			struct Interpolators
			{
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;

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

			 	i.uv = TRANSFORM_TEX(v.uv, _MainTex) + TRANSFORM_TEX(v.uv, _AuxTex);

			 	return i;
			}

		 	float4 FragmentProgram(Interpolators i) : SV_TARGET
		 	{
		 		float4 initialTex = tex2D(_MainTex, i.uv) * _Tint;
		 		float4 secondaryTex = tex2D(_AuxTex, i.uv + float2(_Time.g * _SpeedU, _Time.g * _SpeedV)) * _AuxColour;

		 		return initialTex + secondaryTex;
		 	} 	 	

			ENDCG
		}
	}
}