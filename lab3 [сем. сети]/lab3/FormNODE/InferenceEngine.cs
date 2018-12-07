using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormNODE
{
    public enum LinksTypes { Is_Instance, AKO, Required, Located, Contains, NotRequired };

    public class InferenceEngine
    {
        //Беляев Иван - IvanBelyaev13
        private List<Node> nodes;
        private List<Question> questions;
        private List<string> nodesNames;
        private List<Node> passedNodes;

        public InferenceEngine(List<Node> nodes, List<Question> questions)
        {
            this.nodes = nodes;
            this.questions = questions;
            InferenceResult = false;
            nodesNames = new List<string>();
            passedNodes = new List<Node>();
        }

        public bool GetConclusion(string parentNodeName, string dependentNodeName, string questionText)
        {
            Node parentNode = GetNodeByName(parentNodeName);
            Node dependentNode = GetNodeByName(dependentNodeName);
            Question question = GetQuestionByText(questionText);

            foreach (Link link in parentNode.GetLinks())
            {
                passedNodes.Add(link.ChildNode);

                if (question.GetLinks().Contains(link.LinkType)) // содержится ли в вопросе рассматриваемый тип связи (является ли рассматриваемый тип связи ассоциируемым для заданного вопроса)
                {
                    passedNodes.Add(link.ChildNode);

                    if (link.ChildNode == dependentNode)
                        InferenceResult = true; //для UnitTest
                    //throw new Exception((InferenceResult = true).ToString());
                    else
                        GetConclusion(link.ChildNode.Name, dependentNode.Name, questionText);
                }
            }

            return InferenceResult;
        }

        public List<string> GetChildNodesNamesByNodeName(string nodeName)
        {
            Node target = GetNodeByName(nodeName);

            foreach (Link link in target.GetLinks())
                if (link.LinkType == LinksTypes.AKO || link.LinkType == LinksTypes.Is_Instance)
                {
                    nodesNames.Add(link.ChildNode.Name);
                    GetChildNodesNamesByNodeName(link.ChildNode.Name);
                }

            return nodesNames;
        }

        private Question GetQuestionByText(string text)
        {
            foreach (Question question in questions)
                if (question.Text == text)
                    return question;

            return null;
        }

        private Node GetNodeByName(string name)
        {
            foreach (var node in nodes)
                if (node.Name == name)
                    return node;

            return null;
        }

        private bool InferenceResult
        {
            get;
            set;
        }

        public List<Node> GetPassedNodes()
        {
            return passedNodes;
        }
    }
}
