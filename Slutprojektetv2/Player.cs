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
        /*Min konstruktor skapar spelaren, den säger hur stor rektangeln ska vara
        var den ska spawna, vilka tangenter som är vilka samt lägger till den i min
        lista med spelobjekt. Den tar in alla information från program.cs när den skapar spelare
        detta gör att jag kan bestämma vilka tangenter som ska användas när den skapas, detta
        är väldigt bra om jag t.ex skulle ha flera spelare, då kan jag ge dessa olika 
        tangenter att styra med, olika platser att spawna på osv.
        */
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
        /*Min update metod kollar huruvida en knapp som ska styra spelaren är
        nertryckt samt vilken, beroende på vilken knapp så kommer den att ändra
        speed, bestämmer om den är positiv eller negativ, på båda axlar, detta är det
        som ändrar vilken riktning den flyttar på sig. Lägger jag till speed 
        (som är en variable jag skapat, en int) på x axel kommer den röra sig åt höger
        tar jag bort kommer den att röra sig till vänster, samma princip gäller
        på y axeln bara andra riktningar. Denna metod körs varje frame innan jag börjar
        rita, högre och lägre värde på speed ändrar hur mycket spelaren ska flytta på sig
        varje frame, med andra ord hur snabbt spelaren rör på sig.
        */
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
        /*Denna metod håller koll på om spelaren kolliderar med något, och
        beroende på vad spelaren kolliderar med sker olika saker. Den kollar 
        detta genom att gå igenom listan med game objects, och för varje gameobject 
        så kollar den huruvida detta kolliderar med spelaren.

        Kolliderar spelaren med vattenkannen så kommer boolen 
        wateringcanEquiped att bli true, samt att vattenkannan kommer att få
        samma x och y kordinater som spelaren, detta gör att den kommer att
        förflyttas med spelaren. 

        Den andra delen av min if-sats, kollar huruvida spelaren kolliderar med en planta.
        Om den gör det finns 2 olika utfall. Om spelaren ockå håller i vattenkannan
        (wateringcanEquiped = true) så kommer plantan att vattnas(den byter färg). Om
        spelaren inte håller i vattenkannan så kommer denna att medelas om att den
        måste hålla i vattenkannan för att kunna vattna, detta så att spealren
        ska veta vad den ska göra även om den vägrar att öppna instruktionerna.
        */
        protected override void Collision(){
            foreach (GameObject g in gameObjects)
            {
                if (g is WateringCan)
                {
                    if (Raylib.CheckCollisionRecs(rect, g.rect))
                    {
                        wateringCanEqiped = true;
                        g.rect.x = rect.x;
                        g.rect.y = rect.y;
                    }
                }
                else if (g is Plant)
                {
                    if (Raylib.CheckCollisionRecs(rect, g.rect) && wateringCanEqiped == true)
                    {
                        g.SetHealthyPlant(true);
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
