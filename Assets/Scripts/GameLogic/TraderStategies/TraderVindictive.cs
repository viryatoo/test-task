using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.TraderStategies
{
    public class TraderVindictive : ITraderStrategy
    {
        private TraderBehaviour currentBehaviour = TraderBehaviour.Cooperation;
        public TraderBehaviour GetBehaviour()
        {
            return currentBehaviour;
        }

        public void ResetStrategy()
        {
            currentBehaviour = TraderBehaviour.Cooperation;
        }

        public void SendResultDeal(TraderBehaviour otherTraderBehaviour, Trader trader)
        {
            if(otherTraderBehaviour == TraderBehaviour.Deception) 
                currentBehaviour = otherTraderBehaviour;
        }
        public override string ToString()
        {
            return "Злопамятный";
        }
    }
}
