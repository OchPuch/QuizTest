using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class AnswerButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TextMeshProUGUI text;
    
        public event Action AnswerClick;
        public event Action Released;
    
        private bool _isInitialized;
    
        public void Init(string answerText)
        {
            if (_isInitialized) return;
        
            if (button is null) throw new InvalidOperationException("Button is not set in Inspector");
            if (text is null) throw new InvalidOperationException("Text is not set in Inspector");
        
            text.text = answerText;
            button.onClick.AddListener(() => AnswerClick?.Invoke());
        
            _isInitialized = true;
        }
    
        public void Release()
        {
            _isInitialized = false;
            button.onClick.RemoveAllListeners();
            text.text = string.Empty;
            AnswerClick = null;
            Released?.Invoke();
        }
    }
}
