﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoOS1.Models.GameBase
{
    class MoveInformation
    {
        public MoveInformation(int move, int playerACall, bool playerBAnswer, int finalMove)
        {
            Move = move;
            PlayerACall = playerACall;
            PlayerBAnswer = playerBAnswer;
            FinalMove = finalMove;
        }

        public int Move { get; }
        public int PlayerACall { get; }
        public bool PlayerBAnswer { get; }

        public int FinalMove { get; }
    }
}