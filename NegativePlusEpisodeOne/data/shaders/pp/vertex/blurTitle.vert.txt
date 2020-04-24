// Include the UUSL header
#include <core/shaders/common/common.h>

// Input data struct
STRUCT(VERTEX_IN)
	INIT_ATTRIBUTE(float4,0,POSITION)	// Vertex position
	INIT_ATTRIBUTE(float4,1,TEXCOORD0)	// Vertex texcoords
	INIT_ATTRIBUTE(float4,2,COLOR0)		// Vertex color
END

// Output data struct
STRUCT(VERTEX_OUT)
	INIT_POSITION		// Output projected position
	INIT_OUT(float2,0)	// Texcoords (x and y only)
END

MAIN_BEGIN(VERTEX_OUT,VERTEX_IN)
	
	// Set output position
	OUT_POSITION = getPosition(IN_ATTRIBUTE(0));
	OUT_DATA(0).xy = IN_ATTRIBUTE(1).xy;
	
MAIN_END

// end
