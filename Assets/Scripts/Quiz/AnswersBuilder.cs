using System;
using System.Collections.Generic;
using System.Linq;
using Quiz.Data;
using UI;
using UnityEngine;
using Zenject;

namespace Quiz
{
    [Serializable]
    public class AnswersBuilder : IInitializable
    {
        [SerializeField] private bool shuffleAnswers;
        private AnswerButtonFactory _answerButtonFactory;

        private List<AnswerButton> _answerButtons;

        private bool _isInitialized;
        
        public AnswersBuilder(AnswerButtonFactory answerButtonFactory, bool shuffleAnswers)
        {
            this.shuffleAnswers = shuffleAnswers;
            _answerButtonFactory = answerButtonFactory;
        }

        public void Initialize()
        {
            if (_isInitialized) return;
            _answerButtons = new List<AnswerButton>();
            _isInitialized = true;
        }

        public void BuildAnswers(QuestionData questionData, Action onAnswerCorrect, Action onAnswerIncorrect)
        {
            if (!_isInitialized) throw new InvalidOperationException("QuizBuilder is not initialized");

            var answersTexts = questionData.Answers.ToArray();
            if (shuffleAnswers) answersTexts = answersTexts.OrderBy(a => Guid.NewGuid()).ToArray();

            foreach (var a in answersTexts)
            {
                var button = _answerButtonFactory.CreateButton();
                button.Init(a);

                button.AnswerClick += (questionData.IsCorrectAnswer(a)) ? onAnswerCorrect : onAnswerIncorrect;

                _answerButtons.Add(button);
            }
        }

        public void ClearCurrentAnswers()
        {
            foreach (var button in _answerButtons)
            {
                button.Release();
            }
            _answerButtons.Clear();
        }
    }
}