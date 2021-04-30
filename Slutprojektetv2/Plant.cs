using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Slutprojektetv2
{
    public class Plant : GameObject
    {
        //Definerar 2 specifika färger
        private Color dryPlantColor = new Color(173, 118, 0, 255);
        private Color healthyPlantColor = new Color(217, 33, 0, 255);
        //Håller reda på huruvida en planta behöver vattnas eller ej
        private static bool healtyPlant = false;
        //Skapar rektangeln för plantan, bestämmer storlek samt plats och lägger till i listan
        public Plant(){
            rect.height = 20;
            rect.width = 20;
            rect.x = 400;
            rect.y = 400;
            gameObjects.Add(this);
        }
        public static bool HealthyPlant {
            get
            {
                return healtyPlant;
            }
            set
            {
                healtyPlant = value;
            }
        }
        //Ritar ut rektangeln, ändrar färg beroende på om den är healthy eller ej.
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
