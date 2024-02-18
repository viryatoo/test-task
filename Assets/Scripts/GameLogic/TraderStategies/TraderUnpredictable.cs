using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.TraderStategies
{
    public class TraderUnpredictable : ITraderStrategy
    {
        public TraderBehaviour GetBehaviour()
        {
            return (TraderBehaviour) UnityEngine.Random.Range(0, 1);
        }

        public void ResetStrategy()
        {

        }

        public void SendResultDeal(TraderBehaviour otherTraderBehaviour, Trader trader)
        {

        }
        public override string ToString()
        {
            return "Непредсказуемый";
        }
    }
}
