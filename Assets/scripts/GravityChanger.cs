using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public GameObject rotPoint;
    public GameObject rotateBody;
    public GameObject enviroment;
    public GameObject playerBody;


    // Start is called before the first frame update
    void Start()
    {
        rotateBody.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            rotateBody.SetActive(true);
            rotateBody.transform.RotateAround(rotPoint.transform.position , Vector3.right , -90f);
            StartCoroutine(reverse());
            //enviroment.transform.rotation = Quaternion.AngleAxis(90f, Vector3.right);
            enviroment.transform.Rotate(Vector3.left*90f,Space.World);
            //Physics.clothGravity = new Vector3(0, 0,9.8f);

        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            rotateBody.SetActive(true);
            rotateBody.transform.RotateAround(rotPoint.transform.position, Vector3.left, 90f);
            StartCoroutine(reverse());

            enviroment.transform.Rotate(Vector3.right*90f,Space.World);
            //Physics.clothGravity = new Vector3(0, 0, -9.8f);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rotateBody.SetActive(true);
            rotateBody.transform.RotateAround(rotPoint.transform.position, Vector3.forward, 90f);
            StartCoroutine(reverse());
            enviroment.transform.Rotate(Vector3.back*90f,Space.World);
            //Physics.clothGravity = new Vector3(9.8f, 0, 0);

        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rotateBody.SetActive(true);
            rotateBody.transform.RotateAround(rotPoint.transform.position, Vector3.forward, -90f);
            StartCoroutine(reverse());
            //Physics.clothGravity = new Vector3(9.8f, 0, 0);

            enviroment.transform.Rotate(Vector3.forward*90f,Space.World);
        }


    }


    IEnumerator reverse()
    {
        yield return new WaitForSeconds(1f);
        rotateBody.transform.position = playerBody.transform.position;
        rotateBody.transform.rotation = playerBody.transform.rotation;
        rotateBody.SetActive(false);
    }

   
}
