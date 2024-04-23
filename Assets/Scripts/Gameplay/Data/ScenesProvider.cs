using System;
using UnityEngine;
using Utility;

namespace Gameplay.Data
{
    [CreateAssetMenu(fileName = "ScenesProvider", menuName = "Data/ScenesProvider")]
    public class ScenesProvider : ScriptableObject
    {
        [SerializeField] private SceneField mainMenuScene;
        [SerializeField] private SceneField gameScene;
        
        public SceneField MainMenuScene => mainMenuScene;
        public SceneField GameScene => gameScene;
    }
}