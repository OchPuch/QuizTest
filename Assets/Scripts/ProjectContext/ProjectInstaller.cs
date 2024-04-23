using Gameplay;
using Gameplay.Data;
using UnityEngine;
using Zenject;

namespace ProjectContext
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private ScenesProvider scenesProvider;
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SceneLoader>().AsSingle().WithArguments(scenesProvider);
        }
    }
}
