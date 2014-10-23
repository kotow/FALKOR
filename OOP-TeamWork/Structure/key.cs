using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public class Key : Item
    {
        public Key(int x, int y) : base(x, y, 30, 30)
        {
            this.bonusHealth = 0;
            this.bonusAttack = 0;
            this.bonusDeffense = 0;
            this.SpriteType = SpriteType.Key;
        }
    }
}
