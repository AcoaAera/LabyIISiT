using System.Collections.Generic;

namespace Models_v1._0
{
    class RuleBorda:Basic
    {
        List<int> points;//очки за 1-е, 2-е и другие места
        int[] summPoints;//кол-ва очков для каждого варианта ответа

        public string NameRule { get; set; }

        public RuleBorda(int countVar, List<User> users)
        {
            this.countVar = countVar;
            this.users = users;

            noRepeatPreference = new List<User>();
            countVotesPreference = new List<int>();
            points = new List<int>();

            summPoints = new int[countVar];
            NameRule = "Правило Борда";
        }

        public int IndWinner()
        {
            NoRepetPreference();
            //CountVotesPreference();
            CalcSummPoints();

            WriteData(summPoints, this.NameRule);
            return iMax(summPoints);
        }

        private void CalcSummPoints()//подсчет суммы баллов для каждоый варинта ответа
        {
            int first = countVar; // 10;

            for (int i = 0; i < countVar; i++)
                points.Add(first - i);

            for (int i = 0; i < countVar; i++)
            {
                int summ = 0;

                for (int j = 0; j < countVotesPreference.Count; j++)
                {
                    //какое место занимает данная гипотеза среди данного предпочтения
                    int iPref = noRepeatPreference[j].GetPreferences.FindIndex(y => y == (i + 1));
                    summ += countVotesPreference[j] * points[iPref];
                }

                summPoints[i] = summ;
            }
        }
    }
}