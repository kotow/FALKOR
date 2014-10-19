using System;

namespace OOP_TeamWork
{
    public abstract class Monster : Unit
    {
        public Monster(int x, int y, int width, int height, int health, int atack, int defense)
            : base(x, y, 50, 50, health, atack, defense)
        {
        }


        private static Random random = new Random();
        private static int direction = random.Next(1, 5); // creates a number between 1 and 4
        bool hasConflict = false;
        bool hasWall = false;

        public void MonsterRandomMovement()
        {
            if (hasConflict == false)
            {
                direction = random.Next(1, 5); // creates a number between 1 and 4

                if (direction == 1)
                {
                    this.MoveMonsterRight();
                    if (hasWall == true)
                    {
                        hasConflict = true;
                        hasConflict = false;
                    }
                }

                else if (direction == 2)
                {
                    this.MoveMonsterDown();
                    if (hasWall == true)
                    {
                        hasConflict = true;
                        hasConflict = false;
                    }
                }

                else if (direction == 3)
                {
                    this.MoveMonsterLeft();
                    if (hasWall == true)
                    {
                        hasConflict = true;
                        hasConflict = false;
                    }
                }

                else if (direction == 4)
                {
                    this.MoveMonsterUp();
                    if (hasWall == true)
                    {
                        hasConflict = true;
                        hasConflict = false;
                    }
                }
            }
        }

        private void MoveMonsterRight()
        {
            this.Move(10, 0);
        }

        private void MoveMonsterDown()
        {
            this.Move(0, 10);
        }

        private void MoveMonsterUp()
        {
            this.Move(0, -10);
        }

        private void MoveMonsterLeft()
        {
            this.Move(-10, 0);
        }
    }
}
