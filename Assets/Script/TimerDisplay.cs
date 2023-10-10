using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TimerDisplay : MonoBehaviour
{
    public float timePlayInSeconds;
    public TMP_Text textComponent;
    [HideInInspector]
    public float timeInSeconds;
    public bool isStart;

    void Update()
    {
        if (isStart)
        {
            TimerNow();
        }
        //Debug.Log("Update");
    }

    private void OnEnable()
    {
        timeInSeconds = timePlayInSeconds;
        Debug.Log("OnEnable");
        isStart = false;
    }

    public void TimerNow()
    {
        if (GameManager.Instance.IsGameOver) return;
        //Debug.Log("Update isStart true");

        // Meningkatkan waktu dengan Time.deltaTime
        timeInSeconds = timeInSeconds - Time.deltaTime;
        if (timeInSeconds <= 0f)
        {
            timeInSeconds = 0f;
            GameManager.Instance.gameOver();
        }
        //Debug.Log("TIS: " + timeInSeconds);

        // Konversi waktu ke format menit:detik
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);

        // Mengatur teks untuk menampilkan waktu
        textComponent.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        
    }
}
