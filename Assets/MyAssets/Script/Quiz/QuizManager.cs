using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
public class QuizManager : MonoBehaviour
{
    public Text questionText;
    public Text scoreText;
    public Button[] answerButtons;
    public QuizData quizData; // Ссылка на ваш объект QuizData

    private List<QuestionData> questions;
    private int currentQuestionIndex;
    private int score;

    void Start()
    {
        LoadQuestions(); // Загрузка вопросов из QuizData
        SetNextQuestion(); // Показ первого вопроса
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
                answerButtons[i].GetComponentInChildren<Text>().text = question.answers[i];
            }
        }
        else
        {
            // Викторина завершена
            questionText.text = "Викторина завершена!";
        }
    }

    public void AnswerButtonClick(int answerIndex)
    {
        QuestionData question = questions[currentQuestionIndex];
        if (question.correctAnswerIndex == answerIndex)
        {
            // Правильный ответ
            score++;
        }

        currentQuestionIndex++;
        SetNextQuestion();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Счет: " + score;
    }
}