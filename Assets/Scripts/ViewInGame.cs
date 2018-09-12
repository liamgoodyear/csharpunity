using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ViewInGame : MonoBehaviour {

    public Text coinLabel;
    public Text scoreLabel;
    public Text highscoreLabel;

	// Update is called once per frame
	void Update () {
		if(GameManager.instance.currentGameState == GameState.inGame)
        {
            coinLabel.text = GameManager.instance.collectedCoins.ToString();
            scoreLabel.text = PlayerController.instance.GetDistance().ToString("f0");
            highscoreLabel.text = PlayerPrefs.GetFloat("highscore", 0).ToString("f0");
        }
	}
}
