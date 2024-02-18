using Assets.Scripts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace UI.ControlFlow
{
    public class TradersCounterInfoPresenter
    {
        private TradersCounterInfoPanel infoPanel;
        private TraderStrategiesCounterService counterService;
        public TradersCounterInfoPresenter(TradersCounterInfoPanel panel, TraderStrategiesCounterService service)
        {
            infoPanel = panel;
            counterService = service;
        }

        public void Update()
        {
            infoPanel.UpdateShowInfo(counterService.GetCount());
        }
    }
}
