Shader "Custom/GlobalDissolveSurface" 
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_BumpMap("Normalmap", 2D) = "bump" {}

		[Toggle] _UseGlobalCameraPosition("Use Global Camera Position", Float) = 0

		_Glossiness("Smoothness", Range(0,1)) = 0.5
		_Metallic("Metallic", Range(0,1)) = 0.0

		_DissolveTexture("Dissolve texture", 2D) = "white" {}
		_DissolveTiling("Dissolve tiling", Float) = 1
		_Tolerance("Tolerance", Float) = 0
		_DissolveTextureX("Dissolve texture X", Float) = 0
		_DissolveTextureY("Dissolve texture Y", Float) = 0
		_Radius("Distance", Float) = 1 //distance where we start to reveal the objects
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 100
		Cull off

		CGPROGRAM

		#pragma surface surf Standard fullforwardshadows 

		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _BumpMap;
		//sampler2D _SecondTex;
		sampler2D _DissolveTexture; //texture where we get the dissolve value

		struct Input
		{
			float2 uv_MainTex;
			float2 uv_BumpMap;
			//float2 uv_SecondTex;
			float3 worldPos; //Built-in world position
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		float _UseGlobalCameraPosition;
		float3 _CameraPos; //"Global Shader Variable", contains the CameraPosition
		float _DissolveTiling;
		float _Tolerance;
		float _DissolveTextureX;
		float _DissolveTextureY;
		float _Radius;
		float _OffsetX;
		float _OffsetY;

		void surf(Input IN, inout SurfaceOutputStandard o) 
		{
			half dissolve_value = tex2D(_DissolveTexture, 
				float2(IN.worldPos.x - _DissolveTextureX + _OffsetX, IN.worldPos.y - _DissolveTextureY + _OffsetY) / _DissolveTiling) - _Tolerance;

			float dist = distance(_UseGlobalCameraPosition == 1 ? _CameraPos : 1, IN.worldPos);

			clip(-(dissolve_value - dist / _Radius));

			//half4 tex = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			//half4 second = tex2D(_SecondTex, IN.uv_SecondTex);

			//half4 c = lerp(tex, second, second.a);

			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
		}

		ENDCG
	}

	FallBack "Diffuse"
}