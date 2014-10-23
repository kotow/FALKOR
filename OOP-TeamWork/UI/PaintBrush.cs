using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using OOP_TeamWork.Structure;

namespace OOP_TeamWork.UI
{
    public class PaintBrush : IDrawable
    {
        private const int ProgressBarSizeX = 50;
        private const int ProgressBarSizeY = 8;
        private const int ProgressBarOffsetX = -3;
        private const int ProgressBarOffsetY = -10;

        private const string MageImagePath = "../../Images/Mage.png";
        private const string HealthPotionImagePath = "../../Images/HealingPoition.png";
        private const string ShieldImagePath = "../../Images/Shield.png";
        private const string WallImagePath = "../../Images/Wall.png";
        private const string BlueMonsterImagePath = "../../Images/BlueMonster.png";
        private const string BlackMonsterImagePath = "../../Images/BlackMonster.png";
        private const string WeaponImagePath = "../../Images/weapon.png";
        private const string KeyImagePath = "../../Images/key.png";

        private Image mageImage, healthPotionImage, blueMonster, wallImage, blackMonster, shieldImage, weaponImage, keyImage;
        private Form gameWindow;
        private List<PictureBox> pictureBoxes;
        private List<ProgressBar> progressBars;

        public PaintBrush(Form form)
        {
            this.gameWindow = form;
            this.LoadResources();
            this.pictureBoxes = new List<PictureBox>();
            this.progressBars = new List<ProgressBar>();
        }

        public void AddObject(IDrawable renderableObject)
        {
            if (renderableObject is Unit)
            {
                this.CreateProgressBar(renderableObject as Unit);
            }
            this.CreatePictureBox(renderableObject);
        }

        public void RemoveObject(IDrawable renderableObject)
        {
            var picBox = GetPictureBoxByObject(renderableObject);
            this.gameWindow.Controls.Remove(picBox);
            this.pictureBoxes.Remove(picBox);
            if (renderableObject is Unit)
            {
                var progressBar = GetProgressBarByObject(renderableObject as Unit);
                this.gameWindow.Controls.Remove(progressBar);
                this.progressBars.Remove(progressBar);
            }
        }

        public void RedrawObject(IDrawable objectToBeRedrawn)
        {
            var newCoordinates = new Point(objectToBeRedrawn.PositionX, objectToBeRedrawn.PositionY);
            var picBox = GetPictureBoxByObject(objectToBeRedrawn);
            picBox.Location = newCoordinates;
            if (objectToBeRedrawn is Unit)
            {
                var unit = objectToBeRedrawn as Unit;
                var progressBar = GetProgressBarByObject(unit);
                this.SetProgressBarLocation(unit, progressBar);
                progressBar.Value = unit.CurrentHealth;
            }
        }

        private void CreateProgressBar(Unit unit)
        {
            var progressBar = new ProgressBar();
            progressBar.Size = new Size(ProgressBarSizeX, ProgressBarSizeY);
            this.SetProgressBarLocation(unit, progressBar);
            progressBar.Maximum = unit.health;
            progressBar.Value = unit.CurrentHealth;
            progressBar.Tag = unit;
            progressBars.Add(progressBar);
            this.gameWindow.Controls.Add(progressBar);
        }

        private void SetProgressBarLocation(Unit unit, ProgressBar progressBar)
        {
            progressBar.Location = new Point(unit.UnitPositionX + ProgressBarOffsetX, unit.UnitPositionY + ProgressBarOffsetY);
        }
        private ProgressBar GetProgressBarByObject(Unit unit)
        {
            return this.progressBars.First(p => p.Tag == unit);
        }

        private void CreatePictureBox(IDrawable renderableObject)
        {
            var spriteImage = GetSpriteImage(renderableObject);
            var picBox = new PictureBox();
            picBox.BackColor = Color.Transparent;
            picBox.Image = spriteImage;
            picBox.Parent = this.gameWindow;
            picBox.Location = new Point(renderableObject.PositionX, renderableObject.PositionY);
            picBox.Size = new Size(renderableObject.Width, renderableObject.Height);
            picBox.Tag = renderableObject;
            this.pictureBoxes.Add(picBox);
            this.gameWindow.Controls.Add(picBox);
        }


        private Image GetSpriteImage(IDrawable renderableObject)
        {

            Image image;
            switch (renderableObject.SpriteType)
            {
                case SpriteType.Mage:
                    image = this.mageImage;
                    break;
                case SpriteType.BlueMonster:
                    image = this.blueMonster;
                    break;
                case SpriteType.BlackMonster:
                    image = this.blackMonster;
                    break;
                case SpriteType.Wall:
                    image = this.wallImage;
                    break;
                case SpriteType.HealnigPoition:
                    image = this.healthPotionImage;
                    break;
                case SpriteType.Weapon:
                    image = this.weaponImage;
                    break;
                case SpriteType.Shield:
                    image = this.shieldImage;
                    break;
                case SpriteType.Key:
                    image = this.keyImage;
                    break;
                default:
                    image = this.wallImage;
                    break;
            }
            return image;
        }

        private PictureBox GetPictureBoxByObject(IDrawable renderableObject)
        {
            return this.pictureBoxes.First(p => p.Tag == renderableObject);
        }

        public void LoadResources()
        {
            this.mageImage = Image.FromFile(MageImagePath);
            this.healthPotionImage = Image.FromFile(HealthPotionImagePath);
            this.blueMonster = Image.FromFile(BlueMonsterImagePath);
            this.wallImage = Image.FromFile(WallImagePath);
            this.blackMonster = Image.FromFile(BlackMonsterImagePath);
            this.shieldImage = Image.FromFile(ShieldImagePath);
            this.weaponImage = Image.FromFile(WeaponImagePath);
            this.keyImage = Image.FromFile(KeyImagePath);
        }

        public int PositionX { get; set; }

        public int PositionY { get; set; }

        public void Draw()
        {
        }
        public int Width { get; set; }
        public int Height { get; set; }
        public SpriteType SpriteType { get; set; }
    }
}
