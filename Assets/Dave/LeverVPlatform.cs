using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverVPlatform : MonoBehaviour
{


    [SerializeField] private bool isOn = false;
    [SerializeField] private bool isOff = false;
    private bool playerColliding;

    [SerializeField] private float max;
    private float min;

    [SerializeField] private GameObject platfrom;

    private void Start()
    {
        min = platfrom.transform.localScale.y;
    }

    private void Update()
    {
        if(isOn)
        {
            if(!(platfrom.transform.localScale.y > max))
            {
                platfrom.transform.localScale = platfrom.transform.localScale + new Vector3 (0,(float)1,0) * Time.deltaTime;
                platfrom.transform.localPosition = platfrom.transform.localPosition + new Vector3(0, (float)0.5, 0) * Time.deltaTime;
            }
        }
        else if (isOff)
        {
            if (!(platfrom.transform.localScale.y < min))
            {
                platfrom.transform.localScale = platfrom.transform.localScale - new Vector3(0, (float)1, 0) * Time.deltaTime;
                platfrom.transform.localPosition = platfrom.transform.localPosition - new Vector3(0, (float)0.5, 0) * Time.deltaTime;
            }
        }

        if (playerColliding)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isOn && !isOff)
                {
                    isOff = true;
                }
                isOn = false;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if(!isOn && !isOff)
                {
                    isOn = true;
                }
                isOff = false;
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
