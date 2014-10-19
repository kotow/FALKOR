using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public class BlackMonster : Monster
    {
        private const int monsterHealth = 100;
        private const int monsterAtack = 100;
        private const int monsterDefense = 100;
        public BlackMonster(int x, int y)
            : base(x, y, 50, 50, monsterHealth, monsterAtack, monsterDefense)
        {
            this.SpriteType = SpriteType.BlackMonster;
        }
    }
}
