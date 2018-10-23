using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFSample2
{
    /// <summary>
    /// Главное окно игры Астероиды
    /// </summary>
    public partial class Form1 : Form
    {
        public bool start = true;
        /// <summary>
        /// Главное окно игры Астероиды
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            lblMyname.Text = "Разработчик игры Виноградова О.В.";
        }

        /// <summary>
        /// Старт Игры
        /// </summary>
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            if (start)
            {
                Game.Init(this);
                lblMyname.Text = String.Empty;
                start = false;
            }
            else Loads.Load();

        }

        /// <summary>
        /// Рекорды игры
        /// </summary>
        private void btnRecords_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Выход из игры
        /// </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
