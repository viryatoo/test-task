using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.TraderStategies
{
    public class TraderScamer : ITraderStrategy
    {
        public TraderBehaviour GetBehaviour()
        {
            return TraderBehaviour.Deception;
        }

        public void ResetStrategy()
        {

        }

        public void SendResultDeal(TraderBehaviour traderBehaviour, Trader trader)
        {

        }
        public override string ToString()
        {
            return "Кидала";
        }
    }
}
