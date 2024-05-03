using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private static Timer instance;

    public static Timer Instance { get => instance; }
    [SerializeField] TextMeshProUGUI timerText;
    private float elapsedTime;
    private bool isTimerRunning = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        elapsedTime += Time.deltaTime;
        UpdateUITimer(elapsedTime);
    }

    private void UpdateUITimer(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        timerText.text = FormatTime(minutes, seconds);
    }

    private string FormatTime(int minutes, int seconds)
    {
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateUITimer(elapsedTime);
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResumeTimer()
    {
        isTimerRunning = true; 
    }

    public float GetTimeWhenEndGame()
    {
        return elapsedTime;
    }

    public string GetFormattedTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return FormatTime(minutes, seconds);
    }
}