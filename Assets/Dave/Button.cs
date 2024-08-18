using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Button : MonoBehaviour
{

    private bool isOn;


    [SerializeField] private Platform platfrom;


    private void Update()
    {
        if (isOn)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                platfrom.SetState(1);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                platfrom.SetState(0);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                platfrom.SetState(-1);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                platfrom.SetState(0);
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
