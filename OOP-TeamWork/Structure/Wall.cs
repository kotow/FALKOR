using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public class Wall : Object
    {
        public Wall(int x, int y)
            : base(x, y, 30, 30)
        {
            this.SpriteType = SpriteType.Wall;
        }
    }
}
