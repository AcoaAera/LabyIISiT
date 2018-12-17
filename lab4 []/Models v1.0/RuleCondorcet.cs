using System.Collections.Generic;
using System.Linq;

namespace Models_v1._0
{
    class RuleCondorcet:Basic
    {
        List<Pair> pairs;//все возможнные варинты пар
        List<Pair> resultPairs;//пары, из которых делаем вывод

        RuleSimpson simpson;

        public string NameRuleCondorcet { get; set; }
        public string NameRuleCoplend { get; set; }
        public string NameRuleSimpson;

        public struct Pair
        {
            public int one, two;

            public Pair(int one, int two)
            {
                this.one = one;
                this.two = two;
            }
        }

        public RuleCondorcet(int countVar, List<User> users)
        {
            this.users = users;
            noRepeatPreference = new List<User>();
            countVotesPreference = new List<int>();
            pairs = new List<Pair>();
            resultPairs = new List<Pair>();
            this.countVar = countVar;
            countVotesVariants = new int[countVar];

            simpson = new RuleSimpson(noRepeatPreference, countVotesPreference, countVar);

            NameRuleCondorcet = "Правило Кондорсе";
            NameRuleCoplend = "Правило Копленда";
            NameRuleSimpson = simpson.NameRule;
        }

        public int IndWinner()
        {
            NoRepetPreference();
            //CountVotesPreference();
            AllPair();
            FindResultPairs();
            return iMax();
        }

        private void AllPair()//формирование возможных пар, например: a,b  a,c  b,c
        {
            for (int i = 0; i < countVar; i++)
            {
                for (int j = 0; j < countVar; j++)
                {
                    Pair pair = new Pair(i, j);
                    if (i != j && !FindPair(pair))
                        pairs.Add(pair);
                }
            }
        }

        private bool FindPair(Pair pair)//проверяем, есть такая пара уже в списке
        {
            bool check = false;

            foreach (Pair p in pairs)
            {
                if (p.one == pair.one && p.two == pair.two ||
                    p.two == pair.one && p.one == pair.two)
                {
                    check = true;
                    break;
                }
            }

            return check;
        }

        private void FindResultPairs()//ойййййййййййййййййййй
        {
            foreach (Pair pair in pairs)
            {
                int maxOne, maxTwo, fillVotes;
                maxOne = maxTwo = fillVotes = 0;

                int one, two, iOne, iTwo;
                iOne = iTwo = 0;

                one = pair.one + 1;
                two = pair.two + 1;

                for (int i = 0; i < noRepeatPreference.Count; i++)
                {
                    for (int j = 0; j < noRepeatPreference[i].GetPreferences.Count; j++)
                    {
                        if (noRepeatPreference[i].GetPreferences[j] == one)
                            iOne = j;
                        if (noRepeatPreference[i].GetPreferences[j] == two)
                            iTwo = j;
                    }
                    if (iOne < iTwo)
                        maxOne += countVotesPreference[i];
                }
                for (int z = 0; z < countVotesPreference.Count; z++)
                    fillVotes += countVotesPreference[z];
                maxTwo = fillVotes - maxOne;

                if (maxOne > maxTwo)
                    resultPairs.Add(new Pair(pair.one, pair.two));
                else
                    resultPairs.Add(new Pair(pair.two, pair.one));
            }
        }

        private int iMax()//получаем ответ
        {
            for (int i = 0; i < countVar; i++)//подсчет кол-ва голосов
                foreach (Pair pair in resultPairs)
                    if (pair.one == i)
                        countVotesVariants[i]++;

            int max = countVotesVariants.Max();
            int countMax = 0;

            WriteData(countVotesVariants, NameRuleCondorcet);

            foreach (int num in countVotesVariants)//есть ли парадокс
            {
                if (num == max)
                    countMax++;
            }
            if (countMax > 1)
                return -1;
            else
                return iMax(countVotesVariants);//если нет, то есть явный победитель
        }

        public int Simpson()//метод Симпсона
        {
            return simpson.IndWinner();
        }

        public int Coplend()//метод Копленда
        {
            int[] coplend = new int[countVar];

            for (int i = 0; i < countVar; i++)
                coplend[i] = countVotesVariants[i] - ((countVar - 1) - countVotesVariants[i]);

            WriteData(coplend, NameRuleCoplend);

            return iMax(coplend);
        }

        public List<int> GetVotes
        {
            get { return countVotesPreference; }
        }

        public List<User> GetPreferences
        {
            get { return noRepeatPreference; }
        }
    }
}