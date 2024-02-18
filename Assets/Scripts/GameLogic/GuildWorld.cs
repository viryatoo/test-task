using Assets.Scripts.Services;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Utils;
using VContainer.Unity;

namespace GameLogic
{
    public class GuildWorld
    {
        public float TradeProgress { get; private set; }
        public int CurrentYear { get; private set; }
        public IReadOnlyList<Trader> Traders => traders;

        private List<Trader> traders;
        private TraderFacrory traderFacroty;
        private TraderStrategiesCounterService traderStrategiesCounterService;

        public GuildWorld(TraderFacrory facrory, TraderStrategiesCounterService counterService)
        {
            traderFacroty = facrory;
            traderStrategiesCounterService = counterService;
            TradeProgress = 0;
            traders = new List<Trader>();
        }


        public async void StartGame()
        {
            await SpawnTraders();
            traderStrategiesCounterService.UpdateCounter(traders);
        }

        private async Task SpawnTraders()
        {
            for (int i = 0; i < 10; i++)
            {
                traders.Add(traderFacroty.CreateTrader(TraderFacrory.TraderStrategyType.TraderAltruist));
                await Task.Delay(10);
            }
            for (int i = 0; i < 10; i++)
            {
                traders.Add(traderFacroty.CreateTrader(TraderFacrory.TraderStrategyType.TraderQuirky));
                await Task.Delay(10);
            }
            for (int i = 0; i < 10; i++)
            {
                traders.Add(traderFacroty.CreateTrader(TraderFacrory.TraderStrategyType.TraderScamer));
                await Task.Delay(10);
            }
            for (int i = 0; i < 10; i++)
            {
                traders.Add(traderFacroty.CreateTrader(TraderFacrory.TraderStrategyType.TraderUnpredictable));
                await Task.Delay(10);
            }
            for (int i = 0; i < 10; i++)
            {
                traders.Add(traderFacroty.CreateTrader(TraderFacrory.TraderStrategyType.TraderVillain));
                await Task.Delay(10);
            }
            for (int i = 0; i < 10; i++)
            {
                traders.Add(traderFacroty.CreateTrader(TraderFacrory.TraderStrategyType.TraderVindictive));
                await Task.Delay(10);
            }
        }

        public async void UpdateWorld()
        {
            NewYear();
            await UpdateYear();
            SortTradersByMoney();
            CopyAndRemoveTraders();
            traderStrategiesCounterService.UpdateCounter(traders);
        }

        public void DeleteTrader()
        {
            
        }
        private async Task UpdateYear()
        {
            traders.Shuffle();
            for (int j = 0; j < traders.Count / 2; j++)
            {
                Trader traderFirst = traders[j];
                Trader traderSecond = traders[traders.Count - j - 1];

                int countDeals = Random.Range(5, 10);
                for (int i = 0; i < countDeals; i++)
                {
                    traderFirst = traders[j];
                    traderSecond = traders[traders.Count - j - 1];

                    TraderDeal deal = new TraderDeal(traderFirst, traderSecond);
                    deal.MakeDeal();
                }
                traderFirst.Strategy.ResetStrategy();
                traderSecond.Strategy.ResetStrategy();
                await Task.Delay(15);
                TradeProgress = (float)((j + 2) * 2.0 / traders.Count);
            }
            TradeProgress = 0;
        }

        private void SortTradersByMoney()
        {
            traders.Sort((Trader t1, Trader t2) =>
            {
                return t2.Money.CompareTo(t1.Money);
            });
        }
        private void CopyAndRemoveTraders()
        {
            for(int i = 0; i < 20 && i < traders.Count; i++)
            {
                traders[traders.Count - 1].DestroyTrader();
                traders.RemoveAt(traders.Count - 1);
            }
            for (int i = 0; i < 20 && i<traders.Count; i++)
            {
                traders.Add(traderFacroty.CreateCopy(traders[i]));
            }
        }
        private void NewYear()
        {
            foreach(var trader in traders)
            {
                trader.ResetMoney();
            }
            CurrentYear++;
        }
    }
}


