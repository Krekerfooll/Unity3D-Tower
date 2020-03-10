Shader "Custom/LocalDissolveShader"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_BumpMap("Normalmap", 2D) = "bump" {}

		[Toggle] _UseGlobalCameraPosition("Use Global Camera Position", Float) = 0

		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0

		[NoScaleOffset] _DissolveTexture("Dissolve texture", 2D) = "white" {}
		_DissolveTextureX("Dissolve texture X", Float) = 0
		_DissolveTextureY("Dissolve texture Y", Float) = 0
		_DissolveRadius("DissolveDistance", Float) = 1
		_FadeRadius("FadeDistance", Float) = 1
	}

		SubShader
		{
			Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
			LOD 100
			Cull off

			CGPROGRAM

			#pragma surface surf Standard fullforwardshadows alpha:blend

			#pragma target 3.0

			sampler2D _MainTex;
			sampler2D _BumpMap;
			//sampler2D _SecondTex;
			sampler2D _DissolveTexture;

			struct Input
			{
				float2 uv_MainTex;
				float2 uv_BumpMap;
				//float2 uv_SecondTex;
				float3 worldPos;
			};

			half _Glossiness;
			half _Metallic;
			fixed4 _Color;

			float _UseGlobalCameraPosition;
			float3 _CameraPos; //"Global Shader Variable", contains the Camera Position

			float _DissolveTextureX;
			float _DissolveTextureY;

			float _DissolveRadius;
			float _FadeRadius;

			float _GlobalStateToggle;
			float _GlobalDisolveTextureOffsetX;
			float _GlobalDisolveTextureOffsetY;

			float _GlobalMainTextureOffsetX;
			float _GlobalMainTextureOffsetY;

			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				half dissolve_value = tex2D(_DissolveTexture,
					float2(IN.worldPos.x / _DissolveTextureX + (_GlobalStateToggle == 0 ? sin(_GlobalDisolveTextureOffsetX) : _GlobalDisolveTextureOffsetX),
						IN.worldPos.y / _DissolveTextureY + _GlobalDisolveTextureOffsetY)).x;

				float dist = distance(_UseGlobalCameraPosition == 1 ? _CameraPos : _DissolveRadius, IN.worldPos);

				clip(-(dissolve_value - dist / _DissolveRadius));


				fixed4 c = tex2D(_MainTex, 
					float2(IN.uv_MainTex.x + _GlobalMainTextureOffsetX, IN.uv_MainTex.y + _GlobalMainTextureOffsetY)) * _Color;
				o.Albedo = c.rgb;
				o.Metallic = _Metallic;
				o.Smoothness = _Glossiness;
				o.Alpha = c.a - ((1 / (dist / _FadeRadius)) < 0 ? 0 : (1 / (dist / _FadeRadius)));
				o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
			}

			ENDCG
		}

			FallBack "Diffuse"
}