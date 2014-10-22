using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public class Wall : Object, IDrawable
    {
        public Wall(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            this.SpriteType = SpriteType.Wall;
        }

        public Wall(int x, int y) : base(x, y, 30, 30)
        {
            // TODO: Complete member initialization
        }
    }
}
