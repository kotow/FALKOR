using OOP_TeamWork;
using OOP_TeamWork.Interfaces;
using OOP_TeamWork.UI;
using System;
using System.Windows.Forms;

namespace WorkshopGame.UI
{
    partial class GameWindow : Form
    {
        public const int TimeInterval = 150;

        public GameWindow()
        {
            InitializeComponent();
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

