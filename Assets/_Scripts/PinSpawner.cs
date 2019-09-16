using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour {

	public GameObject pinPrefab;
	public Animator animator;

	private void Update()
	{
		if(Input.GetButtonDown("Fire1"))
		{
			spawnPin();
			animator.SetTrigger("Shooting");

		}
	}

	private void spawnPin()
	{
		Instantiate(pinPrefab, transform.position, transform.rotation);
	}
}
