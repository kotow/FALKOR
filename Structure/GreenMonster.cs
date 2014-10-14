using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public class BlueMonster : Monster
    {
        private const int monsterHealth = 100;
        private const int monsterAtack = 100;
        private const int monsterDefense = 100;
        public BlueMonster(int x, int y, int width, int height)
            : base(x, y, width, height, monsterHealth, monsterAtack, monsterDefense)
        {
            this.SpriteType = SpriteType.BlueMonster;
        }
    }
}
