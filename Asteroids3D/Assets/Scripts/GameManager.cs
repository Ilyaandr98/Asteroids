using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    static int level = 1;
    static int score;
    static int lifes = 3;
    int asteroidAmount;

    int scoreToGiveBonusLife = 2000;
    static int bonusScore;

    static bool hasLost;

    void Awake()
    {
      instance = this;
    }

    void Start()
    {
      if(hasLost)
      {
        level = 1;
        score = 0;
        lifes = 3;
        bonusScore = 0;
        hasLost = false;
      }

      UIManager.instance.UpdateUI();
    }

    public void AddAsteroid()
    {
      asteroidAmount++;
      //Debug.Log(asteroidAmount);
    }

    public void ReduceAsteroids()
    {
      asteroidAmount--;
      //Debug.Log(asteroidAmount);
      if(asteroidAmount <= 0)
      {
        //check wincondition
        //Debug.Log("Все астероиды уничтожены");
        level++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      }
      
    }

    public void AddScore(int amount)
    {
      score += amount;
      bonusScore += amount;
      AddBonusLife();
      UIManager.instance.UpdateUI();
    }

    public int ReadLevel()
    {
      return level;
    }

    void AddBonusLife()
    {
      if(bonusScore >= scoreToGiveBonusLife)
      {
        lifes++;
        bonusScore %= scoreToGiveBonusLife;
      }
    }

    public void LoseLife()
    {
      lifes--;
      UIManager.instance.UpdateUI();
      //losecondition
      if (lifes <= 0)
      {
         //game over
         ScoreHolder.level = level;
         ScoreHolder.score = score;
         //Debug.Log("Game over");
         hasLost = true;
         SceneManager.LoadScene("GameOver");
      }
    }

    public int ReadLifes()
    {
      return lifes;
    }

    public int ReadScore()
    {
      return score;
    }
}

