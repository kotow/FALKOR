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

        public void AttackEnemy(Unit enemy)
        {
            if (this.attack > enemy.defense)
            {
                enemy.CurrentHealth -= this.attack - enemy.defense;
            }
        }

        private int currentHealth = 50;
        private bool isAlive = true;
        public bool IsAlive 
        {
            get 
            {
                return this.isAlive; 
            }
            set 
            {
                if (CurrentHealth <= 0) 
                {
                    this.isAlive = false; 
                }
                else 
                {
                    this.isAlive = true;
                }
            }
        }
        public int CurrentHealth
        {
            get
            {
                return this.currentHealth;
            }
            set
            {
                if (value < 0)
                {
                    this.currentHealth = 0;
                    this.isAlive = false;
                }
                else
                {
                    this.currentHealth = value;
                }
            }
        }
    }
}
