using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wedge: MonoBehaviour 
{
	
	public Wedge[] childWedges;
	public int q;
	public int r;
	public int s;
	public int ymin;
	public int ymax;
	public int size;
	
	
	// Use this for initialization
	void Start () 
	{
		int q2 = -(r + s);
		int r2 = -(q + s);
		int s2 = -(q + r);
		int qmid = (q + q2)/2;
		int rmid = (r + r2)/2;
		int smid = (s + s2)/2;
		int ymid = (ymin + ymax)/2;
		
		if (size == 1)
		{
			childWedges[0] = new Triblock();
		}
		else
		{
			if(ymax > World.maxHeight)
			{
				//At the highest level only 2 child wedges will be created, the lower center and the lower rs corner
				if(size == World.maxSize)
				{
					childWedges[0] = null;
					childWedges[1] = null;
					childWedges[2] = null;
					childWedges[3] = null;
					childWedges[4] = new Wedge(qmid, rmid, smid, ymin, ymid);
					childWedges[5] = new Wedge(qmid, r, s, ymin, ymid);
					childWedges[6] = null;
					childWedges[7] = null;
				}
				//At the second highest level we create the hexagonal area that we will represent the farthest boundaries a player can go
				else if(size == (World.maxSize/2))
				{
					childWedges[0] = null;
					childWedges[1] = null;
					childWedges[2] = null;
					childWedges[3] = null;
					childWedges[4] = new Wedge(qmid, rmid, smid, ymin, ymid);
					childWedges[5] = null;
					childWedges[6] = new Wedge(q, rmid, s, ymin, ymid);
					childWedges[7] = new Wedge(q, r, smid, ymin, ymid);
				}
				else
				{
					childWedges[0] = null;
					childWedges[1] = null;
					childWedges[2] = null;
					childWedges[3] = null;
					childWedges[4] = new Wedge(qmid, rmid, smid, ymin, ymax);
					childWedges[5] = new Wedge(qmid, r, s, ymin, ymid);
					childWedges[6] = new Wedge(q, rmid, s, ymin, ymid);
					childWedges[7] = new Wedge(q, r, smid, ymin, ymid);	
				}
			}
			else
			{
				//Wedge 0 is the center upper wedge, which will be opposite facing
				childWedges[0] = new Wedge(qmid, rmid, smid, ymid, ymax);
				//Wedge 1 is the upper rs corner, or the wedge that is located in the corner where r and s meet
				childWedges[1] = new Wedge(qmid, r, s, ymid, ymax);
				//
				childWedges[2] = new Wedge(q, rmid, s, ymid, ymax);
				childWedges[3] = new Wedge(q, r, smid, ymid, ymax);
				childWedges[4] = new Wedge(qmid, rmid, smid, ymin, ymax);
				childWedges[5] = new Wedge(qmid, r, s, ymin, ymid);
				childWedges[6] = new Wedge(q, rmid, s, ymin, ymid);
				childWedges[7] = new Wedge(q, r, smid, ymin, ymid);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	public void Draw ()
	{
		for( int i = 0; i < 8; i++ )
		{
			childWedges[i].Draw();
		} 
	}
	
	public Wedge(int qside,int rside, int sside, int ylower, int yupper)
	{
		q = qside;
		r = rside;
		s = sside;
		ymin = ylower;
		ymax = yupper;
		size = Mathf.Abs(q + r + s);
	}
}
