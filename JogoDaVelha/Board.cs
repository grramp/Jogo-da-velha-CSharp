using System;
using System.Collections.Generic;
using System.Text;

namespace JogoDaVelha
{
    class Board
    {
        private bool Gaming;
        private int[,] BoardHash;

        public Player[] DefinePlayers()
        {
            this.BoardHash = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            this.Gaming = true;

            Console.Clear();
            int choice = 0;
            while (choice < 1 || choice > 2)
            {
                Console.Write("Quantos jogadores humanos (1-2)? ");
                choice = int.Parse(Console.ReadLine());

            }

            Player[] tempPlayers = new Player[2];
            for (int i = 0; i < tempPlayers.Length; i++)
            {
                tempPlayers[i] = new Player(i);
                if (i < choice)
                {
                    tempPlayers[i].SetHuman(true);
                }

            }

            Console.Clear();
            return tempPlayers;

        }

        public void PlayerTurn(int turn, Player p)
        {
            int marker = 0;
            if (turn == 0) { marker = -1; }
            else if (turn == 1){ marker = 1; }

            if (p.GetHuman() == true)
            {
                Console.WriteLine("Vez do Jogador " + (turn + 1));
                bool check = false;
                while (check == false)
                {
                    Console.Write("Escolha a posição que deseja colocar a peça (1-9): ");
                    int choice = int.Parse(Console.ReadLine());
                    int j, k;
                    j = k = 0;

                    for (int i = 0; i < choice; i++)
                    {

                        if (i == (choice - 1) && this.BoardHash[j, k] == 0)
                        {
                            this.BoardHash[j, k] = marker;
                            check = true;
                        }

                        k++;

                        if (k == 3)
                        {
                            j++;
                            k = 0;
                        }

                    }

                    if (check == false)
                    {
                        Console.WriteLine("Esse valor não é possivel, escolha outra posição.");
                    }
                }
            }

            if (p.GetHuman() == false)
            {
                bool played = false;
                for (int i = 0; i < 3; i++)
                {
                    if (played == false)
                    {
                        if ((this.BoardHash[i, 0] + this.BoardHash[i, 1] + this.BoardHash[i, 2])%3 == -2 || (this.BoardHash[i, 0] + this.BoardHash[i, 1] + this.BoardHash[i, 2])%3 == 2)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (this.BoardHash[i, j] == 0)
                                {
                                    this.BoardHash[i, j] = marker; played = true;
                                }
                            }
                        }

                        else if ((this.BoardHash[0, i] + this.BoardHash[1, i] + this.BoardHash[2, i])%3 == -2 || (this.BoardHash[0, i] + this.BoardHash[1, i] + this.BoardHash[2, i])%3 == 2)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                if (this.BoardHash[j, i] == 0 && played == false)
                                {
                                    this.BoardHash[j, i] = marker; played = true;
                                }
                            }
                        }
                       
                        
                    }
                }

                 if ((this.BoardHash[0, 0] + this.BoardHash[1, 1] + this.BoardHash[2, 2])%3 == -2 || (this.BoardHash[0, 0] + this.BoardHash[1, 1] + this.BoardHash[2, 2])%3 == 2)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (this.BoardHash[j, j] == 0 && played == false)
                        {
                            this.BoardHash[j, j] = marker; played = true;
                        }
                    }
                }
                else if ((this.BoardHash[0, 2] + this.BoardHash[1, 1] + this.BoardHash[2, 0])%3 == -2 || (this.BoardHash[0, 2] + this.BoardHash[1, 1] + this.BoardHash[2, 0])%3 == -2)
                {
                    int n = 2;
                    for (int j = 0; j < 3; j++)
                    {

                        if (this.BoardHash[j, n] == 0 && played == false)
                        {
                            this.BoardHash[j, n] = marker; played = true;
                        }
                        n = n-1;
                    }
                }
                else if (played == false)
                {
                    while (played == false)
                    {
                        var rnd = new Random();
                        int i = rnd.Next(3);
                        int j = rnd.Next(3);


                        if (this.BoardHash[i, j] == 0)
                        {
                            this.BoardHash[i, j] = marker;
                            played = true;
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Pressione qualquer tecla");
                Console.ReadKey();
            }
        }

        public void PrintBoard()
        {
            Console.Clear();
            int j, k;
            j = k = 0;
            string[] pieces = new string[9];
            for (int i = 0; i < 9; i++)
            {

                if (this.BoardHash[j, k] == -1) { pieces[i] = "X"; }
                else if (this.BoardHash[j, k] == 0) { pieces[i] = " "; }
                else if (this.BoardHash[j, k] == 1) { pieces[i] = "O"; }

                k++;

                if (k == 3)
                {
                    j++;
                    k = 0;
                }
            }
            Console.WriteLine();
            Console.WriteLine(" {0} | {1} | {2}", pieces[0], pieces[1], pieces[2]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2}", pieces[3], pieces[4], pieces[5]);
            Console.WriteLine("-----------");
            Console.WriteLine(" {0} | {1} | {2}", pieces[6], pieces[7], pieces[8]);
            Console.WriteLine();
        }

        public int CheckVictory() 
        {
            int j, k;
            j = k = 0;
            int winner=3;

            this.Gaming = false;

            for (int i = 0; i < 9; i++)
            {
                if (this.BoardHash[j, k] == 0) { winner = 0; this.Gaming = true; }

                k++;

                if (k == 3)
                {
                    j++;
                    k = 0;
                }
            }

            for (int i = 0; i < 3; i++) 
            {
                if (this.BoardHash[i, 0] + this.BoardHash[i, 1] + this.BoardHash[i, 2] == -3) { winner = 1; this.Gaming = false; }
                else if (this.BoardHash[i, 0] + this.BoardHash[i, 1] + this.BoardHash[i, 2] == 3) { winner = 2; this.Gaming = false; }
                else if (this.BoardHash[0, i] + this.BoardHash[1, i] + this.BoardHash[2, i] == 3) { winner = 2; this.Gaming = false; }
                else if (this.BoardHash[0, i] + this.BoardHash[1, i] + this.BoardHash[2, i] == -3) { winner = 1; this.Gaming = false; }
                else if (this.BoardHash[0, 0] + this.BoardHash[1, 1] + this.BoardHash[2, 2] == -3) { winner = 1; this.Gaming = false; }
                else if (this.BoardHash[0, 2] + this.BoardHash[1, 1] + this.BoardHash[2, 0] == -3) { winner = 1; this.Gaming = false; }
                else if (this.BoardHash[0, 0] + this.BoardHash[1, 1] + this.BoardHash[2, 2] == 3) { winner = 2; this.Gaming = false; }
                else if (this.BoardHash[0, 2] + this.BoardHash[1, 1] + this.BoardHash[2, 0] == 3) { winner = 2; this.Gaming = false; }
            }

            return winner;

        }

        public void PrintVictory(int winner)
        {

            if (winner != 0)
            {
                switch (winner)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Jogador 1 é o vencedor!");
                        break;
                    case 2:
                        Console.WriteLine();
                        Console.WriteLine("Jogador 2 é o vencedor!");
                        break;
                    case 3:
                        Console.WriteLine();
                        Console.WriteLine("Deu velha...");
                        break;

                }
            }
        }

        public bool GetGaming()
        {

            return this.Gaming;

        }

        public void SetGaming(bool gaming)
        {

            this.Gaming = gaming;

        }

    }
}
