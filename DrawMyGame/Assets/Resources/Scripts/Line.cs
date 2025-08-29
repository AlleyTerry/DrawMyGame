using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Line : MonoBehaviour
{
    //this script is for making the line, the other script is for generating the line on click
    public LineRenderer lineRenderer;
    
    //points that make up the line
    private List<Vector2> points;

    //adding a new point
    //updating our line renderer count
    //and saying where the new point is
    void SetPoint(Vector2 point)
    {
        points.Add(point);
        
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
    }
    
    //method to update line
    public void UpdateLine(Vector2 position)
    {
        //if there are not points yet, make a new list
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(position);
            return;
        }
        //check to make sure you are not adding the same point twice
        if (Vector2.Distance(points.Last(), position) > 0.1f)
        {
            SetPoint(position);
        }
    }
    
}
