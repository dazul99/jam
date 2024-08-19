using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverExtended : MonoBehaviour
{
    [SerializeField] private int state = 0;
    private bool playerColliding;

    [SerializeField] private Platform platfrom;


    private void Update()
    {


        if (playerColliding)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (state != -1)
                {
                    state -= 1;
                    platfrom.SetState(state);
                }

            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (state != 1)
                {
                    state += 1;
                    platfrom.SetState(state);
                }

            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerColliding = false;
        }
    }
}
