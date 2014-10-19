using System;

namespace OOP_TeamWork
{
    public abstract class Monster : Unit
    {
        public Monster(int x, int y, int width, int height, int health, int atack, int defense)
            : base(x, y, width, height, health, atack, defense)
        {
        }


        Random random = new Random();
        int direction = random.Next(1, 5); // creates a number between 1 and 4
        bool hasConflict = false;
        bool hasWall = false;

        private void MonsterRandomMovement(int direction)
        {
            while (true)
                if (hasConflict = false)
                {
                    if (direction == 1)
                    {
                        this.MoveMonsterRight();
                        if (hasWall == true)
                        {
                            hasConflict = true;
                            Random random = new Random();
                            direction = random.Next(1, 5); // creates a number between 1 and 4
                            hasConflict = false;
                        }
                    }

                    else if (direction == 2)
                    {
                        this.MoveMonsterDown();
                        if (hasWall == true)
                        {
                            hasConflict = true;
                            Random random = new Random();
                            direction = random.Next(1, 5); // creates a number between 1 and 4
                            hasConflict = false;
                        }
                    }

                    else if (direction == 3)
                    {
                        this.MoveMonsterLeft();
                        if (hasWall == true)
                        {
                            hasConflict = true;
                            Random random = new Random();
                            direction = random.Next(1, 5); // creates a number between 1 and 4
                            hasConflict = false;
                        }
                    }

                    else  if (direction == 4)
                    {
                        this.MoveMonsterUp();
                        if (hasWall == true)
                        {
                            hasConflict = true;
                            Random random = new Random();
                            direction = random.Next(1, 5); // creates a number between 1 and 4
                            hasConflict = false;
                        }
                    }
                }
        }

        private Unit monster;
        private void MoveMonsterRight()
        {
            this.monster.Move(1, 0); ;
        }

        private void MoveMonsterDown()
        {
            this.monster.Move(0, 1);
        }

        private void MoveMonsterUp()
        {
            this.monster.Move(0, -1);
        }

        private void MoveMonsterLeft()
        {
            this.monster.Move(-1, 0);
        }
    }
}
