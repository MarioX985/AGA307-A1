using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public CharacterController controller;

	public float movementSpeed = 12f;

	[Header("Projectile Settings")]

	public Transform projectileSpawn;
	public GameObject[] projectilePrefab;
    public int projectileSpeed = 20;
	public int projectileLifeTime = 2;
	public int currentWeapon;

    private void Update()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");


		Vector3 movement = transform.right * x + transform.forward * z;


		controller.Move(movement * movementSpeed * Time.deltaTime);

		ChangeWeapon();

		if (Input.GetButtonDown("Fire1"))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		GameObject proj = Instantiate(projectilePrefab[currentWeapon], projectileSpawn.position, projectileSpawn.rotation);

		proj.GetComponent<Rigidbody>().velocity = projectileSpawn.forward * projectileSpeed;
		Destroy(proj, projectileLifeTime);
	}

	void ChangeWeapon()
	{
		if (Input.GetKeyDown("1"))
		{
			currentWeapon = 0;

		}
		else if (Input.GetKeyDown("2"))
		{
			currentWeapon = 1;
		}
		else if (Input.GetKeyDown("3"))
		{
			currentWeapon = 2;
		}
	}
}
