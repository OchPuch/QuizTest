using System.Collections.Generic;
using Quiz.Data;
using UI;
using UI.QuestionDisplayers;
using Zenject;

namespace Gameplay
{
    public class GameUiMediator : System.IDisposable, IInitializable
    {
        private GameSessionController _gameSessionController;
        private ISceneLoader _sceneLoader;

        private QuizResultView _quizResultView;
        private QuestionResultView _questionResultView;

        private readonly List<IQuestionDisplayer> _questionDisplayers = new();


        public GameUiMediator(GameSessionController gameSessionController,
            ISceneLoader sceneLoader,
            QuestionResultView questionResultView, 
            QuizResultView quizResultView,
            params IQuestionDisplayer[] questionDisplayers)
        {
            _sceneLoader = sceneLoader;
            _gameSessionController = gameSessionController;
            _questionResultView = questionResultView;
            _quizResultView = quizResultView;
            _questionDisplayers.AddRange(questionDisplayers);
        }

        

        public void Initialize()
        {
            _gameSessionController.QuestionStarted += DisplayQuestion;
            _gameSessionController.Answered += _questionResultView.DisplayResult;
            _gameSessionController.GameFinished += ChangeNextButtonMeaningToFinishingQuiz;
            _questionResultView.NextButtonClicked += _gameSessionController.StartNextQuestion;
            _quizResultView.RestartButtonClicked += LeaveToMenu;
        }

        public void Dispose()
        {
            _questionDisplayers.Clear();
            _gameSessionController.QuestionStarted -= DisplayQuestion;
            _gameSessionController.Answered -= _questionResultView.DisplayResult;
            _questionResultView.NextButtonClicked -= _gameSessionController.StartNextQuestion;
            _gameSessionController.GameFinished -= ChangeNextButtonMeaningToFinishingQuiz;
            _quizResultView.RestartButtonClicked -= LeaveToMenu;
        }

        private void DisplayQuestion(QuestionData data)
        {
            _questionResultView.OnQuestionStarted(data);

            foreach (var questionDisplayer in _questionDisplayers)
            {
                questionDisplayer.DisplayQuestion(data);
            }
        }

        private void ChangeNextButtonMeaningToFinishingQuiz()
        {
            _questionResultView.NextButtonClicked -= _gameSessionController.StartNextQuestion;
            _questionResultView.NextButtonClicked += DisplayResult;
        }

        private void DisplayResult()
        {
            _quizResultView.DisplayResult(_gameSessionController.GetResult());
        }

        private void LeaveToMenu()
        {
            _sceneLoader.LoadMainMenuScene();
        }
    }
}