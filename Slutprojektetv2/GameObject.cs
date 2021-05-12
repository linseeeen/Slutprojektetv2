using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Slutprojektetv2
{
    public class GameObject
    {
        //gemensam rektangel.
        public Rectangle rect = new Rectangle();
        //Variabel som kollar om plantan är vattnad eller ej
        private bool healtyPlant = false;
        //Låter än andra boolen
        public void SetHealthyPlant (bool value){
            healtyPlant = value;
        }
        //Låter än läsa boolen
        public bool HealthyPlant(){
            return healtyPlant;
        }

        //Lista med alla objekt i spelet
        protected static List<GameObject> gameObjects = new List<GameObject>();
        /*Konstruktorn lägger till gameobject i listan med gameobjects, detta för att
        eventuella gemensamma metoder ska köras senare när jag kör UpdateAll() och
        DrawAll().
        */
        public GameObject()
        {
            gameObjects.Add(this);
        }
        /*Kollar huruvida ett objekt i min lista är utanför själva spelfönstret, om den är det
        så flyttas den tillbaka till en plats innanför spelfönstret.
        */
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
        //Gemensam update-metod
        protected virtual void Update(){
            
        }
        protected virtual void Collision(){
            
        }
        /*Denna metod går igenom min lista med gameobjects och kör metoderna update, wall och collision
        för alla gameobjects
        */
        public static void UpdateAll()
        {
            foreach (GameObject g in gameObjects)
            {
                g.Update();
                g.Wall();
                g.Collision();
            }
        }
        /*Denna metod kommer att göra att rekanglarna är röda om inget annat anges, samt skriver
        ut instruktionstexten att hålla in I, detta för att spelaren inte ska kunna miss ahur
        man öppnar instruktioner.
        */
        protected virtual void Draw(){
            Raylib.DrawRectangleRec(rect, Color.RED);
            Raylib.DrawText("Håll in I för instruktioner", 5, 5, 20, Color.BLACK);
        }
        //Kör DrawAll() för alla objekt i gameobject.
        public static void DrawAll()
        {
            foreach (GameObject g in gameObjects)
                {
                    g.Draw();
                }
        }
    }
}
