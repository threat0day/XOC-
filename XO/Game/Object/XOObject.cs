using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace XO.Game.Object
{
    public static class XOObject
    {
        public static List<UIElement> getX()
        {
            List<UIElement> list = new List<UIElement> ();
            Line lineL = new Line()
            {
                X1 = 70,
                Y1 = 0,
                X2 = 0,
                Y2 = 110,
                Stroke = new SolidColorBrush(Colors.Black)
            };
            Line lineR = new Line()
            {
                X1 = 0,
                Y1 = 0,
                X2 = 90,
                Y2 = 150,
                Stroke = new SolidColorBrush(Colors.Black)
            };

            list.Add(lineL);
            list.Add(lineR);

            return list;
        }

        public static Ellipse getO()
        {
            Ellipse elipce = new Ellipse()
            {
                Width = 70,
                Height = 100,
                Stroke = new SolidColorBrush(Colors.Black)
            };
            return elipce;
        }
    }
}
