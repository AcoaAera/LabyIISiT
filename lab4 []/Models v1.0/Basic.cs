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