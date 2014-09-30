using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class World : MonoBehaviour 
{
	public static World currentWorld;
	public static float DEPTH = (Mathf.Sqrt(3)/2);
	// All of these values must be a power of 2
	public static int maxSize = 4096;
	public static int maxHeight = 256;
	public static int qBoundary = 1024;
	public static int rBoundary = 1024;
	public static int sBoundary = 1024;
	public static int minHeight = 0;
	public static int seed;
	public List<Triblock> triblocks;
	


	// Use this for initialization
	void Awake () 
	{
		currentWorld = this;
		if (seed == 0) 
		{
			seed = Random.Range (0, int.MaxValue);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
