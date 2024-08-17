using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Button : MonoBehaviour
{

    private bool isOn;

    [SerializeField] private float max;
    private float min;

    [SerializeField] private GameObject platfrom;

    private void Start()
    {
        min = platfrom.transform.localScale.y;
    }

    private void Update()
    {
        if (isOn)
        {
            if(Input.GetKey(KeyCode.W))
            {
                if((float)(platfrom.transform.localScale.y + 0.1) < max)
                {
                    platfrom.transform.localScale = platfrom.transform.localScale + new Vector3 (0,(float)1, 0)* Time.deltaTime;
                    platfrom.transform.localPosition = platfrom.transform.localPosition + new Vector3(0, (float)0.5, 0) * Time.deltaTime;
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if ((float)(platfrom.transform.localScale.y - 0.1) > min)
                {
                    platfrom.transform.localScale = platfrom.transform.localScale - new Vector3(0, (float)1, 0) * Time.deltaTime;
                    platfrom.transform.localPosition = platfrom.transform.localPosition - new Vector3(0, (float)0.5, 0) * Time.deltaTime;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isOn = false;
        }
    }

}
