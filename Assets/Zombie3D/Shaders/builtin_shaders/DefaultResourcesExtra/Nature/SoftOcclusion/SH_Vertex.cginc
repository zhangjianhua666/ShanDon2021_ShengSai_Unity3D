// Upgrade NOTE: commented out 'float4x4 _CameraToWorld', a built-in variable
// Upgrade NOTE: replaced '_CameraToWorld' with 'unity_CameraToWorld'
// Upgrade NOTE: replaced 'glstate.light[i].attenuation' with 'unity_LightAtten[i]'
// Upgrade NOTE: replaced 'glstate.light[i].diffuse' with 'unity_LightColor[i]'
// Upgrade NOTE: replaced 'glstate.light[i].position' with 'unity_LightPosition[i]'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

#include "HLSLSupport.cginc"
#include "UnityCG.cginc"
#include "TerrainEngine.cginc"

float _Occlusion, _AO, _BaseLight;
float4 _Color;
float3 _TerrainTreeLightDirections[4];
float4 _TerrainTreeLightColors[4];

struct v2f {
	float4 pos : POSITION;
	float fog : FOGC;
	float4 uv : TEXCOORD0;
	float4 color : COLOR0;
};

// float4x4 _CameraToWorld;
float _HalfOverCutoff;

v2f leaves(appdata_tree v)
{
	v2f o;
	
	TerrainAnimateTree(v.vertex, v.color.w);
	
	float3 viewpos = mul(UNITY_MATRIX_MV, v.vertex);
	o.pos = UnityObjectToClipPos(v.vertex);
	o.fog = o.pos.z;
	o.uv = v.texcoord;
	
	float4 lightDir = 0;
	float4 lightColor = 0;
	lightDir.w = _AO;

	float4 light = UNITY_LIGHTMODEL_AMBIENT;

	for (int i = 0; i < 4; i++) {
		float atten = 1.0;
		#ifdef USE_CUSTOM_LIGHT_DIR
			lightDir.xyz = _TerrainTreeLightDirections[i];
			lightColor = _TerrainTreeLightColors[i];
		#else
			#if UNITY_HAS_LIGHT_PARAMETERS
				float3 toLight = unity_LightPosition[i].xyz - viewpos.xyz * unity_LightPosition[i].w;
				toLight.yz *= -1.0;
				lightDir.xyz = mul( (float3x3)unity_CameraToWorld, normalize(toLight) );
				float lengthSq = dot(toLight, toLight);
				atten = 1.0 / (1.0 + lengthSq * unity_LightAtten[i].z);
				
				lightColor = unity_LightColor[i];
			#endif
		#endif

		lightDir.xyz *= _Occlusion;
		float occ =  dot (v.tangent, lightDir);
		occ = max(0, occ);
		occ += _BaseLight;
		light += lightColor * (occ * atten);
	}

	o.color = light * _Color;
	o.color.a = 0.5 * _HalfOverCutoff;
	
	return o; 
}

v2f bark(appdata_tree v)
{
	v2f o;
	
	TerrainAnimateTree(v.vertex, v.color.w);
	
	float3 viewpos = mul(UNITY_MATRIX_MV, v.vertex);
	o.pos = UnityObjectToClipPos(v.vertex);
	o.fog = o.pos.z;
	o.uv = v.texcoord;
	
	float4 lightDir = 0;
	float4 lightColor = 0;
	lightDir.w = _AO;

	float4 light = UNITY_LIGHTMODEL_AMBIENT;

	for (int i = 0; i < 4; i++) {
		float atten = 1.0;
		#ifdef USE_CUSTOM_LIGHT_DIR
			lightDir.xyz = _TerrainTreeLightDirections[i];
			lightColor = _TerrainTreeLightColors[i];
		#else
			#if UNITY_HAS_LIGHT_PARAMETERS
				float3 toLight = unity_LightPosition[i].xyz - viewpos.xyz * unity_LightPosition[i].w;
				toLight.yz *= -1.0;
				lightDir.xyz = mul( (float3x3)unity_CameraToWorld, normalize(toLight) );
				float lengthSq = dot(toLight, toLight);
				atten = 1.0 / (1.0 + lengthSq * unity_LightAtten[i].z);
				
				lightColor = unity_LightColor[i];
			#endif
		#endif
		

		float diffuse = dot (v.normal, lightDir.xyz);
		diffuse = max(0, diffuse);
		diffuse *= _AO * v.tangent.w + _BaseLight;
		light += lightColor * (diffuse * atten);
	}

	light.a = 1;
	o.color = light * _Color;
	
	#ifdef WRITE_ALPHA_1
	o.color.a = 1;
	#endif
	
	return o; 
}
