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
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
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
}