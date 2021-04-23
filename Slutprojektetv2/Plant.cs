using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Slutprojektetv2
{
    public class Plant : GameObject
    {
        private Color dryPlantColor = new Color(173, 118, 0, 255);
        private Color healthyPlantColor = new Color(217, 33, 0, 255);
        public Plant(){
            rect.height = 20;
            rect.width = 20;
            rect.x = 400;
            rect.y = 400;
            gameObjects.Add(this);
        }
        protected override void Draw()
        {
            if (!healtyPlant)
            {
                Raylib.DrawRectangleRec(rect, dryPlantColor);
            }
            else
            {
                Raylib.DrawRectangleRec(rect, healthyPlantColor);
            }
            
        }
    }
}
