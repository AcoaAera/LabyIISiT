using System;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;

namespace Tests_Project__Lab_1_
{
    class LogicalInferenceMechanism
    {
        private XDocument xml;
        private string path;
        private WorkMemory workMemory;

        public LogicalInferenceMechanism(WorkMemory workMemory)
        {
            path = Directory.GetCurrentDirectory() + "base.xml";
            xml = XDocument.Load(path);
            this.workMemory = workMemory;
        }

        public Tuple<string, string, List<string>> GetQuestionAndCurrentDefruleName() // получение текста следующего вопроса и имени соответствующего правила
        {
            string defName = string.Empty, questionText = string.Empty;
            List<string> validAnswers = new List<string>();

            foreach (var defrule in xml.Root.Elements())
            {
                foreach (var attribute in defrule.Attributes())
                {
                    defName = defrule.Attribute("name").Value;
                    defName = defName.Remove(defName.IndexOf("Defrule"), "Defrule".Length);

                    if (attribute.Name == "question" && !workMemory.IsFactСontained(defName))
                    {     
                        questionText = defrule.Attribute("question").Value;
                        string answersValues = defrule.Attribute("validAnswers").Value;
                        validAnswers = answersValues.Split(',').ToList();
                        return Tuple.Create(questionText, defName, validAnswers);
                    }
                }
            }

            return null;
        }

        public Tuple<string, bool> DefrulesEnumeration() // перебор правил и добавление выведенных фактов в РП 
        {
            string factName = null;
            bool systemExit = false;

            foreach (XElement defrule in xml.Root.Elements())
            {
                if (defrule.HasElements) // если элемент не имеет дочерних элементов (предпосылок), нет смысла проверять его
                {
                    int premisesCount = defrule.Elements().Count(), equalsPairsCount = 0;

                    foreach (XElement premise in defrule.Elements())
                    {
                        foreach (Fact fact in workMemory.GetFactsList())
                        {
                            if (fact.Name == premise.Attribute("name").Value && fact.Value == premise.Attribute("value").Value) // если имена факта из РП и предпосылки совпадают и совпадают их значения, то счетчик сравнения тикает
                            {
                                equalsPairsCount++;
                                break;
                            }
                        }
                    }

                    factName = defrule.Attribute("name").Value;
                    factName = factName.Remove(factName.IndexOf("Defrule"), "Defrule".Length);

                    if (equalsPairsCount == premisesCount && !workMemory.IsFactСontained(factName)) // если кол-во "равных" пар и кол-во предпосылок текущего правила равны, это означает, что можно занести новый выведенный факт в РП
                    {
                        workMemory.Add(new Fact(factName, "да"));

                        foreach (XAttribute attribute in defrule.Attributes()) // если факт добавлен в РП, стоит проверить, не является ли он университетом
                            if (attribute.Name == "univName")
                            {
                                systemExit = true;
                                factName = attribute.Value;
                                break;
                            }
                    }

                    if (systemExit)
                        break;
                }
            }

            return Tuple.Create(factName, systemExit);
        }

        public int GetQuestionsCount()
        {
            int count = 0;

            foreach (var elem in xml.Root.Elements())
            {
                foreach (var attribute in elem.Attributes())
                    if (attribute.Name == "question")
                    {
                        count++;
                        break;
                    }
            }

            return count;
        }
    }
}
