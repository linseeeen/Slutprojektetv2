using System;
using Raylib_cs;
using System.Collections.Generic;

namespace Slutprojektetv2
{
    public class Start : Scene
    {
        /*  Min konstruktor lägger till sig själv i mitt hashset, samt
        lägger till att metoden för att köra denna metod i mitt dictionary
        med key 2
        */
        public Start(){
            scenes.Add(this);
            actions.Add(2, StartScene);
        }
        //Kör gameobjects DrawAll() metod.
        protected override void DrawScene()
        {
            GameObject.DrawAll();
        }
    }
}
