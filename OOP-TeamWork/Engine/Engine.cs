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
        private List<Wall> wallList;
        private Unit player;
        private int interval;

        public Engine(IKeyboardControlable controller, IDrawable painter,
            int loopInterval)
        {
            this.interval = loopInterval;
            this.unitList = new List<Unit>();
            this.itemList = new List<Item>();
            this.wallList = new List<Wall>();
            this.SubscribeToUserInput(controller);
            this.InitializeCharacters();
            this.InitializeItems();
            this.InitializeWalls();
            this.painter = painter;
            foreach (var item in itemList)
            {
                this.painter.AddObject(item);
            }
            foreach (var unit in unitList)
            {
                this.painter.AddObject(unit);
            }
            foreach (var wall in wallList)
            {
                this.painter.AddObject(wall);
            }
        }

        public void PlayNextTurn()
        {
            this.Process();
            this.hasCollision();
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

        private void Process()
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
                    //this.unitList.Remove(unit);
                }
            }
            foreach (var item in itemList)
            {
                if (item.isUsed)
                {
                    this.painter.RemoveObject(item);
                }
            }
            this.unitList.RemoveAll(x => !x.IsAlive);
            this.itemList.RemoveAll(item => item.isUsed);
        }

        private void hasCollision()
        {
            
            foreach (var unit in this.unitList)
            {
                int atackRange = 20;
                bool collision = false;
                var inRangeX = (
                    (unit.UnitPositionX < (this.player.UnitPositionX+this.player.Width + atackRange)) &&
                    ((unit.UnitPositionX + unit.Width) > player.UnitPositionX - atackRange));
                var inRangeY = (
                    (unit.UnitPositionY < (this.player.UnitPositionY + this.player.Height + atackRange)) &&
                    ((unit.UnitPositionY + unit.Height) > player.UnitPositionY - atackRange));

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
           
            foreach (var item in this.itemList)
            {
                bool collisionItem = false;
                var inRangeX = (
                    (item.PositionX < (this.player.UnitPositionX + this.player.Width)) &&
                    ((item.PositionX + item.Width) > player.UnitPositionX));
                var inRangeY = (
                    (item.PositionY < (this.player.UnitPositionY + this.player.Height)) &&
                    ((item.PositionY + item.Height) > player.UnitPositionY));

                if (inRangeX && inRangeY)
                {
                    collisionItem = true;
                }
                if (collisionItem)
                {
                    (this.player as Hero).TakeItem(item);
                }
            }
            foreach (var unit in unitList)
            {
                foreach (var wall in wallList)
                {
                    var inRangeX = (
                        (wall.PositionX < (unit.UnitPositionX + unit.Width)) &&
                        ((wall.PositionX + wall.Width) > unit.UnitPositionX));
                    var inRangeY = (
                        (wall.PositionY < (unit.UnitPositionY + unit.Height)) &&
                        ((wall.PositionY + wall.Height) > unit.UnitPositionY));

                    if (inRangeX && inRangeY)
                    {
                        unit.hasWall = true;
                    }    
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
            var playerCharacter = new Mage(635, 510);
            player = playerCharacter;
            unitList.Add(new BlackMonster(500, 50));
            unitList.Add(new BlueMonster(300, 150));
            unitList.Add(new BlackMonster(500, 50));
            unitList.Add(new BlueMonster(300, 150));
            unitList.Add(new BlackMonster(500, 50));
            unitList.Add(new BlueMonster(300, 150));
            unitList.Add(new BlackMonster(500, 50));
            unitList.Add(new BlueMonster(300, 150));
            unitList.Add(new BlackMonster(800, 450));
            unitList.Add(new BlueMonster(700, 150));
            unitList.Add(new BlackMonster(800, 450));
            unitList.Add(new BlueMonster(700, 150));
            unitList.Add(new BlackMonster(800, 450));
            unitList.Add(new BlueMonster(700, 150));
            unitList.Add(player);
        }
        private void InitializeItems()
        {
            itemList.Add(new Weapon(50, 50));
            itemList.Add(new HealingPoition(40, 150));
            itemList.Add(new Shield(300, 50));
            itemList.Add(new Weapon(1050, 100));
            itemList.Add(new HealingPoition(180, 260));
            itemList.Add(new Shield(1100, 420));
            itemList.Add(new Weapon(1000, 530));
            itemList.Add(new HealingPoition(980, 360));
            itemList.Add(new Shield(960, 450));
            itemList.Add(new Key(635, 40));
        }
        private void InitializeWalls()
        {
            wallList.Add(new Wall(0, 0));
            wallList.Add(new Wall(30, 0));
            wallList.Add(new Wall(60, 0));
            wallList.Add(new Wall(90, 0));
            wallList.Add(new Wall(120, 0));
            wallList.Add(new Wall(150, 0));
            wallList.Add(new Wall(180, 0));
            wallList.Add(new Wall(210, 0));
            wallList.Add(new Wall(240, 0));
            wallList.Add(new Wall(270, 0));
            wallList.Add(new Wall(300, 0));
            wallList.Add(new Wall(330, 0));
            wallList.Add(new Wall(360, 0));
            wallList.Add(new Wall(390, 0));
            wallList.Add(new Wall(420, 0));
            wallList.Add(new Wall(450, 0));
            wallList.Add(new Wall(480, 0));
            wallList.Add(new Wall(510, 0));
            wallList.Add(new Wall(540, 0));
            wallList.Add(new Wall(570, 0));
            wallList.Add(new Wall(600, 0));
            wallList.Add(new Wall(690, 0));
            wallList.Add(new Wall(720, 0));
            wallList.Add(new Wall(750, 0));
            wallList.Add(new Wall(780, 0));
            wallList.Add(new Wall(810, 0));
            wallList.Add(new Wall(840, 0));
            wallList.Add(new Wall(870, 0));
            wallList.Add(new Wall(900, 0));
            wallList.Add(new Wall(930, 0));
            wallList.Add(new Wall(960, 0));
            wallList.Add(new Wall(990, 0));
            wallList.Add(new Wall(1020, 0));
            wallList.Add(new Wall(1050, 0));
            wallList.Add(new Wall(1080, 0));
            wallList.Add(new Wall(1110, 0));
            wallList.Add(new Wall(1140, 0));
            wallList.Add(new Wall(1170, 0));
            wallList.Add(new Wall(0, 30));
            wallList.Add(new Wall(0, 60));
            wallList.Add(new Wall(0, 90));
            wallList.Add(new Wall(0, 120));
            wallList.Add(new Wall(0, 150));
            wallList.Add(new Wall(0, 180));
            wallList.Add(new Wall(0, 210));
            wallList.Add(new Wall(0, 240));
            wallList.Add(new Wall(0, 270));
            wallList.Add(new Wall(0, 300));
            wallList.Add(new Wall(0, 330));
            wallList.Add(new Wall(0, 360));
            wallList.Add(new Wall(0, 390));
            wallList.Add(new Wall(0, 420));
            wallList.Add(new Wall(0, 450));
            wallList.Add(new Wall(0, 480));
            wallList.Add(new Wall(0, 510));
            wallList.Add(new Wall(0, 540));
            wallList.Add(new Wall(0, 570));
            wallList.Add(new Wall(0, 570));
            wallList.Add(new Wall(30, 570));
            wallList.Add(new Wall(60, 570));
            wallList.Add(new Wall(90, 570));
            wallList.Add(new Wall(120, 570));
            wallList.Add(new Wall(150, 570));
            wallList.Add(new Wall(180, 570));
            wallList.Add(new Wall(210, 570));
            wallList.Add(new Wall(240, 570));
            wallList.Add(new Wall(270, 570));
            wallList.Add(new Wall(300, 570));
            wallList.Add(new Wall(330, 570));
            wallList.Add(new Wall(360, 570));
            wallList.Add(new Wall(390, 570));
            wallList.Add(new Wall(420, 570));
            wallList.Add(new Wall(450, 570));
            wallList.Add(new Wall(480, 570));
            wallList.Add(new Wall(510, 570));
            wallList.Add(new Wall(540, 570));
            wallList.Add(new Wall(570, 570));
            wallList.Add(new Wall(600, 570));
            wallList.Add(new Wall(690, 570));
            wallList.Add(new Wall(720, 570));
            wallList.Add(new Wall(750, 570));
            wallList.Add(new Wall(780, 570));
            wallList.Add(new Wall(810, 570));
            wallList.Add(new Wall(840, 570));
            wallList.Add(new Wall(870, 570));
            wallList.Add(new Wall(900, 570));
            wallList.Add(new Wall(930, 570));
            wallList.Add(new Wall(960, 570));
            wallList.Add(new Wall(990, 570));
            wallList.Add(new Wall(1020, 570));
            wallList.Add(new Wall(1050, 570));
            wallList.Add(new Wall(1080, 570));
            wallList.Add(new Wall(1110, 570));
            wallList.Add(new Wall(1140, 570));
            wallList.Add(new Wall(1170, 570));
            wallList.Add(new Wall(1170, 30));
            wallList.Add(new Wall(1170, 60));
            wallList.Add(new Wall(1170, 90));
            wallList.Add(new Wall(1170, 120));
            wallList.Add(new Wall(1170, 150));
            wallList.Add(new Wall(1170, 180));
            wallList.Add(new Wall(1170, 210));
            wallList.Add(new Wall(1170, 240));
            wallList.Add(new Wall(1170, 270));
            wallList.Add(new Wall(1170, 300));
            wallList.Add(new Wall(1170, 330));
            wallList.Add(new Wall(1170, 360));
            wallList.Add(new Wall(1170, 390));
            wallList.Add(new Wall(1170, 420));
            wallList.Add(new Wall(1170, 450));
            wallList.Add(new Wall(1170, 480));
            wallList.Add(new Wall(1170, 510));
            wallList.Add(new Wall(1170, 540));
            wallList.Add(new Wall(1170, 570));

        }

        private void MovePlayerRight()
        {
            this.player.Move(5, 0); ;
        }

        private void MovePlayerDown()
        {
            this.player.Move(0, 5);
        }

        private void MovePlayerUp()
        {
            this.player.Move(0, -5);
        }

        private void MovePlayerLeft()
        {
            this.player.Move(-5, 0);
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
