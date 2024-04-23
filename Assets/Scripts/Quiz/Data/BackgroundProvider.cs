using UnityEngine;

namespace Quiz.Data
{
    public static class BackgroundProvider
    {
        public static Texture2D GetBackgroundFromData(QuestionData questionData)
        {
            return Resources.Load<Texture2D>(questionData.BackgroundPath);
        }
    }
}