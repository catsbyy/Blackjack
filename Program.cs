using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\tWelcome!\n\tHope you know the rules so we can begin playing immediately!\n\t\t\tDealer has to stop on 17");
            Console.Write("Press any key to start the game: ");
            Console.ReadKey();
            Random cards = new Random((int)(DateTime.Now.Ticks));
            int[] playercard = new int[50];
            int[] dealercard = new int[50];
            playercard[0] = cards.Next(1,12);
            playercard[1] = cards.Next(1, 12);
            dealercard[0] = cards.Next(1, 12);
            dealercard[1] = cards.Next(1, 12);
            int playersum = 0, dealersum = 0, j =2, i = 2;
            int x = 0, y = 10;
            playersum = playercard[0] + playercard[1];
            dealersum = dealercard[0] + dealercard[1];
            if (playersum == 21 || dealersum == 21)
            {
                if (playersum > dealersum) Console.WriteLine("You've won");
                if (playersum < dealersum) Console.WriteLine("Dealer's won");
                else Console.WriteLine($"Yours: {playercard[0]}, {playercard[1]}.\nDealer's: {dealercard[0]}, {dealercard[1]}.\nDraw");
            }
            else
            {
            Console.WriteLine($"\n\nWell, you've got {playercard[0]} and {playercard[1]} ({playersum = playercard[0]+playercard[1]} in total)");
            Console.WriteLine($"Dealer has got {dealercard[0]} and ?");
            string readkey = "";
            while (readkey != "e" || playersum <= 21)
            {
                Console.WriteLine("\nDo you want another one card (press 'a') or enough (press 'e')?");
                readkey = Console.ReadLine();
                if (playersum > 21)
                {
                    Console.WriteLine($"You have {playersum}.\nDealer's cards: {dealercard[0]}, {dealercard[1]}. In total {dealersum}. Dealer has won."); break;
                }
                if (readkey == "e" || playersum == 21)
                {
                    Console.SetCursorPosition(x, y - 1);
                    Console.WriteLine(" ");
                    Console.WriteLine("You have " + playersum);
                    Console.Write("Dealer has " + dealercard[0] + ", " + dealercard[1]);
                    if (dealersum < 17)
                    {
                        while (dealersum <= 17)
                        {
                            dealercard[j] = cards.Next(1, 12);
                            Console.Write(", " + dealercard[j]);
                            dealersum += dealercard[j];
                        }
                        if (dealersum > 21)
                            {
                                Console.WriteLine("\nDealer has more than 21. You have won."); break;
                            }
                            if (dealersum > playersum)
                            { Console.WriteLine($"\nDealer's total: {dealersum}. Dealer has won."); break; }
                            if (dealersum < playersum)
                            { Console.WriteLine($"\nDealer's total: {dealersum}. You have won."); break; }
                            else
                            { Console.WriteLine($"\nDealer's total: {dealersum}. Draw"); break; }
                        }
                       else
                        {
                            if (playersum>dealersum)
                            {
                                Console.WriteLine("Dealer's total: " + dealersum + " You won."); break;
                            }
                            if (playersum < dealersum)
                            {
                                Console.WriteLine("Dealer's total: " + dealersum + " Dealer won."); break;
                            }
                            else
                            {
                                Console.WriteLine("Dealer's total: " + dealersum + " Draw."); break;
                            }
                        }
                }
                if (readkey == "a")
                {
                    Console.SetCursorPosition(x, y - 1);
                    Console.WriteLine(" ");
                    y += 4;
                    Console.WriteLine($"Here we go: {playercard[i] = cards.Next(1, 12)} - {playersum+=playercard[i]} in total");
                    if (playersum > 21)
                    {
                        Console.WriteLine("You have more than 21. Dealer has won."); break;
                        }
                    
                }
                i++;
            }

            }
            Console.WriteLine();
        }

    }

}
