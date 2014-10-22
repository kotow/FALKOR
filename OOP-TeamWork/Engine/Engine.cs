using OOP_TeamWork;
using OOP_TeamWork.Interfaces;
using System;
using System.Collections.Generic;
namespace OOP_TeamWork
{
    public class Engine
    {
        private IDrawable painter;
        private List<Unit> unitList;
        private List<Item> itemList;
        private Unit player;
        private int interval;

        public Engine(IKeyboardControlable controller, IDrawable painter,
            int loopInterval)
        {
            this.interval = loopInterval;
            this.unitList = new List<Unit>();
            this.itemList = new List<Item>();
            this.SubscribeToUserInput(controller);
            this.InitializeCharacters();
            this.InitializeItems();
            this.painter = painter;
            foreach (var item in itemList)
            {
                this.painter.AddObject(item);
            }
            foreach (var unit in unitList)
            {
                this.painter.AddObject(unit);
            }
        }

        public void PlayNextTurn()
        {
            this.hasCollision();
            this.ProcessUnits();
            this.RedrawAll();
        }

        private void RedrawAll()
        {
            foreach (var unit in this.unitList)
            {
                this.painter.RedrawObject(unit);
            }
            foreach (var item in this.itemList)
            {
                this.painter.RedrawObject(item);
            }
        }

        private void ProcessUnits()
        {
            foreach (var unit in unitList)
            {
                if (unit is Monster)
                {
                    (unit as Monster).MonsterRandomMovement();
                }
                if (!unit.IsAlive)
                {
                    if (unit is Hero)
                    {
                        throw new Exception("Game Over!");
                    }
                    this.painter.RemoveObject(unit);
                    this.unitList.Remove(unit);
                }
            } 
            this.unitList.RemoveAll(x => !x.IsAlive);
        }

        private void hasCollision()
        {
            bool collision = false;
            foreach (var unit in this.unitList)
            {
                var inRangeX = (
                    (unit.PositionX < (this.player.PositionX+this.player.Width)) &&
                    ((unit.PositionX+unit.Width) > player.PositionX));
                var inRangeY = (
                    (unit.PositionY < (this.player.PositionY + this.player.Height)) &&
                    ((unit.PositionY + unit.Height) > player.PositionY));

                if (inRangeX && inRangeY && !(unit is Hero))
                {
                    collision = true;
                }
                if (collision)
                {
                    this.player.AttackEnemy(unit);
                    unit.AttackEnemy(player);
                }
            }
            bool collisionItem = false;
            foreach (var item in this.itemList)
            {
                var inRangeX = (
                    (item.PositionX < (this.player.PositionX + this.player.Width)) &&
                    ((item.PositionX + item.Width) > player.PositionX));
                var inRangeY = (
                    (item.PositionY < (this.player.PositionY + this.player.Height)) &&
                    ((item.PositionY + item.Height) > player.PositionY));

                if (inRangeX && inRangeY)
                {
                    collisionItem = true;
                }
                if (collisionItem)
                {
                    (this.player as Hero).TakeItem(item);
                    this.painter.RemoveObject(item);
                    this.itemList.Remove(item);
                }
            }
        }

        //private void CheckColosionType(IKeyboardControlable player, List<Unit> units)
        //{
        //    if (hasCollision())
        //    {

        //    }
        //}
        private void InitializeCharacters()
        {
            var playerCharacter = new Mage(100, 100);
            player = playerCharacter;
            unitList.Add(new BlackMonster(500, 50));
            unitList.Add(new BlueMonster(300, 150));
            unitList.Add(new BlackMonster(500, 50));
            unitList.Add(new BlueMonster(300, 150));
            unitList.Add(new BlackMonster(500, 50));
            unitList.Add(new BlueMonster(300, 150));
            unitList.Add(new BlackMonster(500, 50));
            unitList.Add(new BlueMonster(300, 150));
            unitList.Add(player);
        }
        private void InitializeItems()
        {
            itemList.Add(new Weapon(0, 0));
            itemList.Add(new HealingPoition(30, 150));
            itemList.Add(new Shield(100, 10));
        }

        private void MovePlayerRight()
        {
            this.player.Move(1, 0); ;
        }

        private void MovePlayerDown()
        {
            this.player.Move(0, 1);
        }

        private void MovePlayerUp()
        {
            this.player.Move(0, -1);
        }

        private void MovePlayerLeft()
        {
            this.player.Move(-1, 0);
        }

        private void SubscribeToUserInput(IKeyboardControlable userInteface)
        {
            userInteface.OnUpPressed += (sender, args) =>
            {
                this.MovePlayerUp();
            };
            userInteface.OnDownPressed += (sender, args) =>
            {
                this.MovePlayerDown();
            };
            userInteface.OnLeftPressed += (sender, args) =>
            {
                this.MovePlayerLeft();
            };
            userInteface.OnRightPressed += (sender, args) =>
            {
                this.MovePlayerRight();
            };
        }
    }
}
