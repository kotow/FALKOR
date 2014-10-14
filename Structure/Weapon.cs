using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public class Weapon : Item
    {
       private const int weaponBonus = 50;
       public Weapon(int x, int y, int width, int height)
           : base(x, y, width, height)
        {
            this.bonusHealth = 0;
            this.bonusAttack = weaponBonus;
            this.bonusDeffense = 0;
            this.SpriteType = SpriteType.Weapon;
        }
    }
}
