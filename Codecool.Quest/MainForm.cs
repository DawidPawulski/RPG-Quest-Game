using Codecool.Quest.Models;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System;

namespace Codecool.Quest {
    public partial class MainForm : Form {
        GameMap map = MapLoader.LoadMap(@"\Resources\map.txt");
        int mapNumber = 0;
        Thread th = null;
        Thread th2 = null;


        public void StartNewThreads()
        {
            th = new Thread(() => {
                int i = 0;
                bool isRunning = true;
                while (isRunning)
                {
                    Thread.Sleep(100);
                    if (map.mapChanging)
                    {
                        int tempHealth = map.Player.Health;
                        int tempAttack = map.Player.Attack;
                        int tempDefense = map.Player.Defense;
                        mapNumber = map.num;
                        string currentLevel = map.changeMapLevel(mapNumber);
                        map = MapLoader.LoadMap(currentLevel);
                        map.mapChanging = false;
                        map.StartMobs();
                        map.Player.Health = tempHealth;
                        map.Player.Attack = tempAttack;
                        map.Player.Defense = tempDefense;
                    }
                    if (!this.Disposing)
                    {
                        try
                        {
                            Invoke((Action)(() => Refresh()));
                            Invoke((Action)(() => label13.Text = $"Attack {map.Player.Attack.ToString()}"));
                            Invoke((Action)(() => label12.Text = $"Defence {map.Player.Defense.ToString()}"));
                            

                        }
                        catch (Exception ex)
                        {
                            var x = this;
                            isRunning = false;
                        }
                    }



                }

            });
            th2 = new Thread(() =>
            {
                while (true)
                {

                    map.MoveMobs();
                    var state = th2.ThreadState;
                    if (state == ThreadState.AbortRequested)
                    {
                        break;
                    }
                }
            });
            th.Start();
            th2.Start();
        }

        public MainForm() {



            InitializeComponent();
            
            Launch();
            

        }

        public void Launch() {
            Refresh();
            

        }


        private void MainForm_KeyDown(object sender, KeyEventArgs e) {
            if (th.IsAlive)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        map.Player.Move(-1, 0);
                        Refresh();
                        tableLayoutPanel1.Refresh();

                        break;
                    case Keys.Up:
                        map.Player.Move(0, -1);
                        Refresh();
                        tableLayoutPanel1.Refresh();
                        break;
                    case Keys.Right:
                        map.Player.Move(1, 0);
                        Refresh();
                        tableLayoutPanel1.Refresh();
                        break;
                    case Keys.Down:
                        map.Player.Move(0, 1);
                        Refresh();
                        tableLayoutPanel1.Refresh();
                        break;
                }
            

            }
        }



        private void MainForm_Load(object sender, System.EventArgs e)
        {

        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

            Inventory inventory = map.inventory;
            Dictionary<string, Tiles.Tile> tiles = new Dictionary<string, Tiles.Tile>();
            tiles = Tiles.tileMap;
            PictureBox[] boxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8 };
            Label[] labels = { label2, label3, label4, label5, label6, label7, label8, label9 };
            label1.Text = "Health " + map.Player.Health.ToString();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = map.Player.maxHealth;
            if(map.Player.Health <= 0)
            {
                map.Player.Health = 0;
                map.Player.isAlive = false;
                th.Abort();
                th2.Abort();
                label11.Visible = true;
            }
            if (map.Player.gameWin)
            {
                label15.Visible = true;
                th2.Abort();
                th.Abort();
            }
            progressBar1.Value = map.Player.Health;
            int i = 0;
            foreach(KeyValuePair<string, int> pair in inventory.playerInventory)
            {
                Image image = tiles[pair.Key].bitmap;
                boxes[i].Width = 48;
                boxes[i].Height = 48;
                boxes[i].Image = image;
                
                labels[i].Text = " x " + pair.Value.ToString();
                labels[i].Visible = true;
                i++;
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);
            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    Cell cell = map.GetCell(x, y);
                    if (cell.Actor != null)
                    {
                        Tiles.DrawTile(e.Graphics, cell.Actor, x, y);
                    }
                    else
                    {
                        Tiles.DrawTile(e.Graphics, cell, x, y);
                    }
                }
            }
           
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, System.EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, System.EventArgs e)
        {

        }

        private void label10_Click(object sender, System.EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            th.Abort();
            th2.Abort();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string playerName = textBox1.Text;
            if (map.Player.CheckName(playerName))
            {
                progressBar1.Visible = false;
                label12.Visible = false;
                label1.Visible = false;
            }
            label10.Visible = false;
            textBox1.Visible = false;
            button1.Visible = false;
            StartNewThreads();
            map.StartMobs();
            label14.Text += playerName;
            this.Focus();
            this.Select();
        }




        // TODO draw inventory tiles itterating through inventory dictionary and add some kind of boarder
    }
}
