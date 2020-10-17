//Jogo da velha classico em C#
//Desenvolvido por Guilherme R. Rodrigues
using System;

namespace JogoDaVelha
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameRun = true;

            while(gameRun == true)
            {
                int choice, turn, winner;
                turn = choice = winner = 0;

                //Menu
                Console.WriteLine("Jogo da velha C#");
                Console.WriteLine();
                Console.WriteLine("1 - Jogar");
                Console.WriteLine("2 - Como Jogar");
                Console.WriteLine("0 - Sair");
                Console.WriteLine();
                Console.Write("O que você deseja fazer? ");
                choice = int.Parse(Console.ReadLine());
                Board b = new Board();
                

                switch (choice) 
                {
                    case 1:
                        
                        Console.Clear();
                        //definir numero de jogadores humanos
                        Player[] p = b.DefinePlayers();
                        //loop para jogo funcionar enquanto ninguem ganhar ou der velha
                        while (b.GetGaming() == true)
                        {
                            b.PrintBoard();
                            b.PlayerTurn(turn, p[turn]);
                            winner = b.CheckVictory();

                            turn++;
                            if(turn == p.Length)
                            {
                                turn = 0;
                            }
                        }
                        //Printar o vencedor
                        Console.Clear();
                        b.PrintBoard();
                        b.PrintVictory(winner);
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    case 2:
                        //como jogar
                        Console.Clear();
                        Console.WriteLine("As regras são simples...");
                        Console.WriteLine("Para vencer você deve preencher uma reta com uma sequencia de 3 de suas peças");
                        Console.WriteLine();
                        Console.WriteLine("Seja na Horizontal:");
                        Console.WriteLine();
                        Console.WriteLine(" X | X | X");
                        Console.WriteLine("-----------");
                        Console.WriteLine("   |   |  ");
                        Console.WriteLine("-----------");
                        Console.WriteLine("   |   |  ");
                        Console.WriteLine();
                        Console.WriteLine("Na Vertical:");
                        Console.WriteLine();
                        Console.WriteLine(" X |   |  ");
                        Console.WriteLine("-----------");
                        Console.WriteLine(" X |   |  ");
                        Console.WriteLine("-----------");
                        Console.WriteLine(" X |   |  ");
                        Console.WriteLine();
                        Console.WriteLine("Ou na Diagonal:");
                        Console.WriteLine();
                        Console.WriteLine(" X |   |  ");
                        Console.WriteLine("-----------");
                        Console.WriteLine("   | X |  ");
                        Console.WriteLine("-----------");
                        Console.WriteLine("   |   | X ");
                        Console.WriteLine();
                        Console.WriteLine("Selecione a posição que deseja colocar a peça de acordo com os números abaixo");
                        Console.WriteLine();
                        Console.WriteLine(" 1 | 2 | 3");
                        Console.WriteLine("-----------");
                        Console.WriteLine(" 4 | 5 | 6");
                        Console.WriteLine("-----------");
                        Console.WriteLine(" 7 | 8 | 9");
                        Console.WriteLine();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 0:

                        gameRun = false;
                        Console.Clear();

                        break;
                    default:
                        //caso valor de input n for válido
                        Console.Clear();
                        Console.WriteLine("Valor invalido, por favor, escolha um número válido");
                        Console.WriteLine();

                        break;
                }
                    
            }

            Console.WriteLine("Obrigado por jogar!");
            Console.ReadKey();

        }



    }
}
