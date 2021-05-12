using System;
using Raylib_cs;

namespace Slutprojektetv2
{
    public class Orange : Plant
    {
        public Orange(){
            rect.height = 20;
            rect.width = 20;
            rect.x = 500;
            rect.y = 450;
            healthyPlantColor = new Color(255, 145, 0, 255);
            gameObjects.Add(this);
        }
    }
}
