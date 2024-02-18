using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using GameLogic;

public class TraderView: MonoBehaviour
{
    [SerializeField] private TMP_Text traderName;
    [SerializeField] private TMP_Text countMoney;
    [SerializeField] private TMP_Text traderStrategy;
    [SerializeField] private TMP_Text countTraderDeals;

    public void UpdateCountMoney(int money)
    {
        countMoney.text = money.ToString() + " $";
    }

    public void UpdateTraderStrategy(string name)
    {
        traderStrategy.text = name;
    }

    public void UpdateCountTraderDeals(int count)
    {
        countTraderDeals.text = count.ToString();
    }

    public void UpdateName(string name)
    {
        traderName.text = name;
    }
}
