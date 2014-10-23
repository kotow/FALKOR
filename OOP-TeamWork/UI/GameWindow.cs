using OOP_TeamWork;
using OOP_TeamWork.Interfaces;
using OOP_TeamWork.UI;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WorkshopGame.UI
{
    partial class GameWindow : Form
    {
        public const int TimeInterval = 150;
        const int TopMargin = 30;

        Maze maze = null;

        public GameWindow()
        {
            InitializeComponent();

            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(784, 406);
            this.Name = "MazeGen";
            this.ResumeLayout(false);
        //   Text = "FALCON GAME";
        //   Name = "FALCON GAME";

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            ClientSize = new Size(1200, 600);
            go_Click(null, null);
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            IKeyboardControlable controller = new KeyboardController(this);
            IDrawable painter = new PaintBrush(this);
            Engine engine = new Engine(controller, painter, TimeInterval);

            Timer timer = new Timer();
            timer.Interval = TimeInterval;
            timer.Tick += (s, args) =>
            {
                engine.PlayNextTurn();
            };

            timer.Start();
        }

        void go_Click(object o, EventArgs e)
        {
            int rows;
            int cols;
            try
            {
                rows = int.Parse("10");
                cols = int.Parse("20");
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid numeric value entered.");
                return;
            }

            const int LowerBound = 10;
            const int UpperBound = 300;

            if (rows < LowerBound || cols < LowerBound)
            {
                MessageBox.Show("Out of range\nNumber of rows and columns " +
                        "must be at least " + LowerBound.ToString());
                return;
            }

            if (rows > UpperBound || cols > UpperBound)
            {
                MessageBox.Show("Out of range\nNumber of rows and columns " +
                        "must be below " + UpperBound.ToString());
                return;
            }

            maze = new Maze(rows, cols);

            Invalidate();
            Update();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Wall wall = new Wall(100, 100);
            wall.Draw();
            if (maze != null)
                maze.Paint(e.Graphics, 0, 0);
        }
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(784, 406);
            this.Name = "GameWindow";
            this.Text = "RPG Game";
            this.Load += new System.EventHandler(this.GameWindow_Load);
            this.ResumeLayout(false);

        }



        #endregion







    }
}

