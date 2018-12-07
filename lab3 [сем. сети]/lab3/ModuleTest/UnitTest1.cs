using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormNODE;
using System.Collections.Generic;

namespace ModuleTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Рустем Хатямов

            List<Question> списокВопросов = new List<Question>();
            Question q_vhodit = new Question("Является ли: AKO, IS-INSTANCE");
            q_vhodit.LinkAdd(LinksTypes.Is_Instance);
            q_vhodit.LinkAdd(LinksTypes.AKO);
            списокВопросов.Add(q_vhodit);

            //Node Категория = new Node("Категория");
            //Node Гуманитарный = new Node("Гуманитарный");
            Node МГУ = new Node("МГУ");
            Node ТОП5 = new Node("ТОП-5");
            Node ВУЗ = new Node("ВУЗ");

            //Категория.LinkAdd(new Link(Гуманитарный, Категория, LinksTypes.AKO));
            List<Node> nodes = new List<Node>();

            nodes.Add(МГУ);
            nodes.Add(ТОП5);
            nodes.Add(ВУЗ);

            ВУЗ.LinkAdd(new Link(ТОП5, ВУЗ, LinksTypes.AKO));
            ТОП5.LinkAdd(new Link(МГУ, ТОП5, LinksTypes.Is_Instance));

            InferenceEngine engine = new InferenceEngine(nodes, списокВопросов);

            bool actual = engine.GetConclusion(ВУЗ.Name, МГУ.Name, q_vhodit.Text);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }
    }
}
