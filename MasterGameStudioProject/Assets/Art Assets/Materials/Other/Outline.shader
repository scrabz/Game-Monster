Shader "Hidden/Outline"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Resolution("Res", Vector) = (0,0,0,0)
		_LumThreshold("Lum Threshold", Float) = 0.0
		_DepthThreshold("Depth Threshold", Float) = 0.0
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			float lum(float4 color) {
				return 0.2126*color.r + 0.7152*color.g + 0.0722*color.b;
			}

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			float _LumThreshold;
			float _DepthThreshold;
			float4 _Resolution;
			fixed4 _OutlineColor;

			sampler2D _CameraDepthTexture;

			fixed4 frag (v2f i) : SV_Target
			{
				float xOffset = 1 / _Resolution.x;
				float yOffset = 1 / _Resolution.y;
				float3x3 Lum = {
					lum(tex2D(_MainTex, i.uv + float2(-xOffset, yOffset))),  lum(tex2D(_MainTex, i.uv + float2(0, yOffset))),  lum(tex2D(_MainTex, i.uv + float2(xOffset, yOffset))),
					lum(tex2D(_MainTex, i.uv + float2(-xOffset, 0))),		 lum(tex2D(_MainTex, i.uv)),					   lum(tex2D(_MainTex, i.uv + float2(xOffset, 0))),
					lum(tex2D(_MainTex, i.uv + float2(-xOffset, -yOffset))), lum(tex2D(_MainTex, i.uv + float2(0, -yOffset))), lum(tex2D(_MainTex, i.uv + float2(xOffset, -yOffset)))
				};
				float3x3 Depth = {
					tex2D(_CameraDepthTexture, i.uv + float2(-xOffset, yOffset)).x,  tex2D(_CameraDepthTexture, i.uv + float2(0, yOffset)).x,  tex2D(_CameraDepthTexture, i.uv + float2(xOffset, yOffset)).x,
					tex2D(_CameraDepthTexture, i.uv + float2(-xOffset, 0)).x,		 tex2D(_CameraDepthTexture, i.uv).x,					   tex2D(_CameraDepthTexture, i.uv + float2(xOffset, 0)).x,
					tex2D(_CameraDepthTexture, i.uv + float2(-xOffset, -yOffset)).x, tex2D(_CameraDepthTexture, i.uv + float2(0, -yOffset)).x, tex2D(_CameraDepthTexture, i.uv + float2(xOffset, -yOffset)).x
				};
				float lumOutline = 1 - saturate((
					step(abs(Lum._11 - Lum._33), _LumThreshold / 100) + step(abs(Lum._12 - Lum._32), _LumThreshold / 100) +
					step(abs(Lum._13 - Lum._31), _LumThreshold / 100) + step(abs(Lum._21 - Lum._23), _LumThreshold / 100)
				) / 4);
				float depthOutline = 1 - saturate((
					step(abs(Depth._11 - Depth._33), _DepthThreshold / 1000) + step(abs(Depth._12 - Depth._32), _DepthThreshold / 1000) +
					step(abs(Depth._13 - Depth._31), _DepthThreshold / 1000) + step(abs(Depth._21 - Depth._23), _DepthThreshold / 1000)
				) / 4);
				float outline = saturate(lumOutline + depthOutline);
				return lerp(tex2D(_MainTex, i.uv), _OutlineColor, outline);
			}
			ENDCG
		}
	}
}
