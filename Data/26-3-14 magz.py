"""
This script should be generated using the TemporalPlotter. 
It will plot a 3D dataset as a scatter plot in Blender as a series of spheres.
Load into blender by changing workspace (top center) to scripting, then loading text block (bottom leftish), then Running code.
"""



import bpy


def BlenderPlotter(xlist, ylist, zlist):
	for i in range(0, len(xlist)):
		AddSphere(xlist[i], ylist[i], zlist[i])

def AddSphere(x, y, z):
    bpy.ops.mesh.primitive_uv_sphere_add(segments=32, ring_count=16, size=5, location=(x,y,z), rotation=(0,0,0))
    
#BlenderPlotter([1,2],[5,6],[9,0])


def ForScriptGen():
    xlist = [195, 223, 269, 295, 358, 345, 322, 290, 263, 186, 105, 116, 120, 118, 113, 110, 99, 123, 149, 172, 244, 295, 349, 399, 448, 494, 537, 521, 495, 470, 444, 423, 399, 375, 355, 323, 255, 205, 136, ]
    ylist = [495, 454, 386, 313, 334, 394, 455, 503, 549, 536, 535, 500, 456, 404, 325, 248, 193, 146, 94, 48, 75, 101, 122, 146, 171, 199, 218, 265, 312, 378, 421, 468, 516, 559, 597, 638, 633, 635, 636, ]
    zlist = [32, 1, 3, -34, -27, -10, 7, 28, 52, 28, 32, 44, 49, 35, 41, 34, 39, 34, 33, 39, 34, 52, 51, 36, 27, 35, 29, 22, 49, -151, 9, 16, 42, 29, 31, 40, 38, 53, 50, ]
    
    BlenderPlotter(xlist, ylist, zlist)

ForScriptGen()
