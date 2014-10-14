namespace OOP_TeamWork
{
    using OOP_TeamWork.Interfaces;
    using System;
    public abstract class Hero : Unit, IKeyboardControlable
    {
        public Hero(int x, int y, int width, int height, int health, int atack, int defense)
            : base(x, y, width, height, health, atack, defense)
        {
        }

        public void TakeItem(Item item)
        {
            this.health += item.bonusHealth;
            this.attack += item.bonusAttack;
            this.defense += item.bonusDeffense;
        }

        public event EventHandler OnRightPressed;

        public event EventHandler OnLeftPressed;

        public event EventHandler OnUpPressed;

        public event EventHandler OnDownPressed;
    }
}
