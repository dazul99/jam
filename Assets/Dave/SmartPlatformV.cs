using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartPlatformV : MonoBehaviour
{

    private bool isOver = false;

    [SerializeField] private float max;
    private float min;

    private void Start()
    {
        min = transform.localScale.y;
    }

    private void Update()
    {
        if (isOver)
        {
            if(Input.GetMouseButton(1) && !(transform.localScale.y > max))
            {
                transform.localScale = transform.localScale + new Vector3(0, (float)1, 0) * Time.deltaTime;
                transform.localPosition = transform.localPosition + new Vector3(0, (float)0.5, 0) * Time.deltaTime;
            }
            if (Input.GetMouseButton(0) && !(transform.localScale.y < min))
            {
                transform.localScale = transform.localScale - new Vector3(0, (float)1, 0) * Time.deltaTime;
                transform.localPosition = transform.localPosition - new Vector3(0, (float)0.5, 0) * Time.deltaTime;
            }

        }
    }

    private void OnMouseEnter()
    {
        isOver = true;
    }

    private void OnMouseExit()
    {
        isOver = false;
    }

}
