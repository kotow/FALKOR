﻿using OOP_TeamWork.Structure;
namespace OOP_TeamWork
{
    public abstract class Item : Object
    {
        public int bonusHealth;
        public int bonusAttack;
        public int bonusDeffense;
        public bool isUsed = false;
        public Item(int x, int y, int width, int height) : base(x, y, 30, 30)
        {

        }
    }
}
