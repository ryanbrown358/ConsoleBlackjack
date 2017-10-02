using System;

namespace ConsoleBlackJack
{
    class Program
    {
        static string[] playerCards = new string[12]; // create a new string array named playerCards, which we will store our cards in. The maximum index is 12 (so the most you can hold is 11 cards.)

        static string hitOrStay = ""; // create a string variable named hitOrStay to ask to hit or stay.

        static int total = 0, count = 1, dealerTotal = 0; // create three integer variables named total, which is for our total, count, which is our variable to get an index in our array (we increase to hold multiple cards), and dealerTotal, which is, obviously, the dealer's total.

        static Random cardRandomizer = new Random(); // create a new instance of Random called cardRandomizer so we can randomize our cards and the dealer's total.




        static void Main(string[] args)
        {


            Start();

        }

        static string Deal()
        {
            string Card = " ";
            int cards = cardRandomizer.Next(1, 14);
            switch (cards)
            {
                case 1:
                    Card = "Two"; total += 2;
                    break;
                case 2:
                    Card = "Three"; total += 3;
                    break;
                case 3:
                    Card = "Four"; total += 4;
                    break;
                case 4:
                    Card = "Five"; total += 5;
                    break;
                case 5:
                    Card = "Six"; total += 6;
                    break;
                case 6:
                    Card = "Seven"; total += 7;
                    break;
                case 7:
                    Card = "Eight"; total += 8;
                    break;
                case 8:
                    Card = "Nine"; total += 9;
                    break;
                case 9:
                    Card = "Ten"; total += 10;
                    break;
                case 10:
                    Card = "Jack"; total += 10;
                    break;
                case 11:
                    Card = "Queen"; total += 10;
                    break;
                case 12:
                    Card = "King"; total += 10;
                    break;
                case 13:
                    Card = "Ace"; total += 11;
                    break;
                default:
                    Card = "2"; total += 2;
                    break;






            }
            return Card;
        }

        static void Start()
        {
            dealerTotal = cardRandomizer.Next(15, 22); // A Random number between 15 and 22, and 21 for the dealers number
            playerCards[0] = Deal(); // Assigns the index 0 (our first index ) of playerCards[] to the returned vaule of Deal(); this is our second card

            do
            {
                Console.WriteLine("Welcome to Blackjack! you were dealed" + playerCards[0] + " and " + playerCards[1] + ".\nYour total is " + total + ".\nWould you like to hit or stay?");
                hitOrStay =
                    Console.ReadLine().ToLower();
            } while
                (!hitOrStay.Equals("hit") && !hitOrStay.Equals("stay"));
            Game(); // call the game method 
        }

        static void Game()
        {
            if (hitOrStay.Equals("hit")) // we asked the user to hit or stay, and if they chose to hit..
            {
                Hit(); // call the hit method 
            }
            else if (hitOrStay.Equals("stay")) // if they chose to stay //
            {
                if (total > dealerTotal && total <= 21) // if our total is greater than the dealers total and less than 21
                {
                    Console.WriteLine("\nCongrats! You won the game! The dealer's total was " + dealerTotal + ".\nWould you like to play again? y/n"); // tell the user the won, tell them the dealer's total, and ask them to play again

                    playAgain();// Call the method playagain();

                }
                else if (total < dealerTotal)
                {
                    Console.WriteLine(".\nSorry, The dealers total was" + dealerTotal + ".\nWould you like to play again? y/n"); // Tell the user they lost, tell them the dealers total and ask them if they want to play again 
                    playAgain();
                }
            }
        }

        static void Hit()
        {
            count += 1; // add one to count (count is where we get the number to index playerCards)

            playerCards[count] = Deal(); // Deal a card to our next available index in playerCards();

            Console.WriteLine(".\nYou were dealed a(n) " + total + playerCards[count] + "."); // Tell the user what they were dealed 

            if (total.Equals(21))
            {
                Console.WriteLine(".\nYou got Blackjack! the dealer's total was " + dealerTotal + ".\nWould you like to play again?"); // tell the user they got balckjack, tell them the dealers total and ask themt o play again 
                playAgain();

            }
            else if (total > 21)
            {
                Console.WriteLine(".\nYou busted! the dealer's total was " + dealerTotal + ".\nWould you like to play again? y/n"); // tell the user they busted, tell the user the dealers total and ask them to play again.
                playAgain();
            }
            else // otherwise.. (less than 21)
         
            {
                
            do
                    
            {
                    
            Console.WriteLine("\nWould you like to hit or stay?");
                    
            hitOrStay = Console.ReadLine().ToLower();
                    
            } while (!hitOrStay.Equals("hit") && !hitOrStay.Equals("stay")) ; // ask the user to hit or stay, and loop it until they give an acceptable answer
                
                Game(); // call the Game() method
                
            }
            
        }

        static void playAgain()
        {
            string playAgain = ""; // create a string to ask to play again

            do
            {
                playAgain = Console.ReadLine().ToLower();
            } while (!playAgain.Equals("y") && !playAgain.Equals("n")); // in the other methods, we asked if they wanted to play again, now we're just getting input and looping it untill they give an answer 

            if (playAgain.Equals("y")) // if they want to play again
            {
                Console.WriteLine(".\n Press enter to restart the game");
                Console.ReadKey(); // get input (enter)
                Console.Clear(); // clears the console. 
                dealerTotal = 0; // reset the dealer's total 
                count = 1; // reset the count
                total = 0; // reset the total
                Start(); // call the start method to start a new game 
            }
            else if (playAgain.Equals("n"))
            {
                Console.WriteLine(".\nPress enter to exit Blackjack."); // tells them to press enter to close the game
                Console.ReadLine();
                Environment.Exit(0);
            }
        }



    }

}
    

    
        


