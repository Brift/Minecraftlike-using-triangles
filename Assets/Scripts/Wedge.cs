using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Wedges are a pentahedron comprised of equilateral triangles for top and bottom and three squares on the sides.
/// </summary>
public class Wedge: MonoBehaviour 
{
	
	public Wedge[] childWedges;
	public int q;
	public int r;
	public int s;
	public int ymin;
	public int ymax;
	public int size;
	// triDirection dictates whether the wedge is an upper facing wedge, meaning that the s edge is along the x set of planes
	// and the rest of the wedge is above in a positive Z direction or a negative
	public bool triDirection;
	
	
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
			//Wedge 0 is the center upper wedge, which will be opposite facing from the parent wedge
			childWedges[0] = new Triblock(qmid, rmid, smid, ymid, ymax, !triDirection, true);
			//Wedge 1 is the upper rs corner, or the wedge that is located in the corner where r and s meet
			childWedges[1] = new Triblock(qmid, r, s, ymid, ymax, triDirection, true );
			//Wedge 2 is the upper qs corner, or the wedge that is located in the corner where q and s meet
			childWedges[2] = new Triblock(q, rmid, s, ymid, ymax, triDirection, true);
			//Wedge 3 is the upper qr corner, or the wedge that is located in the corner where q and r meet
			childWedges[3] = new Triblock(q, r, smid, ymid, ymax, triDirection, true);
			//Wedge 4 is the center lower wedge, which will be opposite facing from the parent wedge
			childWedges[4] = new Triblock(qmid, rmid, smid, ymin, ymax, !triDirection, true);
			//Wedge 5 is the lower rs corner, or the wedge that is located in the corner where r and s meet
			childWedges[5] = new Triblock(qmid, r, s, ymin, ymid, triDirection, true);
			//Wedge 6 is the lower qs corner, or the wedge that is located in the corner where q and s meet
			childWedges[6] = new Triblock(q, rmid, s, ymin, ymid, triDirection, true);
			//Wedge 7 is the upper qr corner, or the wedge that is located in the corner where q and r meet
			childWedges[7] = new Triblock(q, r, smid, ymin, ymid, triDirection, true);
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
					childWedges[4] = new Wedge(qmid, rmid, smid, ymin, ymid, !triDirection);
					childWedges[5] = new Wedge(qmid, r, s, ymin, ymid, triDirection);
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
					childWedges[4] = new Wedge(qmid, rmid, smid, ymin, ymid, !triDirection);
					childWedges[5] = null;
					childWedges[6] = new Wedge(q, rmid, s, ymin, ymid, triDirection);
					childWedges[7] = new Wedge(q, r, smid, ymin, ymid, triDirection);
				}
				else
				{
					childWedges[0] = null;
					childWedges[1] = null;
					childWedges[2] = null;
					childWedges[3] = null;
					childWedges[4] = new Wedge(qmid, rmid, smid, ymin, ymax, !triDirection);
					childWedges[5] = new Wedge(qmid, r, s, ymin, ymid, triDirection);
					childWedges[6] = new Wedge(q, rmid, s, ymin, ymid, triDirection);
					childWedges[7] = new Wedge(q, r, smid, ymin, ymid, triDirection);	
				}
			}
			else
			{
				//Wedge 0 is the center upper wedge, which will be opposite facing from the parent wedge
				childWedges[0] = new Wedge(qmid, rmid, smid, ymid, ymax, !triDirection);
				//Wedge 1 is the upper rs corner, or the wedge that is located in the corner where r and s meet
				childWedges[1] = new Wedge(qmid, r, s, ymid, ymax, triDirection);
				//Wedge 2 is the upper qs corner, or the wedge that is located in the corner where q and s meet
				childWedges[2] = new Wedge(q, rmid, s, ymid, ymax, triDirection);
				//Wedge 3 is the upper qr corner, or the wedge that is located in the corner where q and r meet
				childWedges[3] = new Wedge(q, r, smid, ymid, ymax, triDirection);
				//Wedge 4 is the center lower wedge, which will be opposite facing from the parent wedge
				childWedges[4] = new Wedge(qmid, rmid, smid, ymin, ymax, !triDirection);
				//Wedge 5 is the lower rs corner, or the wedge that is located in the corner where r and s meet
				childWedges[5] = new Wedge(qmid, r, s, ymin, ymid, triDirection);
				//Wedge 6 is the lower qs corner, or the wedge that is located in the corner where q and s meet
				childWedges[6] = new Wedge(q, rmid, s, ymin, ymid, triDirection);
				//Wedge 7 is the upper qr corner, or the wedge that is located in the corner where q and r meet
				childWedges[7] = new Wedge(q, r, smid, ymin, ymid, triDirection);
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
	
	public Wedge(int qside,int rside, int sside, int ylower, int yupper, bool direction)
	{
		q = qside;
		r = rside;
		s = sside;
		ymin = ylower;
		ymax = yupper;
		triDirection = direction;
		size = Mathf.Abs(q + r + s);
	}
}
