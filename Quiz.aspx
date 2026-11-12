<%@ Page Title="Smart Online Quiz" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Quiz.aspx.cs"
    Inherits="SmartOnlineQuiz2.Quiz" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .quiz-page {
            min-height: 75vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .quiz-card {
            width: 700px;
            padding: 40px;
            background: white;
            border-radius: 20px;
            box-shadow: 0 10px 30px rgba(0,0,0,0.15);
        }

        .quiz-heading {
            text-align: center;
            font-size: 32px;
            font-weight: bold;
            margin-bottom: 10px;
        }

        .quiz-info {
            text-align: center;
            color: #666;
            font-size: 18px;
            margin-bottom: 25px;
        }

        .question {
            display: block;
            font-size: 22px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .options {
            font-size: 19px;
            line-height: 2;
        }

        .button-area {
            text-align: center;
            margin-top: 30px;
        }

        .quiz-button {
            padding: 12px 35px;
            font-size: 18px;
            font-weight: bold;
            color: white;
            background: #2563eb;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            margin: 5px;
        }

        .quiz-button:hover {
            background: #1d4ed8;
        }

        .submit-button {
            background: #16a34a;
        }

        .submit-button:hover {
            background: #15803d;
        }

        .result-box {
            text-align: center;
            margin-top: 30px;
            padding: 25px;
            background: #f8fafc;
            border-radius: 15px;
            font-size: 22px;
            font-weight: bold;
            line-height: 1.8;
        }
    </style>

    <div class="quiz-page">

        <div class="quiz-card">

            <div class="quiz-heading">
                Smart Online Quiz
            </div>

            <div class="quiz-info">
                General Knowledge Quiz
            </div>

            <hr />

            <br />

            <asp:Label
                ID="lblQuestion"
                runat="server"
                CssClass="question">
            </asp:Label>

            <asp:RadioButtonList
                ID="rblOptions"
                runat="server"
                CssClass="options">
            </asp:RadioButtonList>

            <div class="button-area">

                <asp:Button
                    ID="btnNext"
                    runat="server"
                    Text="Next Question"
                    CssClass="quiz-button"
                    OnClick="btnNext_Click" />

                <asp:Button
                    ID="btnSubmit"
                    runat="server"
                    Text="Submit Quiz"
                    CssClass="quiz-button submit-button"
                    OnClick="btnSubmit_Click"
                    Visible="false" />

            </div>

            <asp:Label
                ID="lblResult"
                runat="server">
            </asp:Label>

        </div>

    </div>

</asp:Content>
