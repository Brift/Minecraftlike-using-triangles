using UnityEngine;
using System.Collections;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshCollider))]
[RequireComponent (typeof(MeshFilter))]

public class Triblock : Wedge 
{

	protected MeshRenderer meshRenderer;
	protected MeshCollider meshCollider;
	protected MeshFilter meshFilter;
	public bool filled;
	public bool changeable;
	public int blockType;

	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public Triblock ( int qside, int rside, int sside, int ylower, int yupper, bool direction, bool triblock)
	{
		q = qside;
		r = rside;
		s = sside;
		ymin = ylower;
		ymax = yupper;
		triDirection = direction;
		size = Mathf.Abs(q + r + s);
		
		int q2 = -(r + s);
		int r2 = -(q + s);
		int s2 = -(q + r);
		if( q == World.qBoundary || 
			q2 == World.qBoundary ||
			r == World.rBoundary ||
			r2 == World.rBoundary ||
			s == World.sBoundary ||
			s2 == World.sBoundary ||
			ymin == World.minHeight)
		{
			filled = true;
			changeable = false;
		}
	}
}
