using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    public Transform targetSpawn;
    public GameObject[] targets;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnTarget();
        }
    }

    void SpawnTarget()
    {
        int rNum = Random.Range(0, targets.Length);
        Instantiate(targets[rNum], targetSpawn.position, targetSpawn.rotation);
    }
}
