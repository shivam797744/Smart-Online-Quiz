using System;

namespace SmartOnlineQuiz2
{
    public partial class StartQuiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnStartQuiz_Click(object sender, EventArgs e)
        {
            Session["Name"] = txtName.Text;
            Session["Class"] = txtClass.Text;
            Session["RollNo"] = txtRollNo.Text;

            Response.Redirect("Quiz.aspx");
        }

        protected void btnAIQuiz_Click(object sender, EventArgs e)
        {
            Response.Redirect("AIQuiz.aspx");
        }
    }
}