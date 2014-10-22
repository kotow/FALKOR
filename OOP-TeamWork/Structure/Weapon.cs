using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public class Weapon : Item
    {
       private const int weaponBonus = 10;
       public Weapon(int x, int y)
           : base(x, y, 30, 30)
        {
            this.bonusHealth = 0;
            this.bonusAttack = weaponBonus;
            this.bonusDeffense = 0;
            this.SpriteType = SpriteType.Weapon;
        }
    }
}
