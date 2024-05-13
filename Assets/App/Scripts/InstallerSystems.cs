using App.Scripts.Systems;
using Scellecs.Morpeh;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class InstallerSystems : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        Debug.Log("Configureeeeeeeeeeeeeeeeeeeeeeeee");
        builder.Register<ISystem, MovementSystem>(Lifetime.Singleton);
        builder.Register<ISystem, CameraFollowSystem>(Lifetime.Singleton);
    }
  
}