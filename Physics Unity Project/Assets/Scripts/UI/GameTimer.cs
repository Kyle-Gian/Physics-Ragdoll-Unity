using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameTimer : MonoBehaviour
{
    float currentTime = 0f;

    [HideInInspector]
    public static float _finalTime;

    [SerializeField] TextMeshProUGUI timerText = null;
    [SerializeField] TextMeshProUGUI bestTimeText = null;
    [SerializeField] TextMeshProUGUI finishedText = null;
    [SerializeField] TextMeshProUGUI gameCompletedText = null;

    [SerializeField] Button restartButton = null;
    [SerializeField] Button exitButton = null;


    public static bool timerFinished = false;
    // Start is called before the first frame update
    void Start()
    {
        gameCompletedText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        if (!timerFinished)
        {
            currentTime += 1 * Time.deltaTime;
            DisplayTime(currentTime);
            DisplayHighScore(_finalTime);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            finishedText.gameObject.SetActive(true);
            gameCompletedText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
            _finalTime = currentTime;
            DisplayHighScore(_finalTime);
        }

    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); //converts time to minutes
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // converts time 

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    void DisplayHighScore(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); //converts time to minutes
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // converts time 

        bestTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
