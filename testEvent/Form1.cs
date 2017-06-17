using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testEvent
{
    public partial class Form1 : Form
    {
        public MyEvent evnt;
        public Form1()
        {
            InitializeComponent();
            evnt = new MyEvent();

        }

        public void GameOver()
        {
            MessageBox.Show("11111");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            evnt.gameOver += GameOver;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            evnt.gameOver -= GameOver;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            evnt.onGameOver();
        }
    }

    public delegate void eventAny();
    public class MyEvent
    {
        public event eventAny gameOver;
        public void onGameOver()
        {
            gameOver?.Invoke();
        }
    }
}
