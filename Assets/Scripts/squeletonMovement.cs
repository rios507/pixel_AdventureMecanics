using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class squeleton_Movement : MonoBehaviour
{
    public Animator animed;
    public Rigidbody2D rigirid;

    public Collider2D target;
    public float speed;
    public Transform centerVision;
    public Vector2 sizeVision;
    public LayerMask layerVision;

    public float distance;
     // Start is called before the first frame update
    void Start()
    {
        animed = GetComponent<Animator>();
        rigirid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        target = Physics2D.OverlapBox(centerVision.position, sizeVision, 0, layerVision);
        animed.SetBool("PlayerDetected", target);
        if (target != null)
        {
            distance = Vector2.Distance(transform.position, target.transform.position);
            animed.SetFloat("DistanceOfPlayer", distance);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(centerVision.position, sizeVision);
    }
}
