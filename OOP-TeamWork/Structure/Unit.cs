namespace OOP_TeamWork
{
    public abstract class Unit : Object, IMovable
    {
        public int health;
        protected int attack;
        protected int defense;
        public bool hasWall = false;


        public Unit(int x, int y, int width, int height, int health, int attack, int defense)
            : base(x, y, width, height)
        {
            this.health = health;
            this.attack = attack;
            this.defense = defense;
        }

        public void Move(int x, int y)
        {
            this.UnitPositionX += x;
            this.UnitPositionY += y;
        }

        public void AttackEnemy(Unit enemy)
        {
            if (this.attack > enemy.defense)
            {
                enemy.CurrentHealth -= this.attack - enemy.defense;
            }
        }

        private int currentHealth = 100;
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
                else if (value > health)
                {
                    this.currentHealth = health;
                } 
               else
                {
                    this.currentHealth = value;
                }
            }
        }
        public int UnitPositionY
        {
            get { return this.positionY; }
            set
            {
                if (value < 30 || value > 520)
                {
                    value = positionY;
                }
                positionY = value;
            }
        }

        public int UnitPositionX
        {
            get { return positionX; }
            set
            {
                if (value < 30 || value > 1120)
                {
                    value = positionX;
                }
                positionX = value;
            }
        }

    }
}
