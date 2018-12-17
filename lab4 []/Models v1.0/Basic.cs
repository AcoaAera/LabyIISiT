using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace Models_v1._0
{
    class Basic
    {
        protected int countVar;//кол-во гипотез
        protected int[] countVotesVariants;//кол-во голосов для каждой гипотезы
        protected List<User> users;//предпочтения польз-й

        protected List<User> noRepeatPreference;//неповтор-ся предпочтения
        protected List<int> countVotesPreference;//кол-во гололос по каждому из предпоч-й

        string path = Directory.GetCurrentDirectory() + @"\info.txt";
        StreamWriter writer;

        public int iMax(int[] values)
        {
            int max = values[0];
            int iMax = 0;

            for (int i = 1; i < values.Length; i++)
            {
                if (values[i] >= max)
                {
                    max = values[i];
                    iMax = i;
                }
            }

            return iMax;
        }

        protected void NoRepetPreference()//формир-е списка неповтор-ся предпочтений
        {
            foreach (User user1 in users)
            {
                bool equal = false;

                foreach (var pref in noRepeatPreference)
                    if (pref.GetPreferences.SequenceEqual(user1.GetPreferences))
                    {
                        equal = true;
                        break;
                    }

                if (equal)
                    continue;

                int count = 0;

                foreach (User user2 in users)
                    if (user1.GetPreferences.SequenceEqual(user2.GetPreferences))
                        count++;

                countVotesPreference.Add(count);

                if (!noRepeatPreference.Contains(user1))
                    noRepeatPreference.Add(user1);
            }
        }

        protected void WriteData(int[] data, string nameMethod)
        {
            using (writer = new StreamWriter(path, true, Encoding.Default))
            {
                writer.WriteLine(nameMethod);
                foreach (int value in data)
                    writer.WriteLine(value.ToString());
                writer.WriteLine();
            }
        }
    }
}