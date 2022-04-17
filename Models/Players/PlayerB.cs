using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoOS1.Models.Players
{
    class PlayerB
    {
        private bool[] answers = new bool[] {true,true,true,true,true, false,false,false,false,false,false,
                                             true,true, false,false,false,false,
                                             true,true,true,true, false,
                                             true, false,false};
        public bool Answer(int move, int currentPosition, int playerACall, out int finalMove)
        {
            if (currentPosition == 0) finalMove = 1;
            else if (answers[move%25]) finalMove = currentPosition + playerACall;
            else finalMove = currentPosition + playerACall * -1;
            return answers[move%25];

        }
    }
}
