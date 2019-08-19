// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/MouseMove Texture" 
{

	Properties
	{
		_Tint ("Main Colour", Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_SpeedU ("U Speed", Range(-10, 10)) = 1
		_SpeedV ("V Speed", Range(-10, 10)) = 1
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

			 	i.uv = TRANSFORM_TEX(v.uv, _MainTex);

			 	return i;
			}

		 	float4 FragmentProgram(Interpolators i) : SV_TARGET
		 	{
		 		//float4 initialTex = tex2D(_MainTex, i.uv + float2(_SpeedU,_SpeedV));

		 		return tex2D(_MainTex, GetMovedUV(_SpeedU, _SpeedV, i.uv));
		 	}

			ENDCG
		}
	}
}