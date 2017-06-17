using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XO.Game.Interface;

namespace XO.Game
{
    public class InitGame
    {
        public InitGame()
        {
            IGameMechanic gameMechanic = new GameMechanic();
            gameMechanic.StartGame();
        }
    }
}
