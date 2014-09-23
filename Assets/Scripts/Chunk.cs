using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshCollider))]
[RequireComponent (typeof(MeshFilter))]

public class Chunk : MonoBehaviour 
{
	public byte[,,,] map;
	public Mesh visualMesh;
	protected MeshRenderer meshRenderer;
	protected MeshCollider meshCollider;
	protected MeshFilter meshFilter;
	public static float DEPTH = (Mathf.Sqrt(3)/2);
	
	// Use this for initialization
	void Start () 
	{
		meshRenderer = GetComponent<MeshRenderer>();
		meshCollider = GetComponent<MeshCollider>();
		meshFilter = GetComponent<MeshFilter>();
		
		map = new byte[World.currentWorld.chunkWidth, World.currentWorld.chunkHeight, World.currentWorld.chunkWidth, 2];

		for (int x = 0; x < World.currentWorld.chunkWidth; x++) 
		{
			for (int z = 0; z < World.currentWorld.chunkWidth; z++) 
			{
				for (int t = 0; t < 2; t++) 
				{
					map [x, 0, z, t] = 1;
					map [x, 1, z, t] = (byte)Random.Range (0, 1);
				}
			}
		}
		
		CreateVisualMesh();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public virtual void CreateVisualMesh()
	{
		visualMesh = new Mesh();
		
		List<Vector3> verts = new List<Vector3>();
		List<Vector2> uvs = new List<Vector2>();
		List<int> tris = new List<int>();
		
		for (int r = 0; r < World.currentWorld.chunkWidth; r++) 
		{
			for (int y = 0; y < World.currentWorld.chunkHeight; y++)
			{
				for (int s = 0; s < World.currentWorld.chunkWidth; s++) 
				{
					for (int t = 0; t < 2; t++) 
					{
						if(map[r,y,s,t] == 0) continue;
						
						if (t == 0)
						{
							
						}		
						
					}
				}
			}
		}
		
		visualMesh.vertices = verts.ToArray();
		visualMesh.uv = uvs.ToArray();
		visualMesh.triangles = tris.ToArray();
		visualMesh.RecalculateBounds();
		visualMesh.RecalculateNormals();
		
		meshFilter.mesh = visualMesh;
		meshCollider.sharedMesh = visualMesh;		
	}

	/// <summary>
	/// Builds the side face.
	/// </summary>
	/// <param name="triblock">Triblock.</param>
	/// <param name="llcorner">Lower left corner.</param>
	/// <param name="ulcorner">Upper left corner.</param>
	/// <param name="urcorner">Upper right corner.</param>
	/// <param name="lrcorner">Lower right corner.</param>
	/// <param name="reversed">If set to <c>true</c> reversed.</param>
	/// <param name="verts">Verts.</param>
	/// <param name="uvs">Uvs.</param>
	/// <param name="tris">Tris.</param>
	public virtual void BuildSideFace(byte triblock, Vector3 llcorner, Vector3 ulcorner, Vector3 urcorner, Vector3 lrcorner, bool reversed, List<Vector3> verts, List<Vector2> uvs,List<int> tris)
	{
		int index = verts.Count;
		
		verts.Add(llcorner);
		verts.Add(ulcorner);
		verts.Add(urcorner);
		verts.Add(lrcorner);
		
		uvs.Add (new Vector2(0,0));
		uvs.Add (new Vector2(0,1));
		uvs.Add (new Vector2(1,1));
		uvs.Add (new Vector2(1,0));
		
		if(reversed)
		{
			tris.Add(index + 0);
			tris.Add(index + 1);
			tris.Add(index + 2);
			tris.Add(index + 2);
			tris.Add(index + 3);
			tris.Add(index + 0);
		}
		else
		{
			tris.Add(index + 1);
			tris.Add(index + 0);
			tris.Add(index + 2);
			tris.Add(index + 3);
			tris.Add(index + 2);
			tris.Add(index + 0);
		}
	
	}
	/// <summary>
	/// Builds the top or bottom face of a triblock.
	/// </summary>
	/// <param name="triblock">Triblock.</param>
	/// <param name="corner">Corner.</param>
	/// <param name="up">Up.</param>
	/// <param name="right">Right.</param>
	/// <param name="reversed">If set to <c>true</c> reversed.</param>
	/// <param name="verts">List of Vertices used to build the mesh.</param>
	/// <param name="uvs">List of Uvs that will dictate what texture to apply.</param>
	/// <param name="tris">Tris.</param>
	public virtual void BuildTopFace(byte triblock, Vector3 corner, Vector3 up, Vector3 right, bool reversed, List<Vector3> verts, List<Vector2> uvs,List<int> tris)
	{
		int index = verts.Count;
		
		verts.Add(corner);
		verts.Add(corner + up);
		verts.Add(corner + up + right);
		verts.Add(corner + right);
		
		uvs.Add (new Vector2(0,0));
		uvs.Add (new Vector2(0,1));
		uvs.Add (new Vector2(1,1));
		uvs.Add (new Vector2(1,0));
		
		if(reversed)
		{
			tris.Add(index + 0);
			tris.Add(index + 1);
			tris.Add(index + 2);
			tris.Add(index + 2);
			tris.Add(index + 3);
			tris.Add(index + 0);
		}
		else
		{
			tris.Add(index + 1);
			tris.Add(index + 0);
			tris.Add(index + 2);
			tris.Add(index + 3);
			tris.Add(index + 2);
			tris.Add(index + 0);
		}
		
	}
}
