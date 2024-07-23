Shader "Unlit/Tenmetu"
{
    Properties
    {
        _Color("Color", Color) = (1,1,1,1)
        _Intensity("Intensity", Range(0, 5)) = 1
        _Speed("TimeSpeed", Range(0, 10)) = 1
        //�G�~�b�V�����ǉ�
        [HDR] _EmissionColor("Emission", Color) = (0, 0, 0, 0)
    }
        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        Lighting On
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            float _Intensity;
            float _Speed;
            fixed4 _Color;
            // �G�~�b�V�����p�ϐ���ǉ�
            float3 _EmissionColor;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.vertex.xy;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                //�����RGB�ɃG�~�b�V��������悹����

                _Color.rgb += _EmissionColor;

                fixed intensity = sin(_Time.y * _Speed) * 0.5 + 0.5; 
                return _Color * intensity * _Intensity;
            }
            ENDCG
        }
    }
}