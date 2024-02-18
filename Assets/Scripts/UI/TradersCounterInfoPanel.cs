using GameLogic.TraderStategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class TradersCounterInfoPanel: MonoBehaviour
{
    [SerializeField] private TMP_Text countTraderAltruist;
    [SerializeField] private TMP_Text countTraderQuirkly;
    [SerializeField] private TMP_Text countTraderScamer;
    [SerializeField] private TMP_Text countTraderUnpredictable;
    [SerializeField] private TMP_Text countTraderVillain;
    [SerializeField] private TMP_Text countTraderVindictive;

    Dictionary<Type, TMP_Text> keys;

    private void Start()
    {
        keys = new Dictionary<Type, TMP_Text>()
        {
                {typeof(TraderAltruist),countTraderAltruist },
                {typeof(TraderQuirky),countTraderQuirkly },
                {typeof(TraderScamer),countTraderScamer },
                {typeof(TraderUnpredictable),countTraderUnpredictable },
                {typeof(TraderVillain),countTraderVillain },
                {typeof(TraderVindictive),countTraderVindictive }
        };
    }

    public void UpdateShowInfoFor(Type type,int count)
    {
        keys[type].text = count.ToString();
    }
    public void UpdateShowInfo(IReadOnlyDictionary<Type,int> counts)
    {
        foreach (var count in counts)
        {
            keys[count.Key].text = count.Value.ToString();
        }
    }
}

