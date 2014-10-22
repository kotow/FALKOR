using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public abstract class Object : IDrawable
    {
        private int positionX;
        private int positionY;
        private int width;
        private int height;

        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int PositionY
        {
            get { return positionY; }
            set 
            {
                if (value < 0)
                {
                    value = 0;
                }
                positionY = value; 
            }
        }
        
        public int PositionX
        {
            get { return positionX; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                positionX = value; 
            }
        }

        public void Draw()
        {
            //TODO
        }

        public Object(int x, int y, int width, int height)
        {
            this.PositionX = x;
            this.PositionY = y;
            this.Width = width;
            this.Height = height;
        }

        public SpriteType SpriteType { get; set; }

        public void AddObject(IDrawable objectToBeDrawn)
        {
            //TODO
        }

        public void RemoveObject(IDrawable objectToBeRemoved)
        {
            //TODO
        }

        public void RedrawObject(IDrawable objectToBeRedrawn)
        {
            //TODO
        }
    }
}
