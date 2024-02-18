using Assets.Scripts.Services;
using GameLogic;
using System.Collections;
using System.Collections.Generic;
using UI.ControlFlow;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameScope : LifetimeScope
{
    [SerializeField] private TraderFacrory traderFacrory;
    [SerializeField] private MainMenu mainMenu;
    [SerializeField] private LeaderBoard leaderBoard;
    [SerializeField] private TradersCounterInfoPanel tradersCounterInfoPanel;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent(traderFacrory);
        builder.RegisterComponent(mainMenu);
        builder.RegisterComponent(leaderBoard);
        builder.RegisterComponent(tradersCounterInfoPanel);
        builder.Register<GuildWorld>(Lifetime.Singleton);
        builder.Register<TraderStrategiesCounterService>(Lifetime.Singleton);
        builder.Register<TradersCounterInfoPresenter>(Lifetime.Singleton);
        builder.RegisterEntryPoint<GameLoop>(Lifetime.Singleton);
    }
}
