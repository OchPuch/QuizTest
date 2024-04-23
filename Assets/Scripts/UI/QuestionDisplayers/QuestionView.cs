using Quiz.Data;
using TMPro;
using UnityEngine;

namespace UI.QuestionDisplayers
{
    public class QuestionView : MonoBehaviour, IQuestionDisplayer
    {
        [SerializeField] private TextMeshProUGUI questionText;
        public void DisplayQuestion(QuestionData questionData)
        {
            questionText.text = questionData.Question;
        }
        
    }
}