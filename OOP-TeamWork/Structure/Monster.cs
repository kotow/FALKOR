namespace OOP_TeamWork
{
    public abstract class Monster : Unit
    {
        public Monster(int x, int y, int width, int height, int health, int atack, int defense)
            : base(x, y, width, height, health, atack, defense)
        {
        }
    }
}
