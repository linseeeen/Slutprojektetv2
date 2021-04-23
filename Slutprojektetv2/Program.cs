using System;
using Raylib_cs;

namespace Slutprojektetv2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Skapar mitt fönster
            Raylib.InitWindow(800, 600, "My Wonderfull Farm");

            //Skapar mina obejekt
            Player p1 = new Player(20, 20, KeyboardKey.KEY_W, KeyboardKey.KEY_S, KeyboardKey.KEY_D, KeyboardKey.KEY_A);
            WateringCan water = new WateringCan();
            Plant plant = new Plant();
            //Logiken som sköter själva spelfönstret.
            while (!Raylib.WindowShouldClose())
            {
                GameObject.UpdateAll();

                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.GREEN);

                GameObject.DrawAll();

                Raylib.EndDrawing();
            }
        }
    }
}
