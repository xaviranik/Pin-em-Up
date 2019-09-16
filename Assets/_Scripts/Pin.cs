using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {
	//Pin Physics
	public float speed = 10f;
	public Rigidbody2D rb;
	//Pin Particles
	public GameObject hitParticle;
	public GameObject blastParticle;
	public GameObject bonusParticle;
	//Pin Audio
	public AudioSource audioSource;
	public AudioClip pinHitClip;
	public AudioClip pinScoreClip;
	public AudioClip gameOverClip;
	//Others
	private bool isPinned = false;
	private LevelManager levelManager;
	private Rotator rotator;

	private void Awake()
	{
		levelManager = GameObject.Find("Main Camera").GetComponent<LevelManager>();
		rotator = GameObject.Find("Rotator").GetComponent<Rotator>();
	}

	private void FixedUpdate()
	{
		if (!isPinned)
		{
			rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
		}
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Pin")
		{
			isPinned = true;
			audioSource.PlayOneShot(gameOverClip);
			levelManager.endGame();
			transform.SetParent(collision.transform);
			Instantiate(hitParticle, transform.position, transform.rotation);
			return;
		}
		else if (collision.tag == "Green")
		{
			isPinned = true;
			audioSource.PlayOneShot(pinScoreClip);
			//Score increament
			Score.pinCount++;
			//Cam Shake
			levelManager.camShake();

			//Inversing Rotation
			rotator.targetHit = !rotator.targetHit;
			Debug.Log("Green!");
			transform.SetParent(collision.transform);
			StartCoroutine(destroyPin(transform.gameObject));

		}
		else if (collision.tag == "Power")
		{
			isPinned = true;
			audioSource.PlayOneShot(pinScoreClip);
			//Score increament
			Score.pinCount += 5;
			//Cam Shake
			levelManager.camShake();

			//Inversing Rotation
			rotator.targetHit = !rotator.targetHit;
			Debug.Log("Bonus!");
			transform.SetParent(collision.transform);
			Instantiate(bonusParticle, transform.position, transform.rotation);
			StartCoroutine(destroyPin(transform.gameObject));

		}
		else if (collision.tag == "Rotator")
		{
			isPinned = true;
			audioSource.PlayOneShot(pinHitClip);
			Debug.Log("Rotator!");
			transform.SetParent(collision.transform);
			levelManager.camShake();
		}


	}

	private IEnumerator destroyPin(GameObject gameObject)
	{
		yield return new WaitForSeconds(0.5f);
		Instantiate(blastParticle, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
