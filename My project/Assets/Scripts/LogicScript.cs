using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOver;
    public GameObject pauseButton;
    public static LogicScript instance;


    void Start(){
        instance = this;
    }

    public void ShowGameOver(){
        gameOver.SetActive(true);
        pauseButton.SetActive(false);
    }

    public void RestartGame(){
        SceneManager.LoadScene("SampleScene");
    }

    [ContextMenu("Increase Score")]
    public void addScore(){
        playerScore = playerScore + 1;
        scoreText.text = playerScore.ToString();
    }
}
