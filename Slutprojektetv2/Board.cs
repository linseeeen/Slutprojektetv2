using System;
using System.Collections.Generic;
using Raylib_cs;

namespace Slutprojektetv2
{
    public class Board
    {
        public static List<Board> board = new List<Board>();
        public Board(){
            board.Add(this);
        }
    }
}
