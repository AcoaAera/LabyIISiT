using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Models_v1._0
{
    public partial class Form1 : Form
    {
        List<string> variants;//варианты ответов
        List<User> users;//список голосующих, по сути, список всех предпочтений
        int currentUser;//номер пользователя, кот-й отвечает в данный момент
        List<int> votes;
        List<User> preference;

        public Form1()
        {
            InitializeComponent();

            variants = new List<string> { "МГУ", "ПГУ", "ПНИПУ", "ТГУ" };
            users = new List<User>();
            votes = new List<int>();
            preference = new List<User>();

            select.Enabled = false;
            clearAnswers.Enabled = false;
            vote.Enabled = false;
            textBox1.ReadOnly = true;

            Fill();
        }

        private void Fill()//заполняем listBox1 вариантами ответов
        {
            foreach (string var in variants)
                variantsAnswers.Items.Add(var);
        }

        private void CurrentUser(int value)//показываем, кто на данный момент голосует
        {
            label3.Text = (value + 1).ToString();
        }

        private void ViewWinner()//выводим ответ по каждой из моделей
        {
            RuleMajority majority = new RuleMajority(variants.Count, users);
            MessageBox.Show("Победитель: " + variants[majority.IndWinner()], majority.NameRule);

            RuleCondorcet condorcet = new RuleCondorcet(variants.Count, users);
            votes = condorcet.GetVotes;
            preference = condorcet.GetPreferences;
            int iWin = condorcet.IndWinner();
            if (iWin != -1)
                MessageBox.Show("Победитель: " + variants[iWin], condorcet.NameRuleCondorcet);
            else
                MessageBox.Show("Парадокс", condorcet.NameRuleCondorcet);

            MessageBox.Show("Победитель: " + variants[condorcet.Coplend()], condorcet.NameRuleCoplend);

            MessageBox.Show("Победитель: " + variants[condorcet.Simpson()], condorcet.NameRuleSimpson);

            RuleBorda borda = new RuleBorda(variants.Count, users);
            MessageBox.Show("Победитель: " + variants[borda.IndWinner()], borda.NameRule);
        }

        private void Clear()//когда голосвание закончено, приводим к первонач-му виду
        {
            select.Enabled = false;
            clearAnswers.Enabled = false;
            vote.Enabled = false;
            countUsers.Enabled = true;
            countUsers.Text = string.Empty;
            ok.Enabled = true;
            label3.Text = string.Empty;

            users.Clear();
        }

        private void button1_Click(object sender, EventArgs e)//выбрать один из вариантов
        {
            int iSelect = variantsAnswers.SelectedIndex;

            if (iSelect != -1 && !preferencesUsers.Items.Contains(variants[iSelect]))
                preferencesUsers.Items.Add(variants[iSelect]);
        }

        private void button2_Click(object sender, EventArgs e)//очистить список предпочтений
        {
            preferencesUsers.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)//задать кол-во голосующих
        {
            if (countUsers.Text != string.Empty)
            {
                int count = Convert.ToInt32(countUsers.Text);
                if (count > 0)
                {
                    votes.Clear();
                    preference.Clear();
                    textBox1.Clear();

                    select.Enabled = true;
                    clearAnswers.Enabled = true;
                    vote.Enabled = true;
                    countUsers.Enabled = false;
                    ok.Enabled = false;

                    for (int i = 0; i < count; i++)
                        users.Add(new User());

                    currentUser = 0;
                    CurrentUser(currentUser);
                }
                else
                    MessageBox.Show("Кол-во избирателей должно быть > 0", "Внимание");
            }
            else
                MessageBox.Show("Поле не должно быть пустым", "Внимание");
        }

        private void button4_Click(object sender, EventArgs e)//голосовать
        {
            if (preferencesUsers.Items.Count != 0)
            {
                for (int i = 0; i < preferencesUsers.Items.Count; i++)
                {
                    string preference = preferencesUsers.Items[i].ToString();
                    users[currentUser].AddPreference(variants.FindIndex(x => x == preference) + 1);
                }
                preferencesUsers.Items.Clear();
                if (++currentUser == users.Count)
                {
                    ViewWinner();
                    Clear();
                    FillProfile();
                }
                else
                    //label3.Text = (currentUser + 1).ToString();
                    CurrentUser(currentUser);
            }
            else
                MessageBox.Show("Выберите один из вариантов", "Внимание");
            #region вики
            //for (int i = 0; i < 23; i++)
            //{
            //    users[i].AddPreference(1);
            //    users[i].AddPreference(3);
            //    users[i].AddPreference(2);
            //}
            //for (int i = 0; i < 19; i++)
            //{
            //    users[23 + i].AddPreference(2);
            //    users[23 + i].AddPreference(3);
            //    users[23 + i].AddPreference(1);
            //}
            //for (int i = 0; i < 16; i++)
            //{
            //    users[23 + 19 + i].AddPreference(3);
            //    users[23 + 19 + i].AddPreference(2);
            //    users[23 + 19 + i].AddPreference(1);
            //}
            //for (int i = 0; i < 2; i++)
            //{
            //    users[23 + 19 + i + 16].AddPreference(3);
            //    users[23 + 19 + i + 16].AddPreference(1);
            //    users[23 + 19 + i + 16].AddPreference(2);
            //}
            //ViewWinner();
            #endregion
        }

        private void FillProfile()
        {
            for (int i = 0; i < votes.Count; i++)
            {
                string s = votes[i].ToString() + "   " + GetStringPreference(preference[i]);
                textBox1.Text += s + "\r\n";
            }
        }

        private string GetStringPreference(User user)
        {
            string s = string.Empty;

            foreach (int p in user.GetPreferences)
                s += variants[p - 1] + " ";

            return s;
        }
    }
}