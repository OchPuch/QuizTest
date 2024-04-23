using System;
using System.Linq;
using Quiz;
using Quiz.Data;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class GameSessionController : IDisposable, IInitializable
    {
        private readonly AnswersBuilder _answersBuilder;

        private QuizData _quizData;
        private QuizResult _quizResult;
        private int _currentQuestionIndex;
        private bool _isFinished;
        
        private bool _isInitialized;

        public event Action<QuestionData> QuestionStarted;
        public event Action<bool> Answered;
        public event Action GameFinished;

        public GameSessionController(QuizData data, AnswersBuilder answersBuilder)
        {
            _answersBuilder = answersBuilder;
            _quizData = data;
        }

        public void Initialize()
        {
            if (_isInitialized) return;
            
            _currentQuestionIndex = 0;
            _quizResult = new QuizResult
            {
                CorrectAnswers = 0,
                TotalQuestions = _quizData.Questions.Count()
            };

            Answered += OnAnswer;
            
            _isInitialized = true;
        }
        
        public void Dispose()
        {
            Answered -= OnAnswer;
        }

        public void StartNextQuestion()
        {
            if (!_isInitialized) throw new InvalidOperationException("GameSessionController is not initialized");
            if (_isFinished) return;
            
            var questionData = _quizData.Questions.ToArray()[_currentQuestionIndex];

            _answersBuilder.ClearCurrentAnswers();
            _answersBuilder.BuildAnswers(questionData, AnswerCorrect, AnswerIncorrect);

            QuestionStarted?.Invoke(questionData);

            _currentQuestionIndex++;
        }
        
        public QuizResult GetResult()
        {
            return _quizResult;
        }

        private void AnswerCorrect()
        {
            _quizResult.CorrectAnswers++;
            Answered?.Invoke(true);
        }

        private void AnswerIncorrect()
        {
            Answered?.Invoke(false);
        }

        private void OnAnswer(bool isCorrect)
        {
            if (_currentQuestionIndex < _quizData.Questions.Count()) return;
            _isFinished = true;
            GameFinished?.Invoke();
        }


        
    }
}