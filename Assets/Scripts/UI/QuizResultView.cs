using System;
using Quiz.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class QuizResultView : MonoBehaviour
    {
        [SerializeField] private GameObject resultPanel;
        [SerializeField] private TextMeshProUGUI resultText;
        [Space(10)]
        [SerializeField] private Button restartButton;
        
        public event Action RestartButtonClicked;
        
        public void Initialize()
        {
            resultPanel.SetActive(false);
            restartButton.onClick.AddListener(RestartButtonClick);
        }
        
        public void DisplayResult(QuizResult result)
        {
            resultPanel.SetActive(true);
            resultText.text = $"{result.CorrectAnswers}/{result.TotalQuestions}";
        }

        private void RestartButtonClick()
        {
            RestartButtonClicked?.Invoke();
        }

        
    }
}