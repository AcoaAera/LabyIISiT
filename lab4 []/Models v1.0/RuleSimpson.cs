using System.Collections.Generic;

namespace Models_v1._0
{
    class RuleSimpson:Basic
    {
        int[] data;
        List<Pair> pairs;//все возможн-е пары

        public string NameRule { get; set; }

        public struct Pair
        {
            public int one, two, value;//первое значение пары, второе, кол-во голосов за данну пару

            public Pair(int one, int two, int value)
            {
                this.one = one;
                this.two = two;
                this.value = value;
            }
        }

        public RuleSimpson(List<User> noRepeatPreference, List<int> countVotesPreference, int countVar)
        {
            this.noRepeatPreference = noRepeatPreference;
            this.countVotesPreference = countVotesPreference;
            this.countVar = countVar;
            pairs = new List<Pair>();

            NameRule = "Правило Симпсона";
        }

        public int IndWinner()//ответ
        {
            AllPairs();
            CountVotesPairs();

            //WriteData(data, this.NameRule);
            return MinPairs();
        }

        private void AllPairs()//формирование списка всех пар. Для 4-ч их 12
        {
            for (int i = 0; i < countVar; i++)
            {
                for (int j = 0; j < countVar; j++)
                {
                    if (i != j)
                        pairs.Add(new Pair(i, j, 0));
                }
            }
        }

        private void CountVotesPairs()//кол-во голосов, отданных за каждую пар
        {
            for (int i = 0; i < pairs.Count; i++)
            {
                int summ = 0;
                for (int k = 0; k < noRepeatPreference.Count; k++)
                {
                    int iOne, iTwo;
                    iOne = iTwo = 0;
                    for (int j = 0; j < noRepeatPreference[k].GetPreferences.Count; j++)
                    {
                        if (noRepeatPreference[k].GetPreferences[j] == pairs[i].one + 1)
                            iOne = j;
                        if (noRepeatPreference[k].GetPreferences[j] == pairs[i].two + 1)
                            iTwo = j;
                    }
                    if (iOne < iTwo)
                        summ += countVotesPreference[k];
                }
                pairs[i] = new Pair(pairs[i].one, pairs[i].two, summ);
            }
        }

        private int MinPairs()//выбираем минимальные пары для каждого из вариантов
        {
            List<Pair> result = new List<Pair>();

            for (int i = 0; i < countVar; i++)
            {
                List<Pair> p = new List<Pair>();
                foreach (Pair pair in pairs)
                {
                    if (i == pair.one)
                        p.Add(pair);
                }

                Pair min = p[0];
                for (int j = 0; j < p.Count; j++)
                {
                    if (p[j].value < min.value)
                        min = p[j];
                }
                result.Add(min);
            }

            data = new int[result.Count];
            for (int i = 0; i < result.Count; i++)
                data[i] = result[i].value;

            WriteData(data, this.NameRule);

            return iMax(data);
        }
    }
}