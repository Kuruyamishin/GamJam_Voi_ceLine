using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Line : MonoBehaviour
{
    private  LineRenderer lineRenderer = null;
    //private EdgeCollider2D edgeCollider;
    //public Shader shader;

    public List<Vector2> points = null;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        //edgeCollider = GetComponent<EdgeCollider2D>();
        lineRenderer.positionCount = 0;
       
        
        lineRenderer.useWorldSpace = true;
        

        points = new List<Vector2>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if(lineRenderer != null)
            {
                lineRenderer.positionCount = 0;
            }

            if(points != null)
            {
                points.Clear();
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0.0f;

            if(points.Contains(worldPos)== false)
            {
                points.Add(worldPos);

                lineRenderer.positionCount = points.Count;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, worldPos);
            }
        }
    }

    
}
