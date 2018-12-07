using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FormNODE
{
    public partial class Form1 : Form
    {
        //Беляев Иван - IvanBelyaev13

        private InferenceEngine engine;
        private List<Node> nodes;
        private List<Question> questions;
        private List<Node> passedNodes;

        public Form1()
        {
            InitializeComponent();
        }

        private void FillComboboxes()
        {
            foreach (var node in nodes)
            {
                NodesCmb1.Items.Add(node.Name);
                NodesCmb2.Items.Add(node.Name);
                NodesCmb3.Items.Add(node.Name);
            }

            foreach (var question in questions)
                QuestionsCmb.Items.Add(question.Text);
        }

        private void GetConclusionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string dependentNodeName = NodesCmb1.Text; // предполагаемый зависимый узел
                string parentNodeName = NodesCmb2.Text; // предполагаемый "старший" узел
                string questionText = QuestionsCmb.Text;

                if (dependentNodeName == string.Empty || parentNodeName == string.Empty || questionText == string.Empty)
                    throw new Exception("Выберите вершины и тип вопроса.");

                engine = new InferenceEngine(nodes, questions);
                bool result = engine.GetConclusion(parentNodeName, dependentNodeName, questionText);

                MessageBox.Show(result.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetChildsNodesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string nodeName = NodesCmb3.Text;

                if (nodeName == string.Empty)
                    throw new Exception("Выберите вершину.");

                ChildsNodesListBox.Items.Clear();

                engine = new InferenceEngine(nodes, questions);
                List<string> nodesNames = engine.GetChildNodesNamesByNodeName(nodeName);

                if (nodesNames.Count == 0)
                    ChildsNodesListBox.Items.Add("Дочерних узлов не обнаружено.");
                else
                    foreach (string name in nodesNames)
                        ChildsNodesListBox.Items.Add(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExplanationComponentCallBtn_Click(object sender, EventArgs e)
        {
            if (engine != null)
                passedNodes = engine.GetPassedNodes();

            if (passedNodes == null || engine == null || passedNodes.Count == 0)
            {
                MessageBox.Show("Выполните хотя бы одну проверку.");
                return;
            }

            string result = "Имена пройденных по порядку узлов:\r\n";

            foreach (var node in passedNodes)
                result += node.Name + "\r\n";

            MessageBox.Show(result);
        }
    }
}
