using Gameplay;
using Quiz;
using Quiz.Data;
using UI;
using UI.QuestionDisplayers;
using UnityEngine;
using Zenject;

public class Bootstrap : MonoInstaller
{
    [Header("Data")] 
    [SerializeField] private TextAsset quizDataJson;

    [Header("Gameplay")] 
    [SerializeField] private AnswerButtonFactory answerButtonFactory;
    [SerializeField] private bool shuffleAnswers; //TODO: Replace with config file 

    [Header("UI")] 
    [SerializeField] private QuizResultView quizResultView;
    [SerializeField] private QuestionResultView questionResultView;
    [Space(10)] 
    [SerializeField] private BackgroundView backgroundView;
    [SerializeField] private QuestionView questionView;


    public override void InstallBindings()
    {
        QuizData quizData = QuizData.Parse(quizDataJson.text);
        
        Container.BindInterfacesAndSelfTo<AnswerButtonFactory>().FromInstance(answerButtonFactory).AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<AnswersBuilder>().AsSingle().WithArguments(answerButtonFactory, shuffleAnswers);
        Container.BindInterfacesAndSelfTo<GameSessionController>().AsSingle().WithArguments(quizData);

        questionResultView.Initialize();
        quizResultView.Initialize();

        Container.BindInterfacesAndSelfTo<GameUiMediator>().AsSingle().WithArguments(questionResultView, quizResultView, new IQuestionDisplayer[] { backgroundView, questionView });
    }

    public override void Start()
    {
        Container.Resolve<GameSessionController>().StartNextQuestion();
    }

    
}