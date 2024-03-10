using UnityEngine;

[System.Serializable]
public class QuestionData
{
    public string question;
    public string[] answers;
    public int correctAnswerIndex;
}

[CreateAssetMenu(fileName = "QuizData", menuName = "Quiz/Quiz Data", order = 1)]
public class QuizData : ScriptableObject
{
    public QuestionData[] questions;
}