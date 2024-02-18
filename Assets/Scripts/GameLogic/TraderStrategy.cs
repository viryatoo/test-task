using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public interface ITraderStrategy
    {
        public TraderBehaviour GetBehaviour();
        public void SendResultDeal(TraderBehaviour otherTraderBehaviour, Trader trader);

        public void ResetStrategy();
    }

    public enum TraderBehaviour
    {
        Cooperation,
        Deception
    }

}
