using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XO.Game.Events;

namespace XO.Game
{
    public class Field
    {
        public static int FieldSize;

        private static XOEnum[,] field;

        public Field()
        {
            Field.FieldSize = 3; //
            field = new XOEnum[FieldSize, FieldSize];
            cliarField();
            GameEvent.eGameOver += () => cliarField();
        }
        public Field(int FieldSize)
        {
            Field.FieldSize = FieldSize;
            field = new XOEnum[Field.FieldSize, Field.FieldSize];
        }

        public static void setX(int i, int j)
        {
          
                field[i, j] = XOEnum.X;
            
        }
        public static void setO(int i, int j)
        {
           
                field[i, j] = XOEnum.O;
        
        }

        private void cliarField()
        {
            for (int i = 0; i < FieldSize; i++)
            {
                for (int j = 0; j < FieldSize; j++)
                {
                    field[i, j] = XOEnum.Nil;
                }
            }
        }
        public XOEnum[,] getArray()
        {
            lock (this)
            {
                return field;
            }
        }

        public static XOEnum getXorO(int i, int j)
        {

            return field[i, j];

        }

    }
}
