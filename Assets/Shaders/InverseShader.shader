Shader "Custom/InverseShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
    }
    Category
    {

        SubShader
        {
            Tags { "Queue"="Transparent+1" }
            
            Pass
            {
                ZWrite On
                ZTest Greater
                Lighting On
                SetTexture [_MainTex] {}
            }
        }
    }

    Fallback "specular",1
}
