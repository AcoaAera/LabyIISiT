using System;
using System.Collections.Generic;

namespace Models_v1._0
{
    class RuleMajority:Basic
    {
        public string NameRule { get; set; }

        public RuleMajority(int countVar, List<User> users)
        {
            this.countVar = countVar;
            countVotesVariants = new int[countVar];
            this.users = users;
            NameRule = "Правило большинства";
        }

        public int IndWinner()
        {
            for (int i = 0; i < countVar; i++)//подсчёт кол-ва голосов
            {
                foreach (User user in users)
                {
                    if (user.GetPreferences[0] == (i + 1))
                        countVotesVariants[i]++;
                }
            }

            WriteData(countVotesVariants, this.NameRule);

            return iMax(countVotesVariants);
        }
    }
}