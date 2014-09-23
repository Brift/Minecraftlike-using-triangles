using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshCollider))]
[RequireComponent (typeof(MeshFilter))]

public class Wedge {
	
	public Wedge[] childWedges;
	public Wedge rootWedge;
	public Mesh visualMesh;
	public static float DEPTH = (Mathf.Sqrt(3)/2);
	public enum solid {filled, empty, mixed};
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
