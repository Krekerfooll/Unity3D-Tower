Shader "Custom/NormalOffset"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_NormalOffset("Normal Offset", Range(0, 0.01)) = 0.0
		_SpecialVector("Cpecial vector", Vector) = (0, 0, 0, 0)
	}
	SubShader
	{
		Tags { "Queue" = "Transparent" "RenderType" = "Fade" }
		//Cull off
		LOD 100

			Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _NormalOffset;
			float4 _SpecialVector;

			struct appdata
			{
				float4 vertex : POSITION;
				float4 normal : NORMAL;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};


			float random(float2 uv)
			{
				return frac(sin(dot(uv, float2(12.9898, 78.233)))*43758.5453123);
			}

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(
					float4(
						v.vertex.x + random(_SpecialVector * v.vertex) * _NormalOffset * 0.6
						, v.vertex.y + random(_SpecialVector * v.vertex) * _NormalOffset * 0.6
						, v.vertex.z + random(_SpecialVector * v.vertex) * _NormalOffset * 0.6 + _SpecialVector.z * random(v.vertex) * 0.01,
						v.vertex.w + random(_SpecialVector * v.vertex) * _NormalOffset * 0.6)
					+ v.normal * _NormalOffset * 1.5
				);

				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);

				float alpha = (1 - abs(_SpecialVector.z) * 0.1);
				col.a = alpha < 0 ? 0 : alpha;

				UNITY_APPLY_FOG(i.fogCoord, col);

				return col;
			}
			ENDCG
		}
	}
}