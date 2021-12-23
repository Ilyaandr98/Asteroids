using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ReadScore : MonoBehaviour
{
    public Text highscoreText,highestLevelText;

    void Start()
    {
      highscoreText.text = "HighScore: " + ScoreHolder.score;
      highestLevelText.text = "Your Level: " + ScoreHolder.level;
    }

    
}
