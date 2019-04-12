Shader "Custom/FogShader" 
{
	Properties 
	{		
		_MainTex("Albedo (RGB)", 2D) = "white" {}
		_offsetX("OffsetX",Float) = 0.0
		_offsetY("OffsetY",Float) = 0.0
		_octaves("Octaves",Int) = 7
		_lacunarity("Lacunarity", Range(1.0 , 5.0)) = 2
		_gain("Gain", Range(0.0 , 1.0)) = 0.5
		_value("Value", Range(-2.0 , 2.0)) = 0.0
		_amplitude("Amplitude", Range(0.0 , 5.0)) = 1.5
		_frequency("Frequency", Range(0.0 , 6.0)) = 2.0
		_power("Power", Range(0.1 , 5.0)) = 1.0
		_scale("Scale", Float) = 1.0
		_color("Color", Color) = (1.0,1.0,1.0,1.0)
		[Toggle] _monochromatic("Monochromatic", Float) = 0
		_range("Monochromatic Range", Range(-1.0 , 1.0)) = 0.0
		//_time("time",Range(-10.0f, 10.0f)) = 0.0
	}
	SubShader 
	{
		Tags { "Queue" = "Transparent" "RenderType"="Diffuse" }
		LOD 200

		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		//sampler2D _MainTex;

		struct Input 
		{
			float2 uv_MainTex;
		};



		float _octaves, _lacunarity, _gain, _value, _amplitude, _frequency, _offsetX, _offsetY, _power, _scale, _monochromatic, _range;
		float4 _color;
		
		
		float pos_x[1000];
		float pos_z[1000];

		int pos_count = 0;

		float time;

		float sight_range = 4.0f;

		float fbm(float2 node, float offset, int dir)
		{
			float2 p = node;
			
			p = p * _scale;
						
			p += (float2(offset, offset) * dir);
			
			float oct = _octaves;
			float lac = _lacunarity;
			float gain = _gain;
			float val = _value;
			float amp = _amplitude;
			float freq = _frequency;
			float power = _power;
			
			
			for (int i = 0; i < oct; i++)
			{
				float2 i = floor(p * freq);
				float2 f = frac(p * freq);
				float2 t = f * f * f * (f * (f * 6.0 - 15.0) + 10.0);
				float2 a = i + float2(0.0, 0.0);
				float2 b = i + float2(1.0, 0.0);
				float2 c = i + float2(0.0, 1.0);
				float2 d = i + float2(1.0, 1.0);
				a = -1.0 + 2.0 * frac(sin(float2(dot(a, float2(127.1, 311.7)), dot(a, float2(269.5, 183.3)))) * 43758.5453123);
				b = -1.0 + 2.0 * frac(sin(float2(dot(b, float2(127.1, 311.7)), dot(b, float2(269.5, 183.3)))) * 43758.5453123);
				c = -1.0 + 2.0 * frac(sin(float2(dot(c, float2(127.1, 311.7)), dot(c, float2(269.5, 183.3)))) * 43758.5453123);
				d = -1.0 + 2.0 * frac(sin(float2(dot(d, float2(127.1, 311.7)), dot(d, float2(269.5, 183.3)))) * 43758.5453123);
				float A = dot(a, f - float2(0.0, 0.0));
				float B = dot(b, f - float2(1.0, 0.0));
				float C = dot(c, f - float2(0.0, 1.0));
				float D = dot(d, f - float2(1.0, 1.0));
				float noise = (lerp(lerp(A, B, t.x), lerp(C, D, t.x), t.y));
				val += amp * noise;
				freq *= lac;
				amp *= gain;
			}
			val = clamp(val, -1.0, 1.0);
			return pow(val * 0.5 + 0.5, power);
		}

		float GetDistance(float x1, float y1, float x2, float y2)
		{
			float x = x2 - x1;
			float y = y2 - y1;
			
			return sqrt((x*x) + (y*y));
		}

		float GetMinDistance(float2 uv)
		{
			
			float min_dist = 100000.0f;

			for (int i = 0; i < pos_count; i++)
			{
				float current_dist = GetDistance(uv.x, uv.y, pos_x[i], pos_z[i]);
				
				if (current_dist < min_dist)
				{
					min_dist = current_dist;
				}

				//min_dist = 0.5f;
			}

			return min_dist;
		}

		float GetHighest(float a, float b)
		{
			if (a > b)
			{
				return a;
			}

			return b;
		}

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			float c1 = fbm(IN.uv_MainTex, time, 1);

			float c2 = fbm(IN.uv_MainTex, time, -1);

			float c = (c1 + c2) / 2.0f;

			c = GetHighest(c1, c2);
			
			float a = GetMinDistance(IN.uv_MainTex);//  GetDistance(IN.uv_MainTex.x, IN.uv_MainTex.y, pos_x[0], pos_z[0]);

			a = a * a * sight_range;

			if (a > 1.0f)
			{
				a = 1.0f;
			}

			//_color = float4(pos[0].x, pos[0].x, pos[0].x, 1.0f);

			o.Albedo = float3(c, c, c);
			o.Alpha = a;// c - 0.5f;
		}
		ENDCG
	}
	FallBack "Diffuse" 
}
