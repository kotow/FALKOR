using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public class HealingPoition : Item
    {
        private const int healingPoitionBonus = 50;
        public HealingPoition(int x, int y) : base(x, y, 30, 30)
        {
            this.bonusHealth = healingPoitionBonus;
            this.bonusAttack = 0;
            this.bonusDeffense = 0;
            this.SpriteType = SpriteType.HealnigPoition;
        }
    }
}
