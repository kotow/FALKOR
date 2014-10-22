using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public class Mage : Hero
    {
        private const int mageHealth = 100;
        private const int mageAtack = 120;
        private const int mageDefense = 100;
     
        public Mage(int x, int y)
            : base(x, y, 50, 50, mageHealth, mageAtack, mageDefense)
        {
            this.SpriteType = SpriteType.Mage;
        }
    }
}
