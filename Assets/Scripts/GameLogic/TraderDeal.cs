using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class TraderDeal
    {
        private Trader firstTrader;
        private Trader secondTrader;

        public TraderDeal(Trader firstTrader, Trader secondTrader)
        {
            this.firstTrader = firstTrader;
            this.secondTrader = secondTrader;
        }

        public void MakeDeal()
        {
            TraderBehaviour firstBehaviour = firstTrader.Strategy.GetBehaviour();
            TraderBehaviour secondBehaviour = secondTrader.Strategy.GetBehaviour();

            if (Random.Range(0, 100) <= 5)
            {
                firstBehaviour = InverseBehaviour(firstBehaviour);
            }
            if (Random.Range(0, 100) <= 5)
            {
                secondBehaviour = InverseBehaviour(secondBehaviour);
            }
            if (firstBehaviour == TraderBehaviour.Cooperation && secondBehaviour == TraderBehaviour.Cooperation)
            {
                SendResultDeal(4,4,firstBehaviour,secondBehaviour);
                return;
            }
            if(firstBehaviour == TraderBehaviour.Deception && secondBehaviour == TraderBehaviour.Cooperation)
            {
                SendResultDeal(5,1, firstBehaviour, secondBehaviour);
                return;
            }
            if (firstBehaviour == TraderBehaviour.Cooperation && secondBehaviour == TraderBehaviour.Deception)
            {
                SendResultDeal(1,5, firstBehaviour, secondBehaviour);
                return;
            }
            if (firstBehaviour == TraderBehaviour.Deception && secondBehaviour == TraderBehaviour.Deception)
            {
                SendResultDeal(2,2, firstBehaviour, secondBehaviour);
                return;
            }
        }

        private void SendResultDeal(int addFirstTraderMoney, int addSecondTraderMoney,TraderBehaviour first,TraderBehaviour second)
        {
            firstTrader.SendMoneyForDeal(addFirstTraderMoney);
            secondTrader.SendMoneyForDeal(addSecondTraderMoney);
            firstTrader.Strategy.SendResultDeal(first, firstTrader);
            secondTrader.Strategy.SendResultDeal(second, secondTrader);
        }
        private TraderBehaviour InverseBehaviour(TraderBehaviour behaviour)
        {
            if (behaviour == TraderBehaviour.Deception)
                return TraderBehaviour.Cooperation;
            return TraderBehaviour.Deception;
        }
    }

}

