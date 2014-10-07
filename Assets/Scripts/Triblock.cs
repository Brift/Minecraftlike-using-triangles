using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshCollider))]
[RequireComponent (typeof(MeshFilter))]

public class Triblock : Wedge 
{
	public Mesh visualMesh;
	protected MeshRenderer meshRenderer;
	protected MeshCollider meshCollider;
	protected MeshFilter meshFilter;
	public bool filled;
	public bool changeable;
	public int blockType;
	protected Vector3[] verts;
	protected Vector2[] uvs;
	protected int[] tris;
	protected int q2, r2, s2;
	
	public Triblock (int qside, int rside, int sside, int ylower, int yupper, bool direction):
	base(qside, rside, sside, ylower, yupper, direction)
	{
		q = qside;
		r = rside;
		s = sside;
		ymin = ylower;
		ymax = yupper;
		triDirection = direction;
		size = Mathf.Abs(q + r + s);
		
		q2 = -(r + s);
		r2 = -(q + s);
		s2 = -(q + r);
		if( q == World.qBoundary ||
		   q == -World.qBoundary || 
		   q2 == World.qBoundary ||
		   q2 == -World.qBoundary ||
		   r == World.rBoundary ||
		   r == -World.rBoundary ||
		   r2 == World.rBoundary ||
		   r2 == -World.rBoundary ||
		   s == World.sBoundary ||
		   s == -World.sBoundary ||
		   s2 == World.sBoundary ||
		   s2 == -World.sBoundary ||
		   ymin == World.minHeight)
		{
			filled = true;
			changeable = false;
		}
		else
		{
			filled = false; //this is just to make sure we can draw the boundaries and won't stay
			changeable = true;
		}
		
	}
	
	// Use this for initialization
	void Start () 
	{
		meshRenderer = GetComponent<MeshRenderer>();
		meshCollider = GetComponent<MeshCollider>();
		meshFilter = GetComponent<MeshFilter>();
		
		Vector3 vertex1 = new Vector3();
		vertex1 = RYStoXYZ((float) r,(float) ymax,(float) s);
		
		verts[0] = vertex1;
		verts[1] = RYStoXYZ((float) r,(float) ymax,(float) s2);
		verts[2] = RYStoXYZ((float) r2,(float) ymax,(float) s);
		verts[3] = RYStoXYZ((float) r,(float) ymin,(float) s);
		verts[4] = RYStoXYZ((float) r,(float) ymin,(float) s2);
		verts[5] = RYStoXYZ((float) r2,(float) ymin,(float) s);
		
		tris[0] = 0;
		tris[1] = 1;
		tris[2] = 2;
		
		CreateVisualMesh();
			
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	public virtual void CreateVisualMesh()
	{
		visualMesh = new Mesh();
		
		visualMesh.vertices = verts;
		visualMesh.uv = uvs;
		visualMesh.triangles = tris;
		visualMesh.RecalculateBounds();
		visualMesh.RecalculateNormals();
		
		meshFilter.mesh = visualMesh;
		meshCollider.sharedMesh = visualMesh;
				
	}
	
	public Vector3 RYStoXYZ(float r, float y, float s)
	{
		Vector3 conversion = new Vector3();
		conversion.x = r - (1/2 * s);
		conversion.y = y;
		conversion.z = s * World.DEPTH;
		
		return conversion;		
	}
	
	//public virtual void BuildTopFace
	
	
}
