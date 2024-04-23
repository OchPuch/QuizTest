using System;
using Quiz.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class QuestionResultView : MonoBehaviour
    {
        [Header("Result text")]
        [SerializeField] private TextMeshProUGUI resultText;
        [Space(5)]
        [SerializeField] private Color correctColor;
        [SerializeField] private string correctMessage;
        [Space(5)]
        [SerializeField] private Color incorrectColor;
        [SerializeField] private string incorrectMessage;
        
        [Header("Panel")] 
        [SerializeField] private GameObject resultPanel;
        [SerializeField] private Button nextButton;

        public event Action NextButtonClicked;
        
        private bool _isInitialized;
        
        public void Initialize()
        {
            if (_isInitialized) return;
            nextButton.onClick.AddListener(NextButtonClick);
            _isInitialized = true;
        }
        
        public void DisplayResult(bool isCorrect)
        {
            resultPanel.SetActive(true);
            resultText.color = isCorrect ? correctColor : incorrectColor;
            resultText.text = isCorrect ? correctMessage : incorrectMessage;
        }
        
        public void OnQuestionStarted(QuestionData data)
        {
            HideResult();
        }
    
        private void HideResult()
        {
            resultPanel.SetActive(false);
        }

        private void NextButtonClick()
        {
            NextButtonClicked?.Invoke();
        }

    }
}
