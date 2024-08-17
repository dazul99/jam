using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerDav : MonoBehaviour
{

    private Rigidbody2D rigid;

    [SerializeField] private float speed = 10f;
    [SerializeField] private float jump = 10f;
    [SerializeField] private float dash = 10f;


    private bool canDash = true;
    private bool dashing = false;
    private float dashCD = 1f;
    private float dashTime = 0.2f;
    private float horiz;
    private float dir = 1;
    private bool lookingLeft = false;

    private bool touchingGround = false;


    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (dashing) return;

        horiz = Input.GetAxis("Horizontal");

        rigid.velocity = new Vector2(horiz* speed,rigid.velocity.y);

        if(horiz > 0.01 && lookingLeft)
        {
            dir = 1;
            lookingLeft = false;
            transform.localScale = Vector3.one;
        }
        else if (horiz < -0.01 && !lookingLeft)
        {
            dir = -1;
            lookingLeft = true;
            transform.localScale = new Vector3(-1,1,1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && touchingGround)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jump);
            touchingGround = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            touchingGround = true;
        }
        
    }

    private IEnumerator Dash()
    {
        canDash = false;
        dashing = true;
        float aux = rigid.gravityScale;
        rigid.gravityScale = 0;
        rigid.velocity = new Vector2(transform.localScale.x * dash, 0f);
        yield return new WaitForSeconds(dashTime);
        rigid.gravityScale = aux;
        dashing = false;
        yield return new WaitForSeconds(dashCD);
        canDash = true;
    }
}
