using Gameplay;
using UnityEngine;
using Zenject;

public class MainMenu : MonoBehaviour
{
    private ISceneLoader _sceneLoader;
    
    [Inject]
    private void Construct(ISceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
    
    public void StartGame()
    {
        _sceneLoader.LoadGameScene();
    }
}
