using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Quiz
{
    class Viktorin
    {
        public string nameOfVik { get; set; }
        public List<IQuestion> questions;
        public int score { get; set; }
        public Viktorin(string filePath)
        {
            LoadFromXml(filePath);
        }
        private void LoadFromXml(string filePath)
        {
            questions = new List<IQuestion>();

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            XmlNodeList questionNodes = doc.SelectNodes("/Viktorin/question");

            foreach (XmlNode questionNode in questionNodes)
            {
                string questionText = questionNode.SelectSingleNode("text").InnerText;
                string questionType = questionNode.Attributes["type"].Value;

                if (questionType == "OneAnswer")
                {
                    string correctAnswer = questionNode.SelectSingleNode("correct").InnerText;

                    XmlNodeList optionNodes = questionNode.SelectNodes("options/option");
                    Dictionary<char, string> answerOptions = new Dictionary<char, string>();

                    char optionKey = 'A';

                    foreach (XmlNode optionNode in optionNodes)
                    {
                        string optionText = optionNode.InnerText;
                        answerOptions.Add(optionKey, optionText);
                        optionKey++;
                    }

                    OneAnswQuest oneAnswerQuestion = new OneAnswQuest(questionText, answerOptions, correctAnswer);
                    questions.Add(oneAnswerQuestion);
                }
                else if (questionType == "MultipleAnswer")
                {
                    XmlNodeList correctAnswerNodes = questionNode.SelectNodes("correct/option");
                    List<string> correctAnswers = new List<string>();

                    foreach (XmlNode answerNode in correctAnswerNodes)
                    {
                        string correctAnswer = answerNode.InnerText;
                        correctAnswers.Add(correctAnswer);
                    }

                    XmlNodeList optionNodes = questionNode.SelectNodes("options/option");
                    Dictionary<char, string> answerOptions = new Dictionary<char, string>();

                    char optionKey = 'A';

                    foreach (XmlNode optionNode in optionNodes)
                    {
                        string optionText = optionNode.InnerText;
                        answerOptions.Add(optionKey, optionText);
                        optionKey++;
                    }

                    MoreAnswQuest multipleAnswerQuestion = new MoreAnswQuest(questionText, answerOptions, correctAnswers);
                    questions.Add(multipleAnswerQuestion);
                }
                string viktorinType = doc.DocumentElement.Attributes["type"].Value;
                if (viktorinType == "Math")
                {
                    nameOfVik = "Math";
                }
            }
        }

        public void Start()
        {
            Console.WriteLine(nameOfVik);
            foreach (var q in questions)
            {
                var x = q.IsCorrect();
                if (x == true)
                {
                    score += 100;
                }
                else
                    score -= 10;
            }
        }
    }
}
