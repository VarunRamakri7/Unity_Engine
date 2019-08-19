// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Rotate Texture" 
{

	Properties
	{
		_Tint ("Main Colour", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_RotationSpeed("Rotation Speed", Float) = 2.0
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
			#include "Assets/Shaders/DecalModule_TextureManipulation.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _RotationSpeed;

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
		 		//float2 pivot = float2(0.5,0.5);
		 		//float sinX = sin(_RotationSpeed);
			 	//float cosX = cos(_RotationSpeed);

			 	//float2x2 trigMatrix = float2x2(cosX, -sinX, sinX, cosX);
		 		//float4 initialTex = tex2D(_MainTex, pivot + mul(i.uv - pivot, trigMatrix));

		 		return tex2D(_MainTex, GetRotatedUV(_RotationSpeed, i.uv));
		 	}

			ENDCG
		}
	}
}