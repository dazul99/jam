using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private int state;

    [SerializeField] private int type;

    [SerializeField] private float max;
    private float min;

    private void Start()
    {
        if (type == 0) min = transform.localScale.y;
        else min = transform.localScale.x;
    }

    private void Update()
    {
        if(state != 0)
        {
            if(type == 0)
            {
                if ((state == 1 && ! (max < transform.localScale.y)) || (state == -1 && !(min > transform.localScale.y))) 
                {
                    transform.localScale = transform.localScale + new Vector3(0, (float)1 * state, 0) * Time.deltaTime;
                    transform.localPosition = transform.localPosition + new Vector3(0, (float)0.5 * state, 0) * Time.deltaTime;
                }
            }
            else if (type == 1)
            {
                if ((state == 1 && !(max < transform.localScale.x)) || (state == -1 && !(min > transform.localScale.x)))
                {
                    transform.localScale = transform.localScale + new Vector3((float)1 * state, 0, 0) * Time.deltaTime;
                    transform.localPosition = transform.localPosition + new Vector3((float)0.5 * state, 0, 0) * Time.deltaTime;
                }
            }
            else if (type == 2)
            {
                if ((state == 1 && !(max < transform.localScale.x)) || (state == -1 && !(min > transform.localScale.x)))
                {
                    transform.localScale = transform.localScale + new Vector3((float)1 * state, (float)1 * state, 0) * Time.deltaTime;
                }
            }
            else if (type == 3)
            {
                if ((state == 1 && !(max < transform.localScale.x)) || (state == -1 && !(min > transform.localScale.x)))
                {
                    transform.localScale = transform.localScale + new Vector3((float)1 * state, 0, 0) * Time.deltaTime;
                    transform.localPosition = transform.localPosition - new Vector3((float)0.5 * state, 0, 0) * Time.deltaTime;
                }
            }
            else if (type == 4)
            {
                if ((state == 1 && !(max < transform.localScale.y)) || (state == -1 && !(min > transform.localScale.y)))
                {
                    transform.localScale = transform.localScale + new Vector3(0, (float)1 * state, 0) * Time.deltaTime;
                    transform.localPosition = transform.localPosition - new Vector3(0, (float)0.5 * state, 0) * Time.deltaTime;
                }
            }
        }
    }


    public void SetState(int x)
    {
        state = x;
    }

    public int GetState()
    {
        return state;
    }
}
