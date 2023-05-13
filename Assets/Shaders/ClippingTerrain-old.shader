Shader "ClippingTerrain"{
	//show values to edit in inspector
	Properties{	
		[HideInInspector] _Control ("Control (RGBA)", 2D) = "red" {}
        [HideInInspector] _Splat3 ("Layer 3 (A)", 2D) = "white" {}
        [HideInInspector] _Splat2 ("Layer 2 (B)", 2D) = "white" {}
        [HideInInspector] _Splat1 ("Layer 1 (G)", 2D) = "white" {}
        [HideInInspector] _Splat0 ("Layer 0 (R)", 2D) = "white" {}
        [HideInInspector] _Normal3 ("Normal 3 (A)", 2D) = "bump" {}
        [HideInInspector] _Normal2 ("Normal 2 (B)", 2D) = "bump" {}
        [HideInInspector] _Normal1 ("Normal 1 (G)", 2D) = "bump" {}
        [HideInInspector] _Normal0 ("Normal 0 (R)", 2D) = "bump" {}

		_MainTex ("Texture", 2D) = "white" {}
		_Smoothness ("Smoothness", Range(0, 1)) = 0
		_Emission ("Emission", color) = (0, 0, 0)
		_TurnOnClip ("Clipping", Range(0, 1)) = 1
		_Radius ("Radius", float) = 10
		_CentralSpot ("Centre", Vector) = (0, 0, 0)
		_CutoffColor("Cutoff Color", Color) = (0.24, 0.24, 0.24, 1)
	}

	SubShader{
		//the material is completely non-transparent and is rendered at the same time as the other opaque geometry
		Tags{"ForceNoShadowCasting"="True" "RenderType"="Opaque" "Queue"="Geometry"}
		// render faces regardless if they point towards the camera or away from it
		Cull Off			

		CGPROGRAM
		//the shader is a surface shader, meaning that it will be extended by unity in the background 
		//to have fancy lighting and other features
		//our surface shader function is called surf and we use our custom lighting model
		//fullforwardshadows makes sure unity adds the shadow passes the shader might need
		//vertex:vert makes the shader use vert as a vertex shader function
		#pragma surface surf Standard fullforwardshadows
		#pragma target 3.0

		sampler2D _MainTex;

		half _Smoothness;		
		half3 _Emission;
		
		float _Radius;
		float3 _CentralSpot;
		int _TurnOnClip;

		float4 _CutoffColor;

		//input struct which is automatically filled by unity
		struct Input {
			float2 uv_MainTex;
			float3 worldPos;
			float facing : VFACE;
		};

		//the surface shader function which sets parameters the lighting function then uses
		void surf (Input i, inout SurfaceOutputStandard o) {
			//calculate signed distance to plane
			float distance = _Radius * _Radius
							 -pow(_CentralSpot.x-i.worldPos.x, 2)			 
				 			 -pow(_CentralSpot.z-i.worldPos.z, 2);
			
			//discard surface above plane
			if(_TurnOnClip)
			{
				clip(distance);
			}

			float facing = i.facing * 0.5 + 0.5;
			
			//normal color stuff
			fixed4 col = tex2D(_MainTex, i.uv_MainTex);			
			o.Albedo = col.rgb * facing;			
			o.Smoothness = _Smoothness * facing;
			o.Emission = lerp(_CutoffColor, _Emission, facing);
		}
		ENDCG
	}
	Fallback "Diffuse" //fallback adds a shadow pass so we get shadows on other objects //[HDR]
}
