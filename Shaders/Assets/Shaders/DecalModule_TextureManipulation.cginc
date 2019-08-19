#include "UnityCG.cginc"

float2 GetRotatedUV(float rot, float2 UV)
{
	float2 pivot = float2(0.5, 0.5);
	float sinX = sin(rot);
	float cosX = cos(rot);

	float2x2 trigMatrix = float2x2(cosX, -sinX, sinX, cosX);
	float2 rotatedUV = mul(UV - pivot, trigMatrix);

	return rotatedUV;
}

float2 GetScaledUV(float scale, float2 UV)
{
	float2 pivot = float2(0.5, 0.5);

	float2 scaledUV = (UV - pivot) * scale + pivot;

	return scaledUV;
}

float2 GetMovedUV(float speedX, float speedY, float2 UV)
{
	float2 movedUV =  UV + float2(speedX, speedY);

	return movedUV;
}

//Overloaded with pivot

float2 GetRotatedUV(float2 pivot, float rot, float2 UV)
{
	float sinX = sin(rot);
	float cosX = cos(rot);

	float2x2 trigMatrix = float2x2(cosX, -sinX, sinX, cosX);
	float2 rotatedUV = mul(UV - pivot, trigMatrix);

	return rotatedUV;
}

float2 GetScaledUV(float2 pivot, float scale, float2 UV)
{
	float2 scaledUV = (UV - pivot) * scale + pivot;

	return scaledUV;
}

// All in one
float2 ManipulateTexture(float2 uvSpeeds, float2 UV, float rot, float scale)
{
	float2 rotatedUV;
	float2 scaledUV;
	float2 movedUV;
	float2 pivot = float2(0.5, 0.5);

//Rotation
	float sinX = sin(rot);
	float cosX = cos(rot);

	float2x2 trigMatrix = float2x2(cosX, -sinX, sinX, cosX);
	rotatedUV = mul(UV - pivot, trigMatrix);

//Scaling
	pivot = float2(0.5, 0.5);
	scaledUV = (rotatedUV - pivot) * scale + pivot;

//Moving
	movedUV =  scaledUV + uvSpeeds;

	return movedUV;
}