using System;
using System.Collections.Generic;
using System.Text;

namespace JogoDaVelha
{
    class Player
    {
        private bool Human;
        private int ID;

        public Player( int id)
        {
            this.ID = id;
        }

        public void SetHuman (bool human)
        {

            this.Human = human;

        }

        public bool GetHuman()
        {

            return this.Human;

        }


        public override string ToString()
        {
            return "Jogador " + ID;
        }
    }
}
