using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{

   public float maxDistance = 10;

    public LayerMask layerMask;

    void FixedUpdate()
    {
        Ray ray = new Ray(this.transform.position, Vector3.forward);
        RaycastHit hitInfo;

        if(Physics.Raycast(ray, out hitInfo, maxDistance, layerMask))
        {
            if(hitInfo.collider.tag == "Target")
            {
                hitInfo.collider.GetComponent<MeshRenderer>().material.color = Color.blue;
            }


            Debug.Log("We are hitting:" + hitInfo.collider.name);
        }
    }
}
