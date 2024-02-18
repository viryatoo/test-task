using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VContainer.Unity;

namespace GameLogic
{
    public class GameLoop:IStartable
    {
        private GuildWorld guildWorld;

        public GameLoop(GuildWorld world)
        {
            guildWorld = world;
        }

        public void Start()
        {
            guildWorld.StartGame();
        }
    }
}
