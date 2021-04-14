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
        private int speed = 1;
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
    }
}
