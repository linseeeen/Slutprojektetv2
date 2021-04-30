using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Slutprojektetv2
{
    public class GameObject
    {
        public Rectangle rect = new Rectangle();

        //Lista med alla objekt i spelet
        protected static List<GameObject> gameObjects = new List<GameObject>();

        public GameObject()
        {
            gameObjects.Add(this);
        }
        //Kollar huruvida ett objekt i min lista är utanför själva spelfönstret
        private void Wall()
        {
            if (this.rect.x > 750)
            {
               this.rect.x = 750; 
            }
            else if (this.rect.x < 0)
            {
                this.rect.x = 0;
            }
            else if (this.rect.y > 550)
            {
                this.rect.y = 550;
            }
            else if (this.rect.y < 0)
            {
                this.rect.y = 0;
            }
        }
        protected virtual void Update(){
            
        }
        protected virtual void Collision(){
            
        }
        public static void UpdateAll()
        {
            foreach (GameObject g in gameObjects)
            {
                g.Update();
                g.Wall();
                g.Collision();
            }
        }
        protected virtual void Draw(){
            Raylib.DrawRectangleRec(rect, Color.RED);
            Raylib.DrawText("Håll in I för instruktioner", 5, 5, 20, Color.BLACK);
        }
        public static void DrawAll()
        {
            foreach (GameObject g in gameObjects)
                {
                    g.Draw();
                }
        }
    }
}
