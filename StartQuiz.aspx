<%@ Page Title="Smart Online Quiz" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="StartQuiz.aspx.cs"
    Inherits="SmartOnlineQuiz2.StartQuiz" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .quiz-container {
            min-height: 75vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .quiz-card {
            width: 600px;
            padding: 45px;
            text-align: center;
            background: white;
            border-radius: 20px;
            box-shadow: 0 10px 30px rgba(0,0,0,0.15);
        }

        .quiz-title {
            font-size: 38px;
            font-weight: bold;
            margin-bottom: 10px;
        }

        .quiz-subtitle {
            font-size: 18px;
            color: #666;
            margin-bottom: 30px;
        }

        .input-box {
            width: 80%;
            padding: 12px;
            margin: 8px 0;
            border: 1px solid #ccc;
            border-radius: 8px;
            font-size: 16px;
        }

        .start-button {
            background: #2563eb;
            color: white;
            border: none;
            padding: 15px 50px;
            font-size: 20px;
            font-weight: bold;
            border-radius: 10px;
            cursor: pointer;
            margin-top: 20px;
        }

        .start-button:hover {
            background: #1d4ed8;
        }

        .ai-button {
            background: #7c3aed;
        }

        .ai-button:hover {
            background: #6d28d9;
        }
    </style>

    <div class="quiz-container">

        <div class="quiz-card">

            <div class="quiz-title">
                Smart Online Quiz
            </div>

            <div class="quiz-subtitle">
                All the best! Test your General Knowledge.
            </div>

            <hr />

            <br />

            <asp:TextBox
                ID="txtName"
                runat="server"
                CssClass="input-box"
                placeholder="Enter your name">
            </asp:TextBox>

            <br />

            <asp:TextBox
                ID="txtClass"
                runat="server"
                CssClass="input-box"
                placeholder="Enter your class">
            </asp:TextBox>

            <br />

            <asp:TextBox
                ID="txtRollNo"
                runat="server"
                CssClass="input-box"
                placeholder="Enter your roll number">
            </asp:TextBox>

            <br />

            <asp:Button
                ID="btnStartQuiz"
                runat="server"
                Text="START QUIZ"
                CssClass="start-button"
                OnClick="btnStartQuiz_Click" />

            <br />

            <asp:Button
                ID="btnAIQuiz"
                runat="server"
                Text="AI QUIZ"
                CssClass="start-button ai-button"
                OnClick="btnAIQuiz_Click" />

        </div>

    </div>

</asp:Content>