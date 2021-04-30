using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Slutprojektetv2
{
    public class Scene
    {
        /*Håller reda på mina scener, har valt att lägga den i ett hashset för att inte
        riskera att lägga till samma scen flera gånger.
        */
        protected static HashSet<Scene> scenes = new HashSet<Scene>();
        /*Ett dictionary som kör rätt metod beroende på vilken scen som ska köras
        */
        protected static Dictionary<int, Action> actions = new Dictionary<int, Action>();
        /*Denna metod ritar ut själva scenen, de olika subklasserna har alla
        en egen variant där det defineras vad som ska ritas ut i just den scenen
        */
        protected virtual void DrawScene(){
            
        }
        /*Denna metod ritar ut själva spelet, jag går igenom mitt hashset med en
        foreach loop för att leta reda på rätt scen, jag jämför alla för att se
        huruvida de matchar med scenen start, då kör jag dens DrawScene() metod,
        detta är varför ajg ville vara säker på att jag endast har 1 av varje scen
        i min samling
        */
        protected void StartScene(){
            foreach (Scene s in scenes)
            {
                if (s.GetType() == typeof(Start))
                {
                    s.DrawScene();
                    
                }
            }
        }
        //Samma princip som StartScene() bara att den istället ritar ut instruktioner
        protected void InstructionScene(){
            foreach (Scene s in scenes)
            {
                if (s.GetType() == typeof(Instruktion))
                {
                    
                        s.DrawScene();
                }
            }
        }
        /*Denna metod tar reda på huruvida spelaren håller in knappen I, om
        den gör det så kommer metoden att retunera en int, 1 i detta fall, jag
        har valt att göra det på detta sätt för att det inte ska bli problem
        om användaren trycker på någon annan knapp, eller om man skulle låta användaren
        skriva in ett värde så riskerar det att den matar in något som får programmet
        att krascha, gör jag på detta sett så händer det bara något om användaren
        trycker på I, det finns också alltid en text på skärmen som säger att 
        användare ska hålla in I för instruktioner.
        */
        private static int Converter(){
            int resultat = 0;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_I))
            {
                resultat = 1;
            }
            return resultat;
        }
        /*Denna metod tar in en int från min metod Converter, sen går den igenom 
        mitt dictionary och letar efter den metod som matchar med key 1, när den hittar det
        så kör den metoden som finns lagrad under key 1.
        */
        private static void UserChoice(){
            foreach (int key in actions.Keys)
            {
                if (Converter() == 1 && key == 1)
                {
                    actions[1]();
                }
            }
        }
        /*Denna metodär den metod som ritar ut allt till fönstret, beroende
        på om användaer trycker in I för instruktioner eller ej så ritar den ut
        olika grejer.
        
        En uppdatering jag hade velat göra är så att spelet pausar
        när man är i intruktionerna.
        */
        public static void SceneToScreen(){
            
            GameObject.UpdateAll();
            
            Raylib.BeginDrawing();
            
            Raylib.ClearBackground(Color.GREEN);
            
            if (Raylib.IsKeyDown(KeyboardKey.KEY_I))
            {
                UserChoice();
            }
            else
            {
                actions[2]();
            }
            Raylib.EndDrawing();
        }
    }
}
