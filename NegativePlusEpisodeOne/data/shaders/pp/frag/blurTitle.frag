#include <core/shaders/common/fragment.h>

// Define the texture of the scene
INIT_TEXTURE(0,TEX_SCENE)

// Input values
STRUCT(FRAGMENT_IN)
	INIT_POSITION		// Projected position
	INIT_IN(float2,0)	// Texcoords
END

// Define the grayscale_power parameter
CBUFFER(parameters)
	UNIFORM float grayscale_power;
END

MAIN_BEGIN(FRAGMENT_OUT,FRAGMENT_IN)
	
	// Get the UV
	float2 uv = IN_DATA(0);
	
	// Get the scene color
	float4 scene_color = TEXTURE_BIAS_ZERO(TEX_SCENE,uv);
	
	// Calculate the grayscale
	float3 gray_scene_color = FLOAT3(dot(float3(0.3f, 0.59f, 0.11f), scene_color.rgb));
	scene_color.rgb = lerp(scene_color.rgb,gray_scene_color,FLOAT3(grayscale_power));
	
	OUT_COLOR = scene_color;
	
MAIN_END

// end