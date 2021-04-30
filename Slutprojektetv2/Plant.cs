using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Slutprojektetv2
{
    public class Plant : GameObject
    {
        private Color dryPlantColor = new Color(173, 118, 0, 255);
        private Color healthyPlantColor = new Color(217, 33, 0, 255);
        //Håller reda på huruvida en planta behöver vattnas eller ej
        private static bool healtyPlant = false;
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
        protected override void Update()
        {
            //Slumpa fram ett tal, detta ska avögra huruvida plantan behöver vattnas eller ej.
            //Ska också funka som en mognadsgrej, när den är mogen går det att plockas.
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
