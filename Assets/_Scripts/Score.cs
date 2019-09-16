using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour {

	public static int pinCount;
	public TextMeshProUGUI pinScoreText;
	public TextMeshProUGUI highScoreText;

	private void Start()
	{
		pinCount = 0;

		highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
	}

	private void Update()
	{
		pinScoreText.text = pinCount.ToString();

		if(pinCount > PlayerPrefs.GetInt("HighScore"))
		{
			PlayerPrefs.SetInt("HighScore", pinCount);
			highScoreText.text = pinCount.ToString();
		}
	}


}
