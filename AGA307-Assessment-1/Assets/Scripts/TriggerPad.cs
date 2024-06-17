using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    public GameObject sphere;   //The object we wish to change

    public MeshRenderer sphereMesh;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("Player"))
        {
            //change the spheres colour to green
            sphereMesh.material.color = Color.green;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Increas the spheres scale by 0.01 on all axis
            sphere.gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0.01f);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //set the spheres size back to 1
            sphere.gameObject.transform.localScale -= new Vector3(1, 1, 1);

            //Change the spheres colour to yellow
            sphereMesh.material.color = Color.yellow;
        }
    }
}

