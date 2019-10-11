Shader "Unlit/Highlight"
{
    Properties
    {
        _HighlightColor ("Highlight Color", Color) = (1,1,0,1)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" "Replacement"="Highlight"}
        LOD 100
		
		Blend One One
		ZWrite Off
		ZTest Always

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
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                return o;
            }
			
			fixed4 _HighlightColor;

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = _HighlightColor;
				col.rgb *= col.a;
                return col;
            }
            ENDCG
        }
    }
}
