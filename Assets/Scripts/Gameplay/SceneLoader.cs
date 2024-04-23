using Gameplay.Data;
namespace Gameplay
{
    public interface ISceneLoader
    {
        void LoadMainMenuScene();
        void LoadGameScene();
    }
    
    public class SceneLoader : ISceneLoader
    {
        private readonly ScenesProvider _scenesProvider;
        
        public SceneLoader(ScenesProvider scenesProvider)
        {
            _scenesProvider = scenesProvider;
        }
        public void LoadMainMenuScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(_scenesProvider.MainMenuScene);
        }
        
        public void LoadGameScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(_scenesProvider.GameScene);
        }
    }
}