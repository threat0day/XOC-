using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO.Game.Interface
{
    public interface IGameMechanic
    {
        void StartGame();
        void NewGame();
        void TurnII();
        void FindWinner();
    }
}
