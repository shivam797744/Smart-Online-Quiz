<%@ Page Title="AI Quiz" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="AIQuiz.aspx.cs"
    Inherits="SmartOnlineQuiz2.AIQuiz" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>

        .ai-page {
            min-height: 75vh;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .ai-card {
            width: 700px;
            padding: 40px;
            background: white;
            border-radius: 20px;
            box-shadow: 0 10px 30px rgba(0,0,0,0.15);
        }

        .ai-title {
            text-align: center;
            font-size: 32px;
            font-weight: bold;
            margin-bottom: 10px;
        }

        .ai-subtitle {
            text-align: center;
            color: #666;
            font-size: 18px;
            margin-bottom: 30px;
        }

        .input-label {
            display: block;
            font-size: 18px;
            font-weight: bold;
            margin-top: 15px;
            margin-bottom: 8px;
        }

        .input-box {
            width: 100%;
            padding: 12px;
            border: 1px solid #ccc;
            border-radius: 8px;
            font-size: 16px;
            box-sizing: border-box;
        }

        .generate-button {
            display: block;
            margin: 25px auto;
            padding: 13px 35px;
            background: #2563eb;
            color: white;
            border: none;
            border-radius: 8px;
            font-size: 18px;
            font-weight: bold;
            cursor: pointer;
        }

        .generate-button:hover {
            background: #1d4ed8;
        }

        .question-number {
            display: block;
            text-align: center;
            font-size: 17px;
            color: #666;
            margin-top: 25px;
        }

        .question {
            display: block;
            font-size: 22px;
            font-weight: bold;
            margin-top: 20px;
            margin-bottom: 20px;
        }

        .options {
            font-size: 18px;
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

        .submit-button {
            background: #16a34a;
        }

        .back-button {
            background: #6b7280;
        }

        .result-box {
            display: block;
            text-align: center;
            margin-top: 30px;
            padding: 25px;
            background: #f8fafc;
            border-radius: 15px;
            font-size: 24px;
            font-weight: bold;
            line-height: 1.8;
        }

    </style>


    <div class="ai-page">

        <div class="ai-card">

            <div class="ai-title">
                AI Quiz Generator
            </div>

            <div class="ai-subtitle">
                Generate and attempt quiz questions using AI
            </div>

            <hr />

            <asp:Panel ID="pnlGenerator" runat="server">

                <label class="input-label">
                    Enter Topic
                </label>

                <asp:TextBox
                    ID="txtTopic"
                    runat="server"
                    CssClass="input-box"
                    placeholder="Example: Programming">
                </asp:TextBox>


                <label class="input-label">
                    Number of Questions
                </label>

                <asp:TextBox
                    ID="txtNumber"
                    runat="server"
                    CssClass="input-box"
                    Text="5">
                </asp:TextBox>


                <asp:Button
                    ID="btnGenerate"
                    runat="server"
                    Text="GENERATE QUESTIONS"
                    CssClass="generate-button"
                    OnClick="btnGenerate_Click" />

            </asp:Panel>


            <asp:Panel
                ID="pnlQuiz"
                runat="server"
                Visible="false">

                <asp:Label
                    ID="lblQuestionNumber"
                    runat="server"
                    CssClass="question-number">
                </asp:Label>


                <asp:Label
                    ID="lblAIQuestion"
                    runat="server"
                    CssClass="question">
                </asp:Label>


                <asp:RadioButtonList
                    ID="rblAIOptions"
                    runat="server"
                    CssClass="options">
                </asp:RadioButtonList>


                <div class="button-area">

                    <asp:Button
                        ID="btnAINext"
                        runat="server"
                        Text="Next Question"
                        CssClass="quiz-button"
                        OnClick="btnAINext_Click" />


                    <asp:Button
                        ID="btnAISubmit"
                        runat="server"
                        Text="Submit AI Quiz"
                        CssClass="quiz-button submit-button"
                        OnClick="btnAISubmit_Click"
                        Visible="false" />

                </div>

            </asp:Panel>


            <asp:Label
                ID="lblAIScore"
                runat="server"
                CssClass="result-box">
            </asp:Label>


            <div class="button-area">

                <asp:Button
                    ID="btnNewQuiz"
                    runat="server"
                    Text="Generate New AI Quiz"
                    CssClass="quiz-button"
                    OnClick="btnNewQuiz_Click"
                    Visible="false" />


                <asp:Button
                    ID="btnBack"
                    runat="server"
                    Text="Back to Start"
                    CssClass="quiz-button back-button"
                    OnClick="btnBack_Click" />

            </div>

        </div>

    </div>

</asp:Content>
