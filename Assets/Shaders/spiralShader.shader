Shader "Custom/spiralShader" {
	Properties {
		_Color ("Main Color", Color) = (1, 1, 1, 1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_BumpTex ("normal Map", 2D) = "white" {}
		_ScrollTex ("Scrolling Glowy Map", 2D) = "white" {}
		_ScrollMask ("Glow Map Mask", 2D) = "white" {}
		_ScrollSpeed ("Scroll Speed", Range(0, 10)) = 5
		_SliceGuide ("Slice Guide", 2D) = "white" {}
		_SliceAmount ("Slice Amount", Range(0, 1)) = 0
	}
	
	SubShader {
		Tags { "RenderType"="Opaque" "GlowType"="TransferEffect" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert finalcolor:finalPass

		sampler2D _MainTex;
		sampler2D _BumpTex;
		sampler2D _ScrollTex;
		sampler2D _ScrollMask;
		fixed4 _Color;
		fixed _ScrollSpeed;
		sampler2D _SliceGuide;
      	fixed _SliceAmount;		

		struct Input {
			half2 uv_MainTex;
			half2 uv_BumpTex;
			half2 uv_ScrollTex;
			half2 uv_ScrollMask;
			half2 uv_SliceGuide;
		};
		
		void finalPass (Input IN, SurfaceOutput o, inout fixed4 color)
		{
			// time offset for animation
			half timeOffset = half(_Time.x) * _ScrollSpeed;
			// calc coords
			half2 texCoords = float2(IN.uv_ScrollTex.x, IN.uv_ScrollTex.y + timeOffset);
			
			half4 g = tex2D (_ScrollTex, texCoords) * tex2D (_ScrollMask, IN.uv_ScrollMask);
			color = max(color, g);
		}

		void surf (Input IN, inout SurfaceOutput o) 
		{

			
			half4 c = tex2D (_MainTex, IN.uv_MainTex);
			half3 norm = UnpackNormal(tex2D(_BumpTex, IN.uv_BumpTex));
			
			half extraEdge = 0.1;
			half clipVal = tex2D (_SliceGuide, IN.uv_SliceGuide).r;
			clip(clipVal - _SliceAmount + extraEdge);
			o.Emission = max((_SliceAmount - clipVal), 0) * (1/extraEdge);
			
			o.Normal = norm;
			o.Albedo = c.rgb * _Color;
			//o.Alpha = c.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
