// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Custom/curvedWorld"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
		_X ("X", float) = 0.001
		_Y ("Y", float) = 0.001
		_Z ("Z", float) = 0.001
		//_W ("W", float) = 0.001f
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Lambert vertex:vert addshadow

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
		uniform float _X;
		uniform float _Y;
		uniform float _Z;

        struct Input
        {
            float2 uv_MainTex;
        };

		void vert(inout appdata_full v) 
		{
			float4 w = mul(unity_ObjectToWorld, v.vertex);
				w.xyz -= _WorldSpaceCameraPos.xyz;

				w = float4(0.0f, 0.0f, w.x * w.x * _X, 0.0f);

				v.vertex += mul(unity_WorldToObject, w);
		}

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
