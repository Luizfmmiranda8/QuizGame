using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    public bool IsAnsweringQuestion = false;
    public bool LoadNextQuestion;
    public float FillFraction;
    float timerValue;
    #endregion

    #region EVENTS
    void Update()
    {
        UpdateTimer();
    }
    #endregion

    #region METHODS
    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(IsAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                FillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                IsAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if(timerValue > 0)
            {
                FillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                IsAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                LoadNextQuestion = true;
            }
        }
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
    #endregion
}
