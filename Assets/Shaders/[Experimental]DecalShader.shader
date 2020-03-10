Shader "Custom/DecalShader"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Color("Color", Color) = (1, 1, 1, 1)
		_Decal("Decal", 2D) = "white" {}
		_DecalColor("DecalColor", Color) = (1, 1, 1, 1)
	}
		SubShader
		{
			Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
			LOD 100

				Blend SrcAlpha OneMinusSrcAlpha

			Pass
			{
				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				// make fog work
				#pragma multi_compile_fog

				#include "UnityCG.cginc"

				sampler2D _MainTex;
				float4 _MainTex_ST;
				float4 _Color;

				sampler2D _Decal;
				float4 _Decal_ST;
				float4 _DecalColor;

				struct appdata
				{
					float4 vertex : POSITION;
					float4 normal : NORMAL;
					float2 uv : TEXCOORD0;
					float2 uv2 : TEXCOORD1;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float2 uv2 : TEXCOORD1;
					UNITY_FOG_COORDS(2)
					float4 vertex : SV_POSITION;
				};


				float random(float2 uv)
				{
					return frac(sin(dot(uv, float2(12.9898, 78.233)))*43758.5453123);
				}

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);

					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					o.uv2 = TRANSFORM_TEX(v.uv2, _Decal);
					UNITY_TRANSFER_FOG(o,o.vertex);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					// sample the texture
					fixed4 col = tex2D(_MainTex, i.uv) * _Color;

					col -= tex2D(_Decal, i.uv2) * _DecalColor;

					// apply fog
					UNITY_APPLY_FOG(i.fogCoord, col);

					return col;
				}
				ENDCG
			}
		}
}