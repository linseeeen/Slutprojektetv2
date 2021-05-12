using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Slutprojektetv2
{
    public class Plant : GameObject
    {
        //Definerar 2 specifika färger
        protected Color dryPlantColor = new Color(173, 118, 0, 255);
        protected Color healthyPlantColor = new Color(217, 33, 0, 255);
        //Håller reda på huruvida en planta behöver vattnas eller ej
        //protected static bool healtyPlant = false;
        //Skapar rektangeln för plantan, bestämmer storlek samt plats och lägger till i listan
        public Plant(){
            gameObjects.Add(this);
        }
        //Ritar ut rektangeln, ändrar färg beroende på om den är healthy eller ej.
        protected override void Draw()
        {
            if (!HealthyPlant())
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
