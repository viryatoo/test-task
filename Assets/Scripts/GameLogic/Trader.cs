using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace GameLogic
{
    public class Trader
    {
        public int Money { get; private set; }
        public string Name { get; private set; }
        public IReadOnlyCollection<Trader> PreviousDealersResult { get; private set; }
        public ITraderStrategy Strategy { get; private set; }
        public int CountDeals { get; private set; }

        private TraderView view;



        public Trader(int money, string name, TraderView traderView, ITraderStrategy currentStrategy)
        {
            Money = money;
            Name = name;
            view = traderView;
            Strategy = currentStrategy;

            view.UpdateName(name);
            view.UpdateTraderStrategy(Strategy.ToString());
            view.UpdateCountMoney(money);
            view.UpdateCountTraderDeals(0);
        }

        public void UpdateStrategy(ITraderStrategy strategy)
        {
            Strategy = strategy;
            view.UpdateTraderStrategy(Strategy.ToString());
        }

        public void SendMoneyForDeal(int money)
        {
            CountDeals++;
            Money += money;
            view.UpdateCountMoney(Money);
            view.UpdateCountTraderDeals(CountDeals);
        }

        public void SetPositionInHierarchy(int index)
        {
            view.transform.SetSiblingIndex(index);
        }
        public void ResetMoney()
        {
            Money = 0;
        }

        public void DestroyTrader()
        {
            GameObject.Destroy(view.gameObject);
        }

    }
}

