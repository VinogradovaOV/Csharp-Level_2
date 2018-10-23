using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFSample1
{
    /// <summary>
    /// Главное окно игры Астероиды
    /// </summary>
    public partial class Form1 : Form
    {
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
            Game.Init(this);
            lblMyname.Text = String.Empty;
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
