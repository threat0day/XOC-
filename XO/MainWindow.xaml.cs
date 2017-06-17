using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using XO.Game;
using XO.Game.Events;
using XO.Game.Object;

namespace XO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public XOEnum turn;//чей сейчас ход
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_btn(object sender, RoutedEventArgs e)
        {
            InitGame initGame = new InitGame();
            turn = XOEnum.X;

            for (int i = 0; i < Field.FieldSize; i++)
            {
                for (int j = 0; j < Field.FieldSize; j++)
                {
                    XOButton btn = new XOButton()
                    {

                        Width = 75,
                        Height = 111,
                        Margin = new Thickness(-500 + i * 200, -300 + j * 230, 0, 0),
                        Name = "btn" + i + j,
                    };
                    btn.Click += generateBtnClick;
                    btn.X = i;
                    btn.Y = j;

                    MainGrid.Children.Add(btn);  //на главный кинули кнопку
                }
            }
        }
        void generateBtnClick(Object sender, EventArgs e)
        {
            XOButton btn = ((XOButton)sender);

            if (Field.getXorO(btn.X, btn.Y) == XOEnum.Nil)
            {
                if (turn == XOEnum.O)
                {
                    Field.setO(btn.X, btn.Y);
                    turn = XOEnum.X;
                }

                else
                {
                    Field.setX(btn.X, btn.Y);
                    turn = XOEnum.O;
                }
            }

            Grid grid = getGrid(btn.X, btn.Y);

            btn.Content = grid;

        }

        /// <summary>
        /// возвращает грид с крестиком или ниликом
        /// </summary>
        /// <returns></returns>
        Grid getGrid(int i, int j)
        {
            Grid grid = new Grid();

            if (Field.getXorO(i, j) == XOEnum.O)
            {
                grid.Children.Add(XOObject.getO());
            }
            else
                foreach (var item in XOObject.getX())
                {
                    grid.Children.Add(item);
                }

            return grid;
        }
    }
}
