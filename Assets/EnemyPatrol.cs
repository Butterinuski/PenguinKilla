using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject PointA;
    public GameObject PointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = PointB.transform;
        flip();  // Makes the penguin to flip on start
    }

    
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;  // Penguin walk from point to point 
        if (currentPoint == PointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointB.transform) // When they hit a point, they flip and head to next point
        {
            flip();
            currentPoint = PointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == PointA.transform)
        {
            flip();
            currentPoint = PointB.transform;
        }
    }

    private void flip()  // Flips when the penguin touches a point
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()  // Allows the points to be seen in scene view
    {
        Gizmos.DrawWireSphere(PointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PointB.transform.position, 0.5f);
        Gizmos.DrawLine(PointA.transform.position, PointB.transform.position);
    }
}