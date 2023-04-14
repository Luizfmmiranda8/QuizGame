using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName ="New Question")]
public class QuestionSO : ScriptableObject
{
    #region VARIABLES
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question texte here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;
    #endregion

    #region METHODS
    public string GetQuestion()
    {
        return question;
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }
    #endregion
}
