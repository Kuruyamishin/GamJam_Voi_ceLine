using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    List<Vector2> points;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void LineUpdate(Vector2 mousePos)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;

        }
        if(Vector2.Distance(points.Last(), mousePos) > .1f)
        {
            SetPoint(mousePos);
        }
    }

    void SetPoint(Vector2 point)
    {
        points.Add(point);

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, point);
        edgeCollider.points = points.ToArray();
    }
}
