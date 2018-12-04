using System;
using System.Collections.Generic;

namespace Tests_Project__Lab_1_
{
    class WorkMemory
    {
        private List<Fact> workMemory;
        private LogicalInferenceMechanism mechanism;

        public WorkMemory()
        {
            workMemory = new List<Fact>();
            mechanism = new LogicalInferenceMechanism(this);
            QuestionsCount = mechanism.GetQuestionsCount();
        }

        public void Add(Fact fact) // добавление факта в РП
        {
            workMemory.Add(fact);
        }

        public bool IsFactСontained(string factName) // чек наличия факта в рабочей памяти по имени правила, из которого он был выведен
        {
            bool result = false;

            foreach (Fact fact in workMemory)
            {
                if (fact.Name == factName)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public Tuple<string, string, List<string>> GetQuestionAndCurrentDefruleName() // получение текста следующего вопроса и имени соответствующего правила
        {
            Tuple<string, string, List<string>> result = mechanism.GetQuestionAndCurrentDefruleName();
            string questionText = result.Item1;
            string defName = result.Item2;
            List<string> validAnswers = result.Item3;
            return Tuple.Create(questionText, defName, validAnswers);
        }

        public void ResponseProcessing(string factName, string value) // обработка ответа пользователя путем добавления факта в РП с заданным именем и значением
        {
            //factName = factName.Remove(factName.IndexOf("Defrule"), "Defrule".Length);
            Add(new Fact(factName, value));
        }

        public List<Fact> GetFactsList() // возврат списка фактов, содержащихся в РП, для МЛВ
        {
            return workMemory;
        }

        public Tuple<string, bool> DefrulesEnumeration() // перебор правил и добавление в РП по критерию выполнения всех предпосылок правила
        {
            return mechanism.DefrulesEnumeration();
        }

        public void Clear() // очистка рабочей памяти
        {
            workMemory.Clear();
        }

        public int QuestionsCount
        {
            get;
            private set;
        }
    }
}
