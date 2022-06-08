using System;

namespace cliche_TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int currentPlayer = -1;
            char[] markers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int gameStatus = 0;


            //game board and displays current player
            do
            {
                Console.Clear();
                currentPlayer = GetNextPlayer(currentPlayer);

            
                Display(currentPlayer);

                GameBoard(markers);

                gameEngine(markers, currentPlayer);

                gameStatus = CheckWinner(markers);

               
            } while (gameStatus.Equals(0));

            //clears console to prevent clutter
            Console.Clear();
            Display(currentPlayer);
            GameBoard(markers);

            //status of the game
            if (gameStatus.Equals(1))
            {
                Console.WriteLine($"Player {currentPlayer} gets the chicken dinner for them is the winner!");
            }

            if (gameStatus.Equals(2))
            {
                Console.WriteLine($"This game be a draw!");
            }

        }

        //checks if there is a winner
        private static int CheckWinner(char[] markers)
        {
          
            //checks if there is a draw
            if(IsGameDraw(markers))
            {
                return 2;
            }
            //if we have a winner, announce it and stop game
          if(IsGameWinner(markers))
            {
                return 1;
            }
            return 0;
        }

        //checks if draw is here
        private static bool IsGameDraw(char[] markers)
        {
             return markers[0] != '1' &&
                    markers[1] != '2' &&
                    markers[2] != '3' &&
                    markers[3] != '4' &&
                    markers[4] != '5' &&
                    markers[5] != '6' &&
                    markers[6] != '7' &&
                    markers[7] != '8' &&
                    markers[8] != '9';



        }

        //all possible combos of a win
        private static bool IsGameWinner(char[] markers)
        {
            if (IsGameMarkersTheSame(markers, 0,1,2))
            {
                return true;
            }
            if (IsGameMarkersTheSame(markers, 3,4,5))
            {
                return true;
            }
            if(IsGameMarkersTheSame(markers, 6,7,8))
            {
                return true;
            }
            if (IsGameMarkersTheSame(markers, 0,3,6))
            {
                return true;
            }
            if(IsGameMarkersTheSame(markers, 1,4,7))
            {
                return true;
            }
            if (IsGameMarkersTheSame(markers, 2,5,8))
            {
                return true;
            }
            if(IsGameMarkersTheSame(markers, 0,4,8))
            {
                return true;
            }
            if (IsGameMarkersTheSame(markers, 2,4,6))
            { 
                return true;
            }
            return false;
                
        }


        private static bool IsGameMarkersTheSame(char[] testGameMarkers, int pos1, int pos2, int pos3)
        {
            return (testGameMarkers[pos1].Equals(testGameMarkers[pos2]) && testGameMarkers[pos2].Equals(testGameMarkers[pos3]));
        }







        private static void gameEngine(char[] markers, int currentPlayer)
        {
            bool NotValidMove = true;
            do
            {
           
            //8 As the user places markers on the game update the obard then notify which player has a turn
            string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) && (userInput.Equals("1") ||
                    userInput.Equals("2") ||
                    userInput.Equals("3") ||
                    userInput.Equals("4") ||
                    userInput.Equals("5") ||
                    userInput.Equals("6") ||
                    userInput.Equals("7") ||
                    userInput.Equals("8") ||
                    userInput.Equals("9")))

                {
                   

                    int.TryParse(userInput, out var gamePlacementMarkers);

                    char currentMarker = markers[gamePlacementMarkers - 1];


                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Placement has already a marker please slect another placement");
                    }
                    else
                    {
                        markers[gamePlacementMarkers - 1] = currentMarker = GetPlayerMarker(currentPlayer);

                        NotValidMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Placement has alrady has a mark. Place somewhere else");
                }
                } while (NotValidMove) ;
            



        }

        //assigns markers
        private static char GetPlayerMarker(int player)
        {
            if(player % 2 ==0)
            {
                return 'O';
            }
            return 'X';
        }






        static void Display(int playerNumber)
        {
            //1. provide instructions
            //2. A greeting
            Console.WriteLine("Welcome to the game called the Tic then the Tac then the Toe!!!");
            Console.WriteLine();


            //3 Display player sign, player 1 is x and player 2 is o
            Console.WriteLine("Player 1 is X");
            Console.WriteLine("Player 2 is O");
            Console.WriteLine();
            //4 Who's turn it is
            //5 Instruct the user to enter a number between 1 and 9
            Console.WriteLine($"Player {playerNumber} to move, choose a number between 1 and 9 on the board");
            Console.WriteLine();
        }

        static void GameBoard(char[] markers) 
        {
            //draws gameboard

            Console.WriteLine($" {markers[0]} | {markers[1]} | {markers[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {markers[3]} | {markers[4]} | {markers[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {markers[6]} | {markers[7]} | {markers[8]} ");
        }



        //if pass player 1 then return player 2
        // if not return player 1
        static int GetNextPlayer(int player)
        {
            if(player.Equals(1))
            {
                return 2;
            }

            return 1;
        }


    }
}

