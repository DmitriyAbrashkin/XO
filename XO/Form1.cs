using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO
{
    public partial class Form1 : Form
    {
        Feld GameFeld;
        Cell[,] cells = new Cell[3, 3];
        bool Step = true;
        int ChetX = 0;
        int ChetO = 0;


        public Form1()
        {
            InitializeComponent();
            GameFeld = new Feld();
            Render();
        }

        private void Render()
        {
            const int ButtonWidth = 250;
            const int ButtonHeight = 250;
            label3.Text = Convert.ToString(ChetX);
            label2.Text = Convert.ToString(ChetO);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Button pB = new Button();
                    pB.Width = ButtonWidth;
                    pB.Height = ButtonHeight;
                    pB.Location = new Point(i * 100, j * 100);
                    pB.Parent = tableLayoutPanel1;
                    pB.Tag = GameFeld.Cells[i, j];
                    pB.Click += h_onPBOnClick;
                    cells[i, j] = GameFeld.Cells[i, j];
                    cells[i, j].Status = CellStatus.Unclick;
                    pB.Text = "";
                }

            }
        }

        private void h_onPBOnClick(object sender, EventArgs e)
        {
            Button btn = (sender as Button);
            if (btn.Text.Length == 0)
            {
                var pO = btn.Tag;
                var pF = pO as Cell;
                btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));

                #region Смена хода и отрисовка
                if (Step)
                {
                    btn.Text = "X";
                    Step = false;
                    pF.Status = CellStatus.Cross;
                }
                else
                {
                    btn.Text = "0";
                    Step = true;
                    pF.Status = CellStatus.Zero;
                }
                #endregion

                #region Проверка конца игры
                if (GameFeld.EndGame(cells) == CellStatus.Cross)
                {
                    MessageBox.Show("Игра окончена, победили X");
                    ChetX++;
                    label3.Text = Convert.ToString(ChetX);
                    tableLayoutPanel1.Controls.Clear();
                    Render();
                    this.Refresh();
                }
                else
                if (GameFeld.EndGame(cells) == CellStatus.Zero)
                {
                    MessageBox.Show("Игра окончена, победили 0");
                    ChetO++;
                    label2.Text = Convert.ToString(ChetO);
                    tableLayoutPanel1.Controls.Clear();
                    Render();
                    this.Refresh();

                }
                else
                if(GameFeld.EndGame(cells) == CellStatus.Fall)
                {
                    MessageBox.Show("Игра окончена, ничья");
                    tableLayoutPanel1.Controls.Clear();
                    Render();
                    this.Refresh();

                }
                #endregion

            }

        }

      
    }
}
