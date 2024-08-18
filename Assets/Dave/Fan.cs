using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private float length;
    [SerializeField] private float strength;
    [SerializeField] private bool isOn = false;
    [SerializeField] private int dir = 0;

    [SerializeField] private LayerMask playerLayer;

    private Vector2 direction;
    private bool hit;

    private void Start()
    {
        if (dir == 0)
        {
            direction = Vector2.left;
        }

        else if (dir == 1)
        {
            direction = Vector2.up;
        }
        else if (dir == 2)
        {
            direction = Vector2.right;
        }
        else direction = Vector2.down;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position + new Vector3(0,(float)0.8,0), Vector3.left * length);
        Debug.DrawRay(transform.position, Vector3.left * length);
        Debug.DrawRay(transform.position - new Vector3(0,(float)0.8, 0), Vector3.left * length);

        

        if (isOn)
        {
            RaycastHit2D hits = Physics2D.Raycast(transform.position + new Vector3(0, (float)0.8, 0), direction, length, playerLayer);
            hit = hits.collider != null;
            if (!hit)
            {
                hits = Physics2D.Raycast(transform.position - new Vector3(0, (float)0.8, 0), direction, length, playerLayer);
                hit = hits.collider != null;
                if (!hit)
                {
                    hits = Physics2D.Raycast(transform.position, direction, length, playerLayer);
                    hit = hits.collider != null;
                }
            }
            if(hit)
            {
                hits.rigidbody.AddForce(direction * strength);
            }

        }
    }

}
