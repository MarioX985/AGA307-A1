using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public MeshRenderer sphereMesh;


    private int targetLifeTime = 2;

    public int targetHealth = 3;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Projectile")
        {
            targetHealth -= 1;
        }

        if(targetHealth == 0)
        {
            sphereMesh.material.color = Color.green;
            Destroy(this.gameObject, targetLifeTime);
        }
    }
}
