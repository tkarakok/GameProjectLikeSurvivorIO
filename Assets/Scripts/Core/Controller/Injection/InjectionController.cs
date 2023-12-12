using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class InjectionController : MonoInstaller, IInjectionController
{
    [SerializeField] private Player _player;
    public override void InstallBindings()
    {
        Container.Bind<Player>().FromComponentInHierarchy(_player).AsSingle();
    }
}