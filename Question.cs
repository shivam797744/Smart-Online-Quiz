using System;

namespace SmartOnlineQuiz2
{
    public class Question
    {
        public string QuestionText { get; set; }

        public string OptionA { get; set; }

        public string OptionB { get; set; }

        public string OptionC { get; set; }

        public string OptionD { get; set; }

        public string CorrectAnswer { get; set; }

        public bool CheckAnswer(string answer)
        {
            return answer == CorrectAnswer;
        }
    }
}