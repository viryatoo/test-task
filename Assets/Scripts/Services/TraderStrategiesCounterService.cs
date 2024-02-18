using GameLogic;
using GameLogic.TraderStategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Services
{
    public class TraderStrategiesCounterService
    {
        private Dictionary<Type, int> tradersCounter;

        public TraderStrategiesCounterService()
        {
            InitCounter();
        }

        public void UpdateCounter(IReadOnlyList<Trader> traders)
        {
            InitCounter();
            foreach (var trader in traders)
            {
                tradersCounter[trader.Strategy.GetType()]++;
            }
        }
        private void InitCounter()
        {
            tradersCounter = new Dictionary<Type, int>()
            {
                {typeof(TraderAltruist),0 },
                {typeof(TraderQuirky),0 },
                {typeof(TraderScamer),0 },
                {typeof(TraderUnpredictable),0 },
                {typeof(TraderVillain),0 },
                {typeof(TraderVindictive),0 }
            };
        }

        public int GetCountOf(System.Type type)
        {
            return tradersCounter[type];
        }
        public IReadOnlyDictionary<Type,int> GetCount()
        {
            return tradersCounter;
        }
    }
}
