using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public CharacterController controller;

	public float movementSpeed = 12f;

	[Header("Projectile Settings")]

	public Transform projectileSpawn;
	public GameObject projectilePrefab;
    public int projectileSpeed = 20;
	public int projectileLifeTime = 2;

    private void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");


		Vector3 movement = transform.right * x + transform.forward * z;


		controller.Move(movement * movementSpeed * Time.deltaTime);



		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		GameObject proj = Instantiate(projectilePrefab, projectileSpawn.position, projectileSpawn.rotation);

		proj.GetComponent<Rigidbody>().velocity = projectileSpawn.forward * projectileSpeed;
		Destroy(proj, projectileLifeTime);
	}
}
