using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;
    #endregion

    #region EVENTS
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    #endregion

    #region METHODS
    public void ShowFinalScore()
    {
        finalScoreText.text = "Congratulations!\n You got a score of " + 
                                scoreKeeper.CalculateScore() + "%";
    }
    #endregion
}
