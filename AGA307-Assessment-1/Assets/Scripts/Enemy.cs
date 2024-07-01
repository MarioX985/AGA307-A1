using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    float frames = 500;

    public int health;

    public EnemyType enemyType;

    private void Start()
    {
        Setup();
        StartCoroutine(Move());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            health -= 1;
        }
    }

    void Setup()
    {
        switch(enemyType)
        {
            case EnemyType.Archer:
                health = 50;
                break;
            case EnemyType.OneHand:
                health = 100;
                break;
            case EnemyType.TwoHand:
                health = 200;
                break;
        }

       /* if (enemy == EnemyType.Archer)
            health = 50;
        if (enemy == EnemyType.OneHand)
            health = 100;
        if (enemy == EnemyType.TwoHand)
            health = 200; */
    }

    IEnumerator Move()
    {
        for(int i = 0; i < frames; i++)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
            yield return null;
        }

        transform.Rotate(Vector3.up * 180);

        yield return new WaitForSeconds(3);

        StartCoroutine(Move());
    }

    void Hit(GameObject other)
    {
        GameEvents.OnEnemyHit(this);
            health--;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GameEvents.OnEnemyDie(this);
        StopAllCoroutines();
        Destroy(this.gameObject);
    }

}
