using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour {

	private bool gameHasEnded = false;
	public Rotator rotator;
	public PinSpawner pinSpawner;

	public Animator animator;

	public void camShake()
	{
		if(!gameHasEnded)
		{
			animator.SetTrigger("Shake");
		}
		
	}

	public void endGame()
	{
		if(gameHasEnded)
		{
			return;
		}

		gameHasEnded = true;
		rotator.enabled = false;
		pinSpawner.enabled = false;

		animator.SetTrigger("EndGame");
	}

	public void restartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
