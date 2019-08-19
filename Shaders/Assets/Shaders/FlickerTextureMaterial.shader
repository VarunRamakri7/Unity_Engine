// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Flicker Shader" 
{

	Properties
	{
		_Tint ("Main Colour", Color) = (1,1,1,1)
		//_AuxColour("Secondary Colour", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		//_AuxTex ("Secondary Texture", 2D) = "white" {}
		_Speed ("U Speed", Range(0, 10)) = 1
		//_SpeedV ("V Speed", Float) = 1
	}

	SubShader
	{
		Pass
		{

			Tags
			{
				"RenderQueue" = "Transparent"
			}

			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM

			#pragma vertex VertexProgram
			#pragma fragment FragmentProgram

			#include "UnityCG.cginc"

			float4 _Tint;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			//float4 _AuxColour;
			float _Speed;
			//float _SpeedV;

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

			 	i.uv = TRANSFORM_TEX(v.uv, _MainTex);

			 	return i;
			}

		 	float4 FragmentProgram(Interpolators i) : SV_TARGET
		 	{
		 		float4 initialTex = tex2D(_MainTex, i.uv) * _Tint;

		 		return float4(initialTex.rgb, initialTex.a * sin(_Time.g * _Speed));
		 	} 	 	

			ENDCG
		}
	}
}