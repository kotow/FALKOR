using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public class Shield :Item
    {
        private const int shieldBonus = 50;
        public Shield(int x, int y)
            : base(x, y, 30, 30)
        {
            this.bonusHealth = 0;
            this.bonusAttack = 0;
            this.bonusDeffense = shieldBonus;
            this.SpriteType = SpriteType.Shield;
        }
    }
}
