using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public GameObject lineRenderer;

    public List<Vector2> points = null;
    public bool canTakePoints = true;
    public bool isClicking = false;

    private int movement = 50;
    public int speed;
    public int ascendSpeed;
    private Rigidbody2D rb;

    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            isClicking = Input.GetMouseButton(0);

            if (!isClicking && points.Count == 0)
            {
                canTakePoints = true;
                //rb.velocity = new Vector2(movement * speed * Time.deltaTime, 0);
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }


            if (canTakePoints && isClicking)
                points = lineRenderer.GetComponent<Line>().points;

            if (points.Count != 0 && isClicking)
            {
                MoveToPoint();
                canTakePoints = true;
            }

            else if (points.Count != 0 && !isClicking)
            {
                MoveToPoint();
                canTakePoints = false;
            }

            if (isClicking && points.Count == 0)
                canTakePoints = true;
        }
    }

    private void MoveToPoint()
    {
        if (!isDead)
        {
            Debug.Log("Je me déplace sur le tracé!");
            //rb.velocity = new Vector2(rb.velocity.x, points[0].y);
            //rb.velocity = new Vector2(0, points[0].y * speed * Time.deltaTime);
            transform.position = new Vector2(transform.position.x, points[0].y);

            if (transform.position.y >= points[0].y - 0.01f || transform.position.y <= points[0].y + 0.01f)
            {
                points.Remove(points[0]);
            }
        }
    }
}
