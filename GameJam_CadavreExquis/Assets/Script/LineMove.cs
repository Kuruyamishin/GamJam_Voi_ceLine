using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMove : MonoBehaviour
{
    public GameObject linePrefab;

    Line activeLine;

  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject lineGo = Instantiate(linePrefab);
            activeLine = lineGo.GetComponent<Line>();
        }
        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            activeLine.LineUpdate(mousePos);
        }
    }
}
