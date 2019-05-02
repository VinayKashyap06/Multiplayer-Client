﻿using UnityEngine;
using System.Collections;
using Zenject;
using MultiplayerSystem;
using InputSystem;
using PlayerSystem;

namespace Commons
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            //Declare Signals
            Container.DeclareSignal<MoveForwardSignal>();
            Container.DeclareSignal<OnMoveForwardSignal>();
            Container.DeclareSignal<OnOpponentConnectedSignal>();
            Container.DeclareSignal<OnUserConnectedSignal>();


            //Bind Services
            Container.Bind(typeof(IMultiplayerService), typeof(IInitializable)).
                To<MultiplayerService>().
                AsSingle().
                NonLazy();

            Container.Bind(typeof(IInputService), typeof(ITickable)).
                To<InputService>().
                AsSingle().
                NonLazy();

            Container.Bind<IPlayerService>().
                To<PlayerService>().
                AsSingle().
                NonLazy();
        }
    }
}