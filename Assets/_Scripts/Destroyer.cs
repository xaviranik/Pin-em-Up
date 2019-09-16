using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	public float timeLimit = 2f;

	private void Start()
	{
		Destroy(this.gameObject, timeLimit);
	}
}
