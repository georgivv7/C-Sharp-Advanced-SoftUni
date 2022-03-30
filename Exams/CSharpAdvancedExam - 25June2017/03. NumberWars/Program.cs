using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cardsPlayer1 = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));
            var cardsPlayer2 = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));
            int turn = 0;
            bool gameOver = false;
            while (turn < 1000000 && cardsPlayer1.Count > 0 && cardsPlayer2.Count > 0 && !gameOver)
            {
                turn++;
                string firstCard = cardsPlayer1.Dequeue();
                string secondCard = cardsPlayer2.Dequeue();
                if (GetNumber(firstCard) > GetNumber(secondCard))
                {
                    cardsPlayer1.Enqueue(firstCard);
                    cardsPlayer1.Enqueue(secondCard);
                }
                else if (GetNumber(secondCard) > GetNumber(firstCard))
                {
                    cardsPlayer2.Enqueue(secondCard);
                    cardsPlayer2.Enqueue(firstCard);
                }
                else
                {
                    var cardsHand = new List<string> { firstCard, secondCard };
                    while (!gameOver)
                    {
                        if (cardsPlayer1.Count >= 3 && cardsPlayer2.Count >= 3)
                        {
                            int firstSum = 0;
                            int secondSum = 0;
                            for (int count = 0; count < 3; count++)
                            {
                                var firstHandCard = cardsPlayer1.Dequeue();
                                var secondHandCard = cardsPlayer2.Dequeue();
                                firstSum += GetChar(firstHandCard);
                                secondSum += GetChar(secondHandCard);
                                cardsHand.Add(firstHandCard);
                                cardsHand.Add(secondHandCard);
                            }
                            if (firstSum > secondSum)
                            {
                                AddsCardToWinner(cardsHand, cardsPlayer1);
                                break;
                            }
                            else if (secondSum > firstSum)
                            {
                                AddsCardToWinner(cardsHand, cardsPlayer2);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                }
            }
            string result = string.Empty;

            if (cardsPlayer1.Count == cardsPlayer2.Count)
            {
                result = "Draw";
            }
            else if (cardsPlayer1.Count > cardsPlayer2.Count)
            {
                result = "First player wins";
            }
            else if (cardsPlayer1.Count < cardsPlayer2.Count)
            {
                result = "Second player wins";
            }
            Console.WriteLine($"{result} after {turn} turns");
        }
        static void AddsCardToWinner(List<string> cardsHand, Queue<string> cardsPlayer)
        {
            foreach (var card in cardsHand.OrderByDescending(x=>GetNumber(x))
                .ThenByDescending(x=>GetChar(x)))
            {
                cardsPlayer.Enqueue(card);
            }
        }
        static int GetNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }
        static int GetChar(string card)
        {
            return card[card.Length - 1];
        }
    }
}
