// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/UI Manipulation Module" 
{

	Properties
	{
		_Tint ("Main Colour", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_Scale("Scale Texture", Float) = 1.0
		_SpeedU ("U Speed", Range(-10, 10)) = 0.5
		_SpeedV ("V Speed", Range(-10, 10)) = 0.5
		_RotationSpeed("Rotation Speed", Float) = 0.0
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

			#include "Assets/Shaders/DecalModule_TextureManipulation.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _Scale, _SpeedU, _SpeedV, _RotationSpeed;


			struct Interpolators
			{
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
			};	

			struct VertexData
			{
				float4 position : POSITION;
				float2 uv : TEXCOORD0;
			};

			Interpolators VertexProgram(VertexData v)
		 	{
		 		Interpolators i;
		 		i.position = UnityObjectToClipPos(v.position);
			 	i.uv = TRANSFORM_TEX(v.uv, _MainTex);

			 	return i;
			}

		 	float4 FragmentProgram(Interpolators i) : SV_TARGET
		 	{
		 		float4 mainTex = tex2D(_MainTex, ManipulateTexture(float2(_SpeedU, _SpeedV), i.uv, _RotationSpeed, _Scale));

		 		return mainTex;
		 	}

			ENDCG
		}
	}
}