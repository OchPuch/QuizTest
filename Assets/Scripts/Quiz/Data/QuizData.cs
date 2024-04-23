using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Utility;

namespace Quiz.Data
{
    public class QuizData
    {
        public IEnumerable<QuestionData> Questions => _questions;
        private readonly QuestionData[] _questions;

        private QuizData(QuestionData[] questions)
        {
            _questions = questions;
        }
        
        public static QuizData Parse(string json)
        {
            QuestionData[] questions = JsonHelper.FromJson<QuestionData>(json);
            return new QuizData(questions);
        }
    }
    
    [Serializable]
    public class QuestionData
    {
        public string Question => question;
        
        //background but removed file extension
        public string BackgroundPath => background.Split('.')[0];
        public IEnumerable<string> Answers => answers.Select(a => a.text);
        public bool IsCorrectAnswer(string answer) => answers.First(a => a.text == answer).correct;
        
        [SerializeField] private string question;
        [SerializeField] private AnswerData[] answers;
        [SerializeField] private string background;
        
        [Serializable]
        private class AnswerData
        {
            public string text;
            public bool correct;
        }
    }
    
    

    
}