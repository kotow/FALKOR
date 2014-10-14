using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public interface IDrawable
    {
        int PositionX { get; set; }
        int PositionY { get; set; }
        int Width { get; set;  }
        int Height { get; set; }
        void Draw();

        SpriteType SpriteType { get; set; }

        void AddObject(IDrawable objectToBeDrawn);

        void RemoveObject(IDrawable objectToBeRemoved);

        void RedrawObject(IDrawable objectToBeRedrawn);
    }
}
