using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour {

	public TextMeshProUGUI highScoreText;

	private void Start()
	{
		highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
	}

	public void playGame()
	{
		SceneManager.LoadScene("MainLevel");
	}
	
}
