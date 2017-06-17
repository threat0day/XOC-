using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using XO.Game.Events;
using XO.Game.Interface;


namespace XO.Game
{
    class GameMechanic : IGameMechanic
    {
        public void FindWinner()
        {
            //определяем победителя
            Action<XOEnum> defineWinner = (XOEnum XorO) =>
            {
                if (XorO == XOEnum.X)
                {
                    GameEvent.onXWinner();
                    MessageBox.Show("X win");
                }
                else
                {
                    GameEvent.onOWinner();
                    MessageBox.Show("O win");
                }
            };
            //левая диагональ
            Action<XOEnum> diagonalLeftFind = (XOEnum XorO) =>
            {
                int countdiagonalLeft = 0;
                for (int i = 0; i < Field.FieldSize; i++)
                {
                    if (Field.getXorO(i, i) == XorO)
                    {
                        countdiagonalLeft++;
                    }
                    if (countdiagonalLeft == 3)
                    {
                        defineWinner(XorO);
                        break;
                    }
                }

            };
            //правая диагональ
            Action<XOEnum> diagonalRightFind = (XOEnum XorO) =>
            {
                int countdiagonalRight = 0;
                int i = Field.FieldSize - 1;
                int j = 0;
                while (i >= 0)
                {

                    if (Field.getXorO(j, i) == XorO)
                    {
                        countdiagonalRight++;
                    }
                    if (countdiagonalRight == 3)
                    {
                        defineWinner(XorO);
                        break;
                    }
                    i--;
                    j++;
                }
            };
            //по горизонталям 
            Action<XOEnum> gorizontFind = (XOEnum XorO) =>
            {
                int countXorORight = 0;
                int countXorODown = 0;
                for (int i = 0; i < Field.FieldSize; i++)
                {
                    for (int j = 0; j < Field.FieldSize; j++)
                    {
                        if (Field.getXorO(i, j) == XorO)
                        {
                            countXorODown++;
                        }
                        if (Field.getXorO(j, i) == XorO)
                        {
                            countXorORight++;
                        }
                    }

                    if (countXorORight == 3 | countXorODown == 3)
                    {
                        defineWinner(XorO);
                        break;
                    }

                    else
                    {
                        countXorORight = 0;
                        countXorODown = 0;
                    }

                }
            };

            Task findWinner = new Task(() =>
            {
                bool exit = false;
                GameEvent.eGameOver += () => exit = true;
                while (!exit)
                {
                    diagonalLeftFind(XOEnum.X);
                    diagonalLeftFind(XOEnum.O);
                    diagonalRightFind(XOEnum.X);
                    gorizontFind(XOEnum.X);
                    diagonalRightFind(XOEnum.O);
                    gorizontFind(XOEnum.O);
                    Task.Delay(10);
                }
            });
            findWinner.Start();
        }
        private void checkGameOver()
        {
            Task checkGameOver = new Task(delegate ()
            {
                bool exit = false;
                GameEvent.eGameOver += () => exit = true;
                while (!exit)
                {
                    bool exitNil = false;
                    for (int i = 0; i < Field.FieldSize; i++)
                    {
                        for (int j = 0; j < Field.FieldSize; j++)
                        {
                            if (Field.getXorO(i, j) == XOEnum.Nil) exitNil = true;
                        }
                    }
                    if (!exitNil)
                    {
                        GameEvent.onNotWinner();
                        MessageBox.Show("Ничья");
                    }
                    Task.Delay(10);
                }

            });
            checkGameOver.Start();
        }

        public void NewGame()
        {

        }

        public void StartGame()
        {
            Field mainField = new Field();

            FindWinner();
            checkGameOver();
        }

        public void TurnII()
        {

        }
    }

}
