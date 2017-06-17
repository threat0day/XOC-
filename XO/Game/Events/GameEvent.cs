using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO.Game.Events
{
    public delegate void gameEvent();

    public static class GameEvent
    {
        public static event gameEvent eNotWinner;
        public static event gameEvent eGameOver;
        public static event gameEvent eXWinner;
        public static event gameEvent eOWinner;

        public static void onNotWinner()
        {
            eNotWinner?.Invoke();
            eGameOver?.Invoke();
        }
        public static void onGameOver()
        {
            eGameOver?.Invoke();
        }
        public static void onXWinner()
        {
            eXWinner?.Invoke();
            eGameOver?.Invoke();
        }
        public static void onOWinner()
        {
            eOWinner?.Invoke();
            eGameOver?.Invoke();
        }
    }
}
