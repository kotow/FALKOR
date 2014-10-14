using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public class Mage : Hero
    {
        private const int mageHealth = 100;
        private const int mageAtack = 100;
        private const int mageDefense = 100;
     
        public Mage(int x, int y, int width, int height)
            : base(x, y, width, height, mageHealth, mageAtack, mageDefense)
        {
            this.SpriteType = SpriteType.Mage;
        }
    }
}
