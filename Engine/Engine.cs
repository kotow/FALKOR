using OOP_TeamWork;
using OOP_TeamWork.Interfaces;
using System;
using System.Collections.Generic;
namespace OOP_TeamWork
{
    public class Engine
    {
        private IDrawable painter;
        private List<Object> objectList;
        private Unit player;
        private int interval;

        public Engine(IKeyboardControlable controller, IDrawable painter,
            int loopInterval)
        {
            this.interval = loopInterval;
            this.objectList = new List<Object>();
            this.SubscribeToUserInput(controller);
            this.InitializeCharacters();
            this.painter = painter;
            foreach (var obj in objectList)
            {
                this.painter.AddObject(obj);
            }
        }

        public void PlayNextTurn()
        {
            this.ProcessUnits();
            this.RedrawAll();
        }

        private void RedrawAll()
        {
            foreach (var unit in this.objectList)
            {
                this.painter.RedrawObject(unit);
            }
        }

        private void ProcessUnits()
        {
            //TODO
        }

        private void InitializeCharacters()
        {
            var playerCharacter = new Mage(100, 100, 198, 255);
            player = playerCharacter;
            objectList.Add(new BlackMonster(500, 50, 132, 142));
            objectList.Add(new BlueMonster(300, 150, 136, 136));
            objectList.Add(new Weapon(100, 100, 100, 100));
            objectList.Add(player);
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
