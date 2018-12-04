using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tests_Project__Lab_1_
{
    public partial class Form1 : Form
    {
        private WorkMemory workMemory;
        private string currentFactName;
        private int clicksCount, askedQuestionCount;
        private List<string> validAnswersList;

        public Form1()
        {
            InitializeComponent();
            clicksCount = 0;
            askedQuestionCount = 0;
            currentFactName = null;
            workMemory = new WorkMemory();
            SystemOutputTB.TabStop = false; // убирает фокус с текстбокса 
            SystemOutputTB.Text = "Вас приветствует экспертная система по выбору ВУЗа. Отвечайте на вопросы согласно правилам системы, пока не получите рекомендацию системы.\r\n\r\n";
            UserAnswerBTN.Text = "Начать";
        }

        private void AnswerTheQuestion() // отправка ответа пользователя
        {
            string answerValue = UserAnswerTB.Text;

            foreach (string variant in validAnswersList)
            {
                if (variant == answerValue)
                {
                    SystemOutputTB.AppendText(" " + answerValue);
                    workMemory.ResponseProcessing(currentFactName, answerValue);
                    YesRB.Checked = NoRB.Checked = false;
                    SystemOutputTB.AppendText("\r\n\r\n");
                    UserAnswerTB.Focus();
                    UserAnswerTB.Clear();
                    return;
                }
            }

            UserAnswerTB.Clear();
            throw new Exception("Введите один из предложенных вариантов ответа.");
        }

        private void GetQuestion() // получение нового вопроса
        {
            // структура кортежа: 1 - текст вопроса, 2 - имя факта, которому соответствует текущий вопрос, 3 - список допустимых вариантов ответа
            Tuple<string, string, List<string>> result = workMemory.GetQuestionAndCurrentDefruleName();
            SystemOutputTB.AppendText(result.Item1);
            currentFactName = result.Item2;
            validAnswersList = result.Item3;
        }

        private void UserAnswerBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (++clicksCount == 1)
                {
                    UserAnswerBTN.Text = "Ответить";
                    UserAnswerTB.Enabled = true;
                }
                else
                {
                    if (UserAnswerTB.Text == string.Empty)
                        throw new Exception("Поле ввода не должно быть пустым.");

                    AnswerTheQuestion();
                    ++askedQuestionCount; // количество заданных вопросов для обработки случаев, когда система не может вывести ответ

                    #region Проверка условия прекращения работы системы

                    Tuple<string, bool> corteg = workMemory.DefrulesEnumeration();
                    bool isFinal = corteg.Item2; // булевая переменная, возвращающая содержание факта типа "университет" в РП

                    if (askedQuestionCount == workMemory.QuestionsCount)
                    {
                        SystemOutputTB.AppendText("Система не смогла выбрать ВУЗ, попробуйте еще раз.");
                        UserAnswerBTN.Enabled = false;
                        ExplanationComponentCallBtn.Enabled = true;
                        return;
                    }

                    if (isFinal)
                    {
                        SystemOutputTB.AppendText("Система советует поступать в " + corteg.Item1);
                        UserAnswerBTN.Enabled = false;
                        ExplanationComponentCallBtn.Enabled = true;
                        return;
                    }

                    #endregion
                }

                GetQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void YesRB_CheckedChanged(object sender, EventArgs e)
        {
            UserAnswerTB.Text = "да";
        }

        private void NoRB_CheckedChanged(object sender, EventArgs e)
        {
            UserAnswerTB.Text = "нет";
        }

        private void ExplanationComponentCallBtn_Click(object sender, EventArgs e)
        {
            string result = "Последовательность выведенных фактов: \r\n";

            foreach (var fact in workMemory.GetFactsList())
                result += "Имя факта: " + fact.Name + ", значение: " + fact.Value + "\r\n";

            MessageBox.Show(result);
        }

        private void SystemResetBTN_Click(object sender, EventArgs e)
        {
            clicksCount = 0;
            askedQuestionCount = 0;
            currentFactName = string.Empty;
            workMemory.Clear();
            SystemOutputTB.Text = "Вас приветствует экспертная система по выбору ВУЗа. Отвечайте на вопросы согласно правилам системы, пока не получите рекомендацию системы.\r\n\r\n";
            UserAnswerBTN.Text = "Начать";
            UserAnswerTB.Enabled = false;
            UserAnswerBTN.Enabled = true;
            ExplanationComponentCallBtn.Enabled = false;
            UserAnswerTB.Clear();
        }
    }
}
