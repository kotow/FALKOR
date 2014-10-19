namespace OOP_TeamWork.UI
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    class Maze
    {
        const int UP = 1;
        const int LEFT = 2;
        const int RIGHT = 4;
        const int DOWN = 8;

        int[,] maze;
        int rows;
        int cols;
        int unused;

        public Maze(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;

            maze = new int[cols, rows];

            for (int i = 0; i < cols; ++i)
                for (int j = 0; j < rows; ++j)
                    maze[i, j] = 0;

            maze[0, 0] = DOWN | RIGHT;
            maze[cols - 1, 0] = DOWN | LEFT;
            maze[0, rows - 1] = UP | RIGHT;
            maze[cols - 1, rows - 1] = UP | LEFT;

            for (int i = 1; i < rows - 1; ++i)
            {
                maze[0, i] = DOWN | UP;
                maze[cols - 1, i] = DOWN | UP;
            }
            for (int i = 1; i < cols - 1; ++i)
            {
                maze[i, 0] = LEFT | RIGHT;
                maze[i, rows - 1] = LEFT | RIGHT;
            }

            maze[cols / 2, 0] = UP | LEFT;
            maze[cols / 2 + 1, 0] = UP | RIGHT;
            maze[cols / 2, rows - 1] = DOWN | LEFT;
            maze[cols / 2 + 1, rows - 1] = DOWN | RIGHT;

            unused = (cols - 2) * (rows - 2);

            Generate();
            Draw();
        }

        Bitmap image;
        Graphics graphics;

        void Draw()
        {
            const int CELLSIZE = 30;

            int xsize = cols * CELLSIZE;
            int ysize = rows * CELLSIZE;

            image = new Bitmap(xsize, ysize);
            graphics = Graphics.FromImage(image);

            graphics.Clear(Color.DarkBlue);

            Pen pen = new Pen(Color.Yellow);

            for (int i = 0; i < cols; ++i)
                for (int j = 0; j < rows; ++j)
                {
                    int room = maze[i, j];
                    if ((room & UP) != 0)
                        graphics.DrawLine(pen,
                                  i * CELLSIZE + CELLSIZE / 2,
                                  j * CELLSIZE,
                                  i * CELLSIZE + CELLSIZE / 2,
                                  j * CELLSIZE + CELLSIZE / 2 - 1);
                    if ((room & DOWN) != 0)
                        graphics.DrawLine(pen,
                                  i * CELLSIZE + CELLSIZE / 2,
                                  j * CELLSIZE + CELLSIZE / 2,
                                  i * CELLSIZE + CELLSIZE / 2,
                                  j * CELLSIZE + CELLSIZE - 1);
                    if ((room & RIGHT) != 0)
                        graphics.DrawLine(pen,
                                  i * CELLSIZE + CELLSIZE / 2,
                                  j * CELLSIZE + CELLSIZE / 2,
                                  i * CELLSIZE + CELLSIZE - 1,
                                  j * CELLSIZE + CELLSIZE / 2);
                    if ((room & LEFT) != 0)
                        graphics.DrawLine(pen,
                                  i * CELLSIZE,
                                  j * CELLSIZE + CELLSIZE / 2,
                                  i * CELLSIZE + CELLSIZE / 2 - 1,
                                  j * CELLSIZE + CELLSIZE / 2);
                }
        }

        public void Paint(Graphics g, int x, int y)
        {
            g.DrawImage(image, x, y);
        }

        void Generate()
        {

            const int Nsave = 20;
            int[] prevNdir = new int[Nsave];

            int[,] moveTable = { { 0, -1 }, { -1, 0 }, { 1, 0 }, { 0, 1 } };

            int curx, cury;

            Random random = new Random();

            while (unused > 0)
            {

                do
                {
                    curx = random.Next(cols);
                    cury = random.Next(rows);
                } while (maze[curx, cury] != 0);

                for (int i = 0; i < Nsave; ++i)
                    prevNdir[i] = 0;
                --unused;

                for (; ; )
                {
                    int dir;

                    for (int i = 0; i < Nsave - 1; ++i)
                        prevNdir[i] = prevNdir[i + 1];

                    bool[] gotdir = new bool[4];

                    do
                    {
                        do
                        {
                            dir = random.Next(4);
                        } while (dir == (prevNdir[Nsave - 2] ^ 3));
                        prevNdir[Nsave - 1] = dir;

                        for (int i = 0; i < 4; ++i)
                            gotdir[i] = false;
                        for (int i = 0; i < Nsave; ++i)
                            gotdir[prevNdir[i]] = true;

                    } while (gotdir[0] && gotdir[1] && gotdir[2] && gotdir[3]);

                    maze[curx, cury] |= (1 << dir);

                    curx += moveTable[dir, 0];
                    cury += moveTable[dir, 1];

                    bool exitcond = (maze[curx, cury] != 0);

                    maze[curx, cury] |= (1 << (dir ^ 3));

                    if (exitcond)
                        break;

                    --unused;
                }
            }
        }
    }
}
