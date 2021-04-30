using System;
using System.IO;
using Raylib_cs;

namespace Slutprojektetv2
{
    public class Instruktion : Scene
    {
        /*Denna string variabel läser in ett textdokuemnt där instruktionerna 
        är lagrade, detta för att slippa ha de i min kod, det blir mindre klottrigt då.
        */
        string instruktion = File.ReadAllText(@"Instruktion.txt");
        //Denna konstruktor gör samma som den för start
        public Instruktion(){
            scenes.Add(this);
            actions.Add(1, InstructionScene);
        }
        /*Denna DrawScene() skriver ut texten som finns i mitt textdokument,
        på platsen för x= 100, y = 50, i fontstorlek 20 med färgen svart
        */
        protected override void DrawScene()
        {
            Raylib.DrawText(instruktion, 100, 50, 20, Color.BLACK);
        }
    }
}
