using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public TMPro.TextMeshProUGUI questionText;
    public TMPro.TextMeshProUGUI scoreText;
    public Button[] answerButtons;
    public QuizData quizData;
    private List<QuestionData> questions;
    private int currentQuestionIndex;
    private int score;
    public GameObject EndScreen;
    public GameObject QuizScreen;
    public TMPro.TextMeshProUGUI timerText;
    public float maxTime = 15f; // Set the initial time limit per question
    private float timeRemaining;
    private float initialWidth;
    public RectTransform panelTransform;
    private AudioClip timerSound; // Assign the sound clip in the Inspector
    public AudioSource audioSource;

    public void StartQuiz()
    {
        timeRemaining = maxTime;
        currentQuestionIndex = 0;
        score = 0;
        initialWidth = panelTransform.rect.width;
        LoadQuestions();
        SetNextQuestion();
        InvokeRepeating("UpdateTimer", 1f, 1f); // Start the timer
        audioSource = GetComponent<AudioSource>();
    }

    void LoadQuestions()
    {
        questions = new List<QuestionData>(quizData.questions);
    }

    void SetNextQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            QuestionData question = questions[currentQuestionIndex];
            questionText.text = question.question;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = question.answers[i];
            }

            
            timeRemaining = maxTime; // Reset the timer for the next question
            panelTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initialWidth);
        }
        else
        {
            EndQuiz();
        }
    }

    public void AnswerButtonClick(int answerIndex)
    {

            QuestionData question = questions[currentQuestionIndex];
            if (question.correctAnswerIndex == answerIndex)
            {
                score++;
            }
            currentQuestionIndex++;
  
            SetNextQuestion();
    }

    void Update()
    {
        timerText.text = Mathf.Round(timeRemaining).ToString();
    }

    void UpdateScoreText()
    {
        scoreText.text = score + " из " + questions.Count;
    }

    void EndQuiz()
    {
        UpdateScoreText();
        panelTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initialWidth);
        EndScreen.SetActive(true);
        QuizScreen.SetActive(false);
        CancelInvoke("UpdateTimer"); // Stop the timer when the quiz ends
    }

    void UpdateTimer()
    {
        timeRemaining -= 1f;
        timerText.text = Mathf.Round(timeRemaining).ToString();

        float fillAmount = timeRemaining / maxTime; // ¬ычисл€ем заполнение шкалы относительно текущего и максимального времени
        Debug.Log(fillAmount);
        panelTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, initialWidth * fillAmount); // ”станавливаем новую ширину панели
        if (timeRemaining <= 0f)
        {
            if (timerSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(timerSound); // Play the timer sound if assigned
            }
            currentQuestionIndex++;
            SetNextQuestion(); // Time's up, treat it as an unanswered question
        }
    }
}
//public class QuizManager : MonoBehaviour
//{
//public TMPro.TextMeshProUGUI questionText;
//public TMPro.TextMeshProUGUI scoreText;
//public Button[] answerButtons;
//public QuizData quizData; 

//private List<QuestionData> questions;
//private int currentQuestionIndex;
//private int score;
//public GameObject EndScreen;
//public GameObject QuizScreen;

//public void StartQuiz()
//{
//    currentQuestionIndex = 0;
//    score = 0;
//    LoadQuestions();
//    SetNextQuestion();
//}
//void LoadQuestions()
//{
//    questions = new List<QuestionData>(quizData.questions);
//}

//void SetNextQuestion()
//{
//    Debug.Log(currentQuestionIndex);
//    if (currentQuestionIndex < questions.Count)
//    {
//        QuestionData question = questions[currentQuestionIndex];
//        questionText.text = question.question;

//        for (int i = 0; i < answerButtons.Length; i++)
//        {
//            answerButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = question.answers[i];
//        }
//    }
//    else
//    {
//        // ¬икторина завершена
//        UpdateScoreText();
//        EndScreen.SetActive(true);
//        QuizScreen.SetActive(false);

//    }
//}

//public void AnswerButtonClick(int answerIndex)
//{
//    Debug.Log("Anser Click");
//    Debug.Log("answerIndex");
//    QuestionData question = questions[currentQuestionIndex];
//    Debug.Log(question.correctAnswerIndex);
//    if (question.correctAnswerIndex == answerIndex)
//    {
//        Debug.Log("scored");
//        // ѕравильный ответ
//        score++;
//    }

//    currentQuestionIndex++;
//    SetNextQuestion();
//}

//void UpdateScoreText()
//{
//    scoreText.text = score+"из "+ questions.Count;
//}
//}