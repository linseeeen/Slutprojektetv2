using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Slutprojektetv2
{
    public class WateringCan : GameObject
    {
        public int water = 3;
        public WateringCan(){
            rect.height = 30;
            rect.width = 30;
            rect.x = 50;
            rect.y = 100;
            gameObjects.Add(this);
        }
        protected override void Update()
        {
            
        }
        protected override void Draw()
        {
            Raylib.DrawRectangleRec(rect, Color.BLUE);
        }
    }
}
