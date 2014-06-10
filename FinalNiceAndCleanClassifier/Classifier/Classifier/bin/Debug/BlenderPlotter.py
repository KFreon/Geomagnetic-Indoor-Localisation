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
    bpy.ops.mesh.primitive_uv_sphere_add(segments=32, ring_count=16, size=*s*, location=(x,y,z), rotation=(0,0,0))
    
#BlenderPlotter([1,2],[5,6],[9,0])


def ForScriptGen():
    xlist = "*x*"
    ylist = "*y*"
    zlist = "*z*"
    
    BlenderPlotter(xlist, ylist, zlist)

ForScriptGen()
