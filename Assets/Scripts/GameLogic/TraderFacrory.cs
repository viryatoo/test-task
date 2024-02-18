using GameLogic.TraderStategies;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class TraderFacrory : MonoBehaviour
    {
        [SerializeField] private Transform traderParent;
        [SerializeField] private TraderView prefab;
        private int countTraders = 0;

        public Trader CreateTrader(TraderStrategyType strategyType)
        {
            TraderView view = Instantiate(prefab, traderParent);
            Trader trader = new Trader(0, $"Trader {countTraders}", view, CreateTraderStartegy(strategyType));
            countTraders++;
            return trader;
        }

        public Trader CreateCopy(Trader trader)
        {
            Trader copyTrader = CreateTrader(CreateCopyTraderStartegy(trader));
            return copyTrader;
        }
        private ITraderStrategy CreateTraderStartegy(TraderStrategyType type)
        {
            switch (type)
            {
                case TraderStrategyType.TraderAltruist: return new TraderAltruist();
                case TraderStrategyType.TraderQuirky: return new TraderQuirky();
                case TraderStrategyType.TraderScamer: return new TraderScamer();
                case TraderStrategyType.TraderUnpredictable: return new TraderUnpredictable();
                case TraderStrategyType.TraderVillain: return new TraderVillain();
                case TraderStrategyType.TraderVindictive: return new TraderVindictive();
            }
            return new TraderAltruist();
        }

        private TraderStrategyType CreateCopyTraderStartegy(Trader trader)
        {
            switch (trader.Strategy)
            {
                case TraderAltruist: return TraderStrategyType.TraderAltruist;
                case TraderQuirky: return TraderStrategyType.TraderQuirky;
                case TraderScamer: return TraderStrategyType.TraderScamer;
                case TraderUnpredictable: return TraderStrategyType.TraderUnpredictable;
                case TraderVillain: return TraderStrategyType.TraderVillain;
                case TraderVindictive: return TraderStrategyType.TraderVindictive;
            }
            return default;
        }

        public enum TraderStrategyType
        {
            TraderAltruist,
            TraderQuirky,
            TraderScamer,
            TraderUnpredictable,
            TraderVillain,
            TraderVindictive
        }
    }
}

        