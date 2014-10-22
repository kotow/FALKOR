using System;
namespace OOP_TeamWork.Interfaces
{
    public interface IKeyboardControlable : IMovable
    {
        event EventHandler OnRightPressed;
        event EventHandler OnLeftPressed;
        event EventHandler OnUpPressed;
        event EventHandler OnDownPressed;
    }
}
