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
    // public VisibilityController visibilityController;

    //void Start()
    //{
    //    LoadQuestions(); // �������� �������� �� QuizData
    //    SetNextQuestion(); // ����� ������� �������
    //}
    public void StartQuiz()
    {
        currentQuestionIndex = 0;
        score = 0;
        LoadQuestions();
        SetNextQuestion();
    }
    void LoadQuestions()
    {
        questions = new List<QuestionData>(quizData.questions);
    }

    void SetNextQuestion()
    {
        Debug.Log(currentQuestionIndex);
        if (currentQuestionIndex < questions.Count)
        {
            QuestionData question = questions[currentQuestionIndex];
            questionText.text = question.question;

            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = question.answers[i];
            }
        }
        else
        {
            // ��������� ���������
            UpdateScoreText();
            EndScreen.SetActive(true);
            QuizScreen.SetActive(false);

        }
    }

    public void AnswerButtonClick(int answerIndex)
    {
        Debug.Log("Anser Click");
        Debug.Log("answerIndex");
        QuestionData question = questions[currentQuestionIndex];
        Debug.Log(question.correctAnswerIndex);
        if (question.correctAnswerIndex == answerIndex)
        {
            Debug.Log("scored");
            // ���������� �����
            score++;
        }

        currentQuestionIndex++;
        SetNextQuestion();
    }

    void UpdateScoreText()
    {
        scoreText.text = score+"�� "+ questions.Count;
    }
}