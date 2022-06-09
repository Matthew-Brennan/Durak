/**
 * Deck.cs
 * Defines a deck of Cards
 * author:       Tonya Chung
 *               Matthew Brennan
 *               Michael Sehdev
 *               Wesley Whitmore
 * date:         February 18, 2017
 * description:  A basic class with methods concerning a deck
 * methods:      Size()             - Determines the size of the deck
 *               Shuffle()          - Shuffles the deck
 *               DrawNextCard()     - Draws the next card on top of the deck
 *               DrawRandomCard()   - Draws a random card from the deck
 * */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DurakLibrary
{
    public class Deck : IEnumerable<Card>
    {
        List<Card> deck = new List<Card>();
        const int MAXIMUM_CARDS = 52;
        private static readonly Random randomizer = new Random();

        public Deck()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    deck.Add(new Card(rankVal, suitVal));
                }
            }
        }

        public Deck(int size)
        {
            if (size == 20)
            {
                for (int suitValue = 0; suitValue < 4; suitValue++)
                {
                    for (int rankValue = 9; rankValue < 14; rankValue++)
                    {
                        deck.Add(new Card(rankValue, suitValue));
                    }
                }
            }
            else if (size == 36 || size != 52)
            {
                for (int suitNum = 0; suitNum < 4; suitNum++)
                {
                    for (int rankNum = 5; rankNum < 14; rankNum++)
                    {
                        deck.Add(new Card(rankNum, suitNum));
                    }
                }
            }
            else
            {
                for (int suitNum = 0; suitNum < 4; suitNum++)
                {
                    for (int rankNum = 1; rankNum < 14; rankNum++)
                    {
                        deck.Add(new Card(rankNum, suitNum));
                    }
                }
            }
        }
        public IEnumerator<Card> GetEnumerator()
        {
            return deck.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return deck.GetEnumerator();
        }

        public int Size()
        {
            return deck.Count;
        }
        /// <summary>
        /// Shuffle()
        /// Shuffles a deck based off of the Fisher-Yates shuffle
        /// </summary>
        public void Shuffle()
        {
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = randomizer.Next(n + 1);
                Card value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        public Card DrawNextCard()
        {
            Card nextCard = new Card();
            if (deck.Count != 0)
            {
                Card tempCard = deck.First();
                nextCard.rank = tempCard.rank;
                nextCard.suit = tempCard.suit;
                deck.RemoveAt(0);
            }
            else
            {
                throw new Exception("No more cards in the deck");
            }
            return nextCard;
        }

        public Card DrawRandomCard()
        {
            Card randomCard = new Card();
            if (deck.Count != 0)
            {
                int randomSpot = randomizer.Next(1, deck.Count);
                Card tempCard = deck[randomSpot];
                randomCard.rank = tempCard.rank;
                randomCard.suit = tempCard.suit;
                deck.RemoveAt(randomSpot);
            }
            else
            {
                throw new Exception("No more cards in the deck");
            }
            return randomCard;
        }
    }
}

