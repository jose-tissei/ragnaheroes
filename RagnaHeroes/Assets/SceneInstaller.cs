using Zenject;
using UnityEngine;
using System.Collections;

public class SceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // Container.Bind<SceneCanvas>().ToSelf().AsSingle();
        Container.Bind<IFactoryPlaceHolder>().To<FactoryPlaceHolder>().AsSingle();
    }
}