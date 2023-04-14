using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] float timeToCompletQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    public bool isAnsweringQuestion = false;
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

        if(timerValue <= 0)
        {
            if(!isAnsweringQuestion)
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompletQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }

        Debug.Log(timerValue);
    }
    #endregion
}
