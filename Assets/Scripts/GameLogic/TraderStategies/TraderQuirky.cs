using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace GameLogic.TraderStategies
{
    public class TraderQuirky : ITraderStrategy
    {
        private Queue<TraderBehaviour> cashedBehaviours;

        private TraderBehaviour currentBehaviour;

        private bool isScamed;

        public TraderQuirky()
        {
            cashedBehaviours = new Queue<TraderBehaviour>();
            cashedBehaviours.Enqueue(TraderBehaviour.Cooperation);
            cashedBehaviours.Enqueue(TraderBehaviour.Deception);
            cashedBehaviours.Enqueue(TraderBehaviour.Cooperation);
            cashedBehaviours.Enqueue(TraderBehaviour.Cooperation);
            cashedBehaviours.Enqueue(TraderBehaviour.Cooperation);
            currentBehaviour = cashedBehaviours.Dequeue();
        }
        public TraderBehaviour GetBehaviour()
        {
            return currentBehaviour;
        }

        public void ResetStrategy()
        {
            cashedBehaviours.Enqueue(TraderBehaviour.Cooperation);
            cashedBehaviours.Enqueue(TraderBehaviour.Deception);
            cashedBehaviours.Enqueue(TraderBehaviour.Cooperation);
            cashedBehaviours.Enqueue(TraderBehaviour.Cooperation);
            cashedBehaviours.Enqueue(TraderBehaviour.Cooperation);
            currentBehaviour = cashedBehaviours.Dequeue();
            isScamed = false;
        }

        public void SendResultDeal(TraderBehaviour otherTraderBehaviour, Trader trader)
        {
            if(otherTraderBehaviour == TraderBehaviour.Deception)
            {
                isScamed = true;
            }

            if (cashedBehaviours.Count == 0)
            {
                if (isScamed)
                    currentBehaviour = TraderBehaviour.Deception;
                else
                    currentBehaviour = otherTraderBehaviour;
            }
            else
            {
                currentBehaviour = cashedBehaviours.Dequeue();
            }

        }
        public override string ToString()
        {
            return "Ушлый";
        }

    }
}
