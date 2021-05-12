using System;
using Raylib_cs;

namespace Slutprojektetv2
{
    public class Strawberry : Plant
    {
        public Strawberry(){
            rect.height = 20;
            rect.width = 20;
            rect.x = 450;
            rect.y = 450;
            healthyPlantColor = new Color(255, 0, 115, 255);
            gameObjects.Add(this);
        }
    }
}
