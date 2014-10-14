using OOP_TeamWork.Interfaces;
using System;
using System.Windows.Forms;

namespace OOP_TeamWork.UI
{
    public class KeyboardController : IKeyboardControlable
    {
        public event EventHandler OnRightPressed;

        public event EventHandler OnLeftPressed;

        public event EventHandler OnUpPressed;

        public event EventHandler OnDownPressed;


        public KeyboardController(Form form)
        {
            form.KeyDown += FormKeyDown;
        }

        private void FormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (this.OnUpPressed != null)
                    {
                        this.OnUpPressed(this, new EventArgs());
                    }
                    break;
                case Keys.D:
                    if (this.OnRightPressed != null)
                    {
                        this.OnRightPressed(this, new EventArgs());
                    }
                    break;
                case Keys.S:
                    if (this.OnDownPressed != null)
                    {
                        this.OnDownPressed(this, new EventArgs());
                    }
                    break;
                case Keys.A:
                    if (this.OnLeftPressed != null)
                    {
                        this.OnLeftPressed(this, new EventArgs());
                    }
                    break;
                default:
                    break;
            }
        }

        public virtual void Move(int x, int y)
        {
            //throw new NotImplementedException();
        }
    }
}
