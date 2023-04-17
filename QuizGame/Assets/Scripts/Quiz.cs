using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    #region VARIABLES
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question1;
    [SerializeField] QuestionSO question2;
    [SerializeField] QuestionSO question3;
    [SerializeField] QuestionSO question4;
    [SerializeField] QuestionSO question5;
    int currentQuestion = 0;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    bool hasAnsweredEarly = true;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Progress bar")]
    [SerializeField] Slider progressBar;

    public bool isComplete;
    #endregion

    #region EVENTS
    void Awake()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        progressBar.maxValue = 5;
        progressBar.value = 0;
    }

    void Update()
    {
        timerImage.fillAmount = timer.FillFraction;

        if(timer.LoadNextQuestion)
        {
            if(progressBar.value == progressBar.maxValue)
            {
                isComplete = true;
                return;
            }

            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.LoadNextQuestion = false;
        }
        else if(!hasAnsweredEarly && !timer.IsAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    #endregion

    #region METHODS
    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;        
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + scoreKeeper.CalculateScore() + "%";     
    }

    void GetNextQuestion()
    {
        if(currentQuestion <= 5)
        {
            currentQuestion++;
            SetButtonState(true);
            SetDefaultButtonSprite();
            DisplayQuestion(currentQuestion);
            progressBar.value++;
            scoreKeeper.IncrementQuestionsSeen();
        }
    }

    void DisplayQuestion(int currentQuestion)
    {
        if(currentQuestion == 1)
        {
            questionText.text = question1.GetQuestion();

            for(int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question1.GetAnswer(i);
            }
        }
        else if(currentQuestion == 2)
        {
            questionText.text = question2.GetQuestion();

            for(int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question2.GetAnswer(i);
            }
        }
        else if(currentQuestion == 3)
        {
            questionText.text = question3.GetQuestion();

            for(int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question3.GetAnswer(i);
            }
        }
        else if(currentQuestion == 4)
        {
            questionText.text = question4.GetQuestion();

            for(int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question4.GetAnswer(i);
            }
        }
        else if(currentQuestion == 5)
        {
            questionText.text = question5.GetQuestion();

            for(int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question5.GetAnswer(i);
            }
        }
    }

    void SetButtonState(bool state)
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Button>().interactable = state;
        }
    }

    void SetDefaultButtonSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Image>().sprite = defaultAnswerSprite;
        }
    }

    void DisplayAnswer(int index)
    {
        if(currentQuestion == 1)
        {
            if(index == question1.GetCorrectAnswerIndex())
            {
                questionText.text = "Correct!";
                answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;
                scoreKeeper.IncrementCorrectAnswers();
            }
            else
            {
                questionText.text = "Sorry, the correct answer was: \n" + question1.GetAnswer(question1.GetCorrectAnswerIndex());
                answerButtons[question1.GetCorrectAnswerIndex()].GetComponent<Image>().sprite = correctAnswerSprite;
            }
        }
        else if(currentQuestion == 2)
        {
            if(index == question2.GetCorrectAnswerIndex())
            {
                questionText.text = "Correct!";
                answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;
                scoreKeeper.IncrementCorrectAnswers();
            }
            else
            {
                questionText.text = "Sorry, the correct answer was: \n" + question2.GetAnswer(question2.GetCorrectAnswerIndex());
                answerButtons[question2.GetCorrectAnswerIndex()].GetComponent<Image>().sprite = correctAnswerSprite;
            }
        }
        if(currentQuestion == 3)
        {
            if(index == question3.GetCorrectAnswerIndex())
            {
                questionText.text = "Correct!";
                answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;
                scoreKeeper.IncrementCorrectAnswers();
            }
            else
            {
                questionText.text = "Sorry, the correct answer was: \n" + question3.GetAnswer(question3.GetCorrectAnswerIndex());
                answerButtons[question3.GetCorrectAnswerIndex()].GetComponent<Image>().sprite = correctAnswerSprite;
            }
        }
        if(currentQuestion == 4)
        {
            if(index == question4.GetCorrectAnswerIndex())
            {
                questionText.text = "Correct!";
                answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;
                scoreKeeper.IncrementCorrectAnswers();
            }
            else
            {
                questionText.text = "Sorry, the correct answer was: \n" + question4.GetAnswer(question4.GetCorrectAnswerIndex());
                answerButtons[question4.GetCorrectAnswerIndex()].GetComponent<Image>().sprite = correctAnswerSprite;
            }
        }
        if(currentQuestion == 5)
        {
            if(index == question5.GetCorrectAnswerIndex())
            {
                questionText.text = "Correct!";
                answerButtons[index].GetComponent<Image>().sprite = correctAnswerSprite;
                scoreKeeper.IncrementCorrectAnswers();
            }
            else
            {
                questionText.text = "Sorry, the correct answer was: \n" + question5.GetAnswer(question5.GetCorrectAnswerIndex());
                answerButtons[question5.GetCorrectAnswerIndex()].GetComponent<Image>().sprite = correctAnswerSprite;
            }
        }
    }
    #endregion
}
