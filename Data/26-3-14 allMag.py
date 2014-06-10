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
    xlist = [-52, -63, -76, -136, -47, -52, -48, -48, -42, -56, -17, -3, -28, -46, -43, -48, -48, -39, -40, -37, -41, -39, -36, -26, -45, 0, -24, -6, 47, 81, -33, -48, -26, -50, -42, -39, -20, -33, -41, ]
    ylist = [-70, -81, -79, -69, -30, -86, -102, -100, -101, -86, -113, -104, -99, -93, -94, -89, -84, -98, -73, -92, -146, -145, -117, -59, -59, -50, -102, -74, -80, -107, -73, -90, -106, -77, -102, -127, -121, -106, -113, ]
    zlist = [32, 1, 3, -34, -27, -10, 7, 28, 52, 28, 32, 44, 49, 35, 41, 34, 39, 34, 33, 39, 34, 52, 51, 36, 27, 35, 29, 22, 49, -151, 9, 16, 42, 29, 31, 40, 38, 53, 50, ]
    
    BlenderPlotter(xlist, ylist, zlist)

ForScriptGen()
