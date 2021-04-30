using System;
using Raylib_cs;

namespace Slutprojektetv2
{
    public class Player : GameObject
    {
        private KeyboardKey upKey;
        private KeyboardKey downKey;
        private KeyboardKey rightKey;
        private KeyboardKey leftKey;
        private float speed = 0.5f;
        //Håller reda på om spelaren håller i vattenkanna eller ej
        protected bool wateringCanEqiped = false;
        public Player(float x, float y, KeyboardKey upKey, KeyboardKey downKey, KeyboardKey rightKey, KeyboardKey leftKey)
        {
            this.rect.height = 50;
            this.rect.width = 50;
            this.rect.x = x;
            this.rect.y = y;

            this.upKey = upKey;
            this.downKey = downKey;
            this.leftKey = leftKey;
            this.rightKey = rightKey; 
            gameObjects.Add(this);
        }
        protected override void Update()
        {
            
            if (Raylib.IsKeyDown(upKey))
            {
                this.rect.y -= speed;
            }
            else if (Raylib.IsKeyDown(downKey))
            {
                this.rect.y += speed;
            }
            else if (Raylib.IsKeyDown(leftKey))
            {
                this.rect.x -= speed;
            }
            else if (Raylib.IsKeyDown(rightKey))
            {
                this.rect.x += speed;
            }
        }
        
        protected override void Collision(){
            foreach (GameObject g in gameObjects)
            {
                if (g.GetType() == typeof(WateringCan))
                {
                    if (Raylib.CheckCollisionRecs(rect, g.rect))
                    {
                        wateringCanEqiped = true;
                        g.rect.x = rect.x;
                        g.rect.y = rect.y;
                    }
                }
                else if (g.GetType() == typeof(Plant))
                {
                    if (Raylib.CheckCollisionRecs(rect, g.rect) && wateringCanEqiped == true)
                    {
                        Plant.HealthyPlant = true;
                    }
                    else if (Raylib.CheckCollisionRecs(rect, g.rect))
                    {
                        Raylib.DrawText("Du måste plocka upp vattenkannan för att kunna vattna!", 100, 50, 20, Color.BLACK);
                    }
                }
            }
        }
    }
}
