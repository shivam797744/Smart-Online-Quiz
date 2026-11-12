using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

namespace SmartOnlineQuiz2
{
    public partial class AIQuiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlQuiz.Visible = false;
                lblAIScore.Text = "";
                btnNewQuiz.Visible = false;
            }
        }


        // ==========================================
        // GENERATE AI QUESTIONS
        // ==========================================

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string topic = txtTopic.Text.Trim();
            string numberText = txtNumber.Text.Trim();

            if (topic == "")
            {
                lblAIScore.Text = "Please enter a topic.";
                return;
            }

            int number;

            if (!int.TryParse(numberText, out number))
            {
                lblAIScore.Text = "Please enter a valid number.";
                return;
            }

            if (number < 1 || number > 10)
            {
                lblAIScore.Text =
                    "Please enter a number between 1 and 10.";

                return;
            }


            string prompt =
                "Create " + number +
                " multiple choice quiz questions about " +
                topic + ". " +

                "Return ONLY JSON. " +

                "The JSON must have this structure: " +

                "{\"questions\":[" +

                "{\"QuestionText\":\"question\"," +
                "\"OptionA\":\"option A\"," +
                "\"OptionB\":\"option B\"," +
                "\"OptionC\":\"option C\"," +
                "\"OptionD\":\"option D\"," +
                "\"CorrectAnswer\":\"A\"}" +

                "]} " +

                "CorrectAnswer must be A, B, C or D. " +

                "Do not include explanations. " +
                "Do not include markdown. " +
                "Do not show the correct answer to the user.";


            try
            {
                JavaScriptSerializer serializer =
                    new JavaScriptSerializer();

                Dictionary<string, object> requestData =
                    new Dictionary<string, object>();

                requestData["model"] = "llama3.2:3b";
                requestData["prompt"] = prompt;
                requestData["stream"] = false;
                requestData["format"] = "json";


                string jsonRequest =
                    serializer.Serialize(requestData);


                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] =
                        "application/json";


                    string response =
                        client.UploadString(
                            "http://localhost:11434/api/generate",
                            "POST",
                            jsonRequest);


                    Dictionary<string, object> ollamaResult =
                        serializer.Deserialize<
                            Dictionary<string, object>>(response);


                    if (!ollamaResult.ContainsKey("response"))
                    {
                        lblAIScore.Text =
                            "AI did not return a response.";

                        return;
                    }


                    string aiResponse =
                        ollamaResult["response"].ToString();


                    // Read the JSON returned by AI
                    Dictionary<string, object> quizData =
                        serializer.Deserialize<
                            Dictionary<string, object>>(aiResponse);


                    if (!quizData.ContainsKey("questions"))
                    {
                        lblAIScore.Text =
                            "AI response does not contain questions.";

                        return;
                    }


                    // JavaScriptSerializer returns JSON arrays
                    // as ArrayList
                    ArrayList questionList =
                        quizData["questions"] as ArrayList;


                    if (questionList == null ||
                        questionList.Count == 0)
                    {
                        lblAIScore.Text =
                            "No questions were generated.";

                        return;
                    }


                    List<Question> questions =
                        new List<Question>();


                    foreach (object item in questionList)
                    {
                        Dictionary<string, object> data =
                            item as Dictionary<string, object>;


                        if (data == null)
                        {
                            continue;
                        }


                        Question question =
                            new Question();


                        question.QuestionText =
                            GetValue(data, "QuestionText");


                        question.OptionA =
                            GetValue(data, "OptionA");


                        question.OptionB =
                            GetValue(data, "OptionB");


                        question.OptionC =
                            GetValue(data, "OptionC");


                        question.OptionD =
                            GetValue(data, "OptionD");


                        question.CorrectAnswer =
                            GetValue(data, "CorrectAnswer")
                            .Trim()
                            .ToUpper();


                        // Make sure answer is A/B/C/D
                        if (question.CorrectAnswer == "A" ||
                            question.CorrectAnswer == "B" ||
                            question.CorrectAnswer == "C" ||
                            question.CorrectAnswer == "D")
                        {
                            questions.Add(question);
                        }
                    }


                    if (questions.Count == 0)
                    {
                        lblAIScore.Text =
                            "AI questions could not be read correctly.";

                        return;
                    }


                    // Store questions in Session
                    Session["AIQuestions"] = questions;

                    // Start from first question
                    Session["AIQuestionIndex"] = 0;

                    // Start score from zero
                    Session["AIScore"] = 0;


                    // Hide generator
                    pnlGenerator.Visible = false;

                    // Show quiz
                    pnlQuiz.Visible = true;

                    lblAIScore.Text = "";

                    btnNewQuiz.Visible = false;


                    DisplayAIQuestion();
                }
            }
            catch (Exception ex)
            {
                lblAIScore.Text =
                    "AI Error: " +
                    Server.HtmlEncode(ex.Message);
            }
        }


        // ==========================================
        // GET JSON VALUE
        // ==========================================

        private string GetValue(
            Dictionary<string, object> data,
            string key)
        {
            if (data.ContainsKey(key) &&
                data[key] != null)
            {
                return data[key].ToString();
            }

            return "";
        }


        // ==========================================
        // DISPLAY QUESTION
        // ==========================================

        private void DisplayAIQuestion()
        {
            List<Question> questions =
                Session["AIQuestions"]
                as List<Question>;


            if (questions == null ||
                questions.Count == 0)
            {
                return;
            }


            int index =
                Convert.ToInt32(
                    Session["AIQuestionIndex"]);


            if (index >= questions.Count)
            {
                return;
            }


            Question question =
                questions[index];


            lblQuestionNumber.Text =
                "Question " +
                (index + 1) +
                " of " +
                questions.Count;


            lblAIQuestion.Text =
                question.QuestionText;


            rblAIOptions.Items.Clear();


            rblAIOptions.Items.Add(
                new ListItem(
                    "A) " + question.OptionA,
                    "A"));


            rblAIOptions.Items.Add(
                new ListItem(
                    "B) " + question.OptionB,
                    "B"));


            rblAIOptions.Items.Add(
                new ListItem(
                    "C) " + question.OptionC,
                    "C"));


            rblAIOptions.Items.Add(
                new ListItem(
                    "D) " + question.OptionD,
                    "D"));


            rblAIOptions.ClearSelection();


            // Last question
            if (index == questions.Count - 1)
            {
                btnAINext.Visible = false;
                btnAISubmit.Visible = true;
            }
            else
            {
                btnAINext.Visible = true;
                btnAISubmit.Visible = false;
            }
        }


        // ==========================================
        // NEXT QUESTION
        // ==========================================

        protected void btnAINext_Click(
            object sender,
            EventArgs e)
        {
            if (rblAIOptions.SelectedItem == null)
            {
                lblAIScore.Text =
                    "Please select an answer.";

                return;
            }


            CheckCurrentAnswer();


            int index =
                Convert.ToInt32(
                    Session["AIQuestionIndex"]);


            index++;


            Session["AIQuestionIndex"] =
                index;


            lblAIScore.Text = "";


            DisplayAIQuestion();
        }


        // ==========================================
        // SUBMIT AI QUIZ
        // ==========================================

        protected void btnAISubmit_Click(
            object sender,
            EventArgs e)
        {
            if (rblAIOptions.SelectedItem == null)
            {
                lblAIScore.Text =
                    "Please select an answer.";

                return;
            }


            CheckCurrentAnswer();


            int score =
                Convert.ToInt32(
                    Session["AIScore"]);


            List<Question> questions =
                Session["AIQuestions"]
                as List<Question>;


            int total =
                questions.Count;


            pnlQuiz.Visible = false;


            lblAIScore.Text =
                "<div class='result-box'>" +
                "AI Quiz Completed!<br/><br/>" +
                "Your Score: " +
                score +
                " / " +
                total +
                "</div>";


            btnNewQuiz.Visible = true;
        }


        // ==========================================
        // CHECK ANSWER
        // ==========================================

        private void CheckCurrentAnswer()
        {
            List<Question> questions =
                Session["AIQuestions"]
                as List<Question>;


            if (questions == null)
            {
                return;
            }


            int index =
                Convert.ToInt32(
                    Session["AIQuestionIndex"]);


            Question question =
                questions[index];


            string selectedAnswer =
                rblAIOptions.SelectedValue;


            if (question.CheckAnswer(
                selectedAnswer))
            {
                int score =
                    Convert.ToInt32(
                        Session["AIScore"]);


                score++;


                Session["AIScore"] =
                    score;
            }
        }


        // ==========================================
        // NEW AI QUIZ
        // ==========================================

        protected void btnNewQuiz_Click(
            object sender,
            EventArgs e)
        {
            Session.Remove("AIQuestions");
            Session.Remove("AIQuestionIndex");
            Session.Remove("AIScore");


            pnlGenerator.Visible = true;
            pnlQuiz.Visible = false;


            lblAIScore.Text = "";


            btnNewQuiz.Visible = false;
        }


        // ==========================================
        // BACK TO START
        // ==========================================

        protected void btnBack_Click(
            object sender,
            EventArgs e)
        {
            Response.Redirect("StartQuiz.aspx");
        }
    }
}