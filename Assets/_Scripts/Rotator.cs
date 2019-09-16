using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float rotationSpeed = 100f;
	public bool targetHit = false;

	private int randomChance = 1;

	private void Start()
	{
		StartCoroutine(getRandomNum());
	}


	private IEnumerator getRandomNum()
	{
		while(true)
		{
			yield return new WaitForSeconds(2f);
			randomChance = Random.Range(0, 2);

			if(randomChance > 0)
			{
				targetHit = !targetHit;
			}
		}
		
	}

	public void Update()
	{
		if(!targetHit)
		{
			transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
		}
		else
		{
			transform.Rotate(0f, 0f, rotationSpeed  * Time.deltaTime);
		}
	}
}
