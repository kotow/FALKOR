namespace OOP_TeamWork
{
    using OOP_TeamWork.Interfaces;
    using System;
    using System.Windows.Forms;
    public abstract class Hero : Unit, IKeyboardControlable
    {
        public Hero(int x, int y, int width, int height, int health, int atack, int defense)
            : base(x, y, width, height, health, atack, defense)
        {
        }

        public void TakeItem(Item item)
        {
            this.CurrentHealth += item.bonusHealth;
            this.attack += item.bonusAttack;
            this.defense += item.bonusDeffense;
        }

        public event EventHandler OnRightPressed;

        public event EventHandler OnLeftPressed;

        public event EventHandler OnUpPressed;

        public event EventHandler OnDownPressed;
        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (this.OnUpPressed != null)
                    {
                        this.OnUpPressed(this, new EventArgs());
                    }
                    break;
                case Keys.D:
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new EventArgs());
                    }
                    break;
                case Keys.S:
                    if (this.OnDownPressed != null)
                    {
                        this.OnDownPressed(this, new EventArgs());
                    }
                    break;
                case Keys.A:
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new EventArgs());
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
