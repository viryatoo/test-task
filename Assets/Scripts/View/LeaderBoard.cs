using GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private Button btnSortByMoney;
    [SerializeField] private Button btnSortByDealers;

    private IReadOnlyList<Trader> traders;

    [Inject]
    public void Setup(GuildWorld guildWorld)
    {
        traders = guildWorld.Traders;
        btnSortByMoney.onClick.AddListener(SortByMoney);
        btnSortByDealers.onClick.AddListener(SortByDealers);
    }

    private void SortByMoney()
    {
        var sortTraders = traders.OrderByDescending(x => x.Money);
        int i = 0;
        foreach (var trader in sortTraders)
        {
            trader.SetPositionInHierarchy(i);
            i++;
            Debug.Log(i);
        }
    }
    private void SortByDealers()
    {
        var sortTraders = traders.OrderByDescending(x => x.CountDeals);
        int i = 0;
        foreach (var trader in sortTraders)
        {
            trader.SetPositionInHierarchy(i);
            i++;
        }
    }
}

