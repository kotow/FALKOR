namespace OOP_TeamWork
{
    public class Assassin : Hero
    {
        private const int assassinHealth = 100;
        private const int assassinAtack = 100;
        private const int assassinDefense = 100;

        public Assassin(int x, int y)
            : base(x, y, 50, 50, assassinHealth, assassinAtack, assassinDefense)
        {
            //image
        }
    }
}
