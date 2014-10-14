using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public class Wall : Object
    {
        public Wall(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.SpriteType = SpriteType.Wall;
        }
    }
}
