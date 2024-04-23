using Quiz.Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI.QuestionDisplayers
{
    public class BackgroundView : MonoBehaviour, IQuestionDisplayer
    {
        [SerializeField] private RawImage backgroundImage;
        [SerializeField] private CanvasScaler canvasScaler;

        private void DisplayBackground(Texture2D backgroundTexture)
        {
            if (backgroundTexture is null) return;
            backgroundImage.texture = backgroundTexture;
            ResizeBackground();
        }
        
        private void ResizeBackground()
        {
            if (backgroundImage.texture is null) return;
            float aspectRatio = (float)backgroundImage.texture.width / backgroundImage.texture.height;
            float newWidth = canvasScaler.referenceResolution.y * aspectRatio;
            backgroundImage.rectTransform.sizeDelta = new Vector2(newWidth, canvasScaler.referenceResolution.y);
        }

        public void DisplayQuestion(QuestionData questionData)
        {
            DisplayBackground(BackgroundProvider.GetBackgroundFromData(questionData));
        }
    }
}