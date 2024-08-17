using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BlockTutorial : MonoBehaviour
{
    private int step = 1;

    [SerializeField] private GameObject moveGround;
    [SerializeField] private GameObject text1;
    [SerializeField] private GameObject text2;
    [SerializeField] private GameObject text3;
    [SerializeField] private GameObject text4;
    [SerializeField] private GameObject text5;

    [SerializeField] private Transform cam;
    [SerializeField] private Camera camcam;

    [SerializeField] private Vector3 newCamLoc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (step == 1)
            {
                moveGround.transform.Translate(0, -14, 0);
                text1.active = false;
                text2.active = true;
                transform.position = new Vector3(5.5f, transform.position.y, 0);
                step++;
            }
            else if (step == 2)
            {
                moveGround.active = false;
                text2.active = false;
                text3.active = true;
                transform.position = new Vector3(0,-18,0);
                transform.localScale = new Vector3(8,1,1);
                step++;
            }
            else if (step == 3)
            {
                cam.position = newCamLoc;
                camcam.orthographicSize = 10;
                transform.localScale = new Vector3(1, 1, 1);
                transform.position = new Vector3(31.3f,-18.5f,0);
                text3.active = false;
                text4.active = true;
                step++;
            }
            else if (step == 4)
            {
                Debug.Log("Tutorial completado :D");
            }
            


        }
    }






}
