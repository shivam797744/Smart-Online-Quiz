using System;
using System.Collections.Generic;

namespace SmartOnlineQuiz2
{
    // Delegate
    public delegate void QuizCompletedHandler(int score);

    public class QuizManager
    {
        public List<Question> Questions { get; set; }

        public int Score { get; private set; }

        // Event
        public event QuizCompletedHandler QuizCompleted;

        public QuizManager()
        {
            Questions = new List<Question>();
            Score = 0;
        }

        // Method
        public void AddQuestion(Question question)
        {
            Questions.Add(question);
        }

        // Method
        public bool CheckAnswer(int questionNumber, string answer)
        {
            if (Questions[questionNumber].CheckAnswer(answer))
            {
                Score++;
                return true;
            }

            return false;
        }

        // Method
        public int GetScore()
        {
            return Score;
        }

        // Method
        public int GetTotalQuestions()
        {
            return Questions.Count;
        }

        // Method to trigger Event
        public void CompleteQuiz()
        {
            if (QuizCompleted != null)
            {
                QuizCompleted(Score);
            }
        }
    }
}