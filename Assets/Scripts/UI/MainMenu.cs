using GameLogic;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI.ControlFlow;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button startDealers;
    [SerializeField] private Image progresImg;
    [SerializeField] private TMP_Text currentYearText;
    
    private GuildWorld guildWorld;
    private TradersCounterInfoPresenter counterInfoPresenter;
    [Inject]
    public void Setup(GuildWorld world, TradersCounterInfoPresenter infoPresenter)
    {
       guildWorld = world;
       counterInfoPresenter = infoPresenter;
       startDealers.onClick.AddListener(guildWorld.UpdateWorld);
    }

    public void Close()
    {
        startDealers.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        progresImg.fillAmount = guildWorld.TradeProgress;
        currentYearText.text = guildWorld.CurrentYear.ToString();
        counterInfoPresenter.Update();
    }
}
