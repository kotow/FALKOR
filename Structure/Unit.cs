namespace OOP_TeamWork
{
    public abstract class Unit : Object, IMovable
    {
        public int health;
        protected int attack;
        protected int defense;

        public Unit(int x, int y, int width, int height, int health, int attack, int defense) 
            : base(x, y, width, height)
        {
            this.health = health;
            this.attack = attack;
            this.defense = defense;
        }

        public void Move(int x, int y)
        {
            this.PositionX += x;
            this.PositionY += y;
        }

        public void AttackEnemy()
        {
            //TODO
        }

        public bool IsAlive = true;
    }
}
