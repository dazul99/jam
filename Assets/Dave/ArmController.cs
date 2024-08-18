using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    [SerializeField] private float max;
    private float min;

    [SerializeField] private GameObject hand;

    private void Start()
    {
        min = transform.localScale.x;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.C) && transform.localScale.x < max)
        {
            hand.transform.localPosition = hand.transform.localPosition + new Vector3((float)1, 0, 0) * Time.deltaTime;
            transform.localScale = transform.localScale + new Vector3((float)1, 0, 0) * Time.deltaTime;
            transform.localPosition = transform.localPosition + new Vector3((float)0.5, 0, 0) * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.Z) && transform.localScale.x > min) 
        {
            hand.transform.localPosition = hand.transform.localPosition - new Vector3((float)1, 0, 0) * Time.deltaTime;
            transform.localScale = transform.localScale - new Vector3((float)1, 0, 0) * Time.deltaTime;
            transform.localPosition = transform.localPosition - new Vector3((float)0.5, 0, 0) * Time.deltaTime;
        }
    }
}
