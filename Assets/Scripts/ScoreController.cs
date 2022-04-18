using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;    // Not being used but kept on for possible other levels. 


// Paul Kent Yochum
// Score and Timer Script
// 4/16/2022

public class ScoreController : MonoBehaviour
{

    public Text scoreText;
    private int score;
    float currentTime = 0f;
    float startingTime = 10f;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    [SerializeField] Text countDownText;
    
  
    void Start()
    {
        currentTime = startingTime;    // When level starts up, timer is set to starting time variable
        Resume();    // Sets timescale to 1 and pause menu to false in case game has started over from pause menu
    }

    void Update()
    {
        scoreText.text = score.ToString();    // Transfers int score to string
        currentTime -= 1 * Time.deltaTime;    // Updates deltaTime -1 from currentTime variable
        countDownText.text = currentTime.ToString("0");    // Updates string with currentTime value

        if(currentTime <= 0)    // Pauses game if time reaches 0
        {
            Pause();
            currentTime = 0;

        }
    }

    void Resume()    // Sets timescale to 1 and pause menu to inactive 
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }

    void Pause()    // Sets timescale to 0 and pause menu to active
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
        
    }



    void OnTriggerEnter2D(Collider2D target)    // Collision from spider tag into basket causes pase menu to pop up
    {
        if (target.tag == "Spider")
        {
            Pause();
        }
                     
    }

    void OnTriggerExit2D(Collider2D target)    // Collision from fruit tag into basket causes fruit object to destroy and score to increase by 1
    {
        if(target.tag == "Fruit")
        {
            Destroy(target.gameObject);
            score++;
        }
    }   
    
}
