/**
 * Deck.cs
 * Defines a hand of cards
 * author:       Tonya Chung
 *               Matthew Brennan
 *               Michael Sehdev
 *               Wesley Whitmore
 * date:         February 18, 2017
 * description:  A basic class with methods concerning a hand
 * methods:      AddCard()             - Adds a card to a hand
 *               CardsRemaining()      - Determines how many cards
 *               RemoveNextCard()      - Removes the next card from your hand
 *               RemoveSpecificCard()  - Removes a specific card from the deck
 *               CurrentHandSize()     - Determines the current hand size
 *               AddCards()            - Add multiple cards to the hand
 *               AddRemaining()        - Add the remaining required cards back into the hand
 *               ToString()            - Returns the actual hand
 *               ElementAt()           - Indexes the card
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakLibrary
{
    public class Hand
    {
        //A hand can only hold up to a maximum of 6 cards at one time
        const int MAXIMUM_CARDS = 5;
        Deck standardDeck = new Deck();
        List<Card> hand = new List<Card>();

        /**
         * Constructor that adds all the next cards based off a deck
         * */
        public Hand()
        {
            for (int counter = 0; counter <= MAXIMUM_CARDS; counter++)
            {
                hand.Add(standardDeck.DrawNextCard());
            }
        }

        /**
         * Constructor that creates a hand from a deck
         * @param deckToUse
         * */
        public Hand(Deck deckToUse)
        {
            {
                for (int counter = 0; counter <= MAXIMUM_CARDS; counter++)
                {
                    hand.Add(deckToUse.DrawNextCard());
                }
            }
        }

        /**
         * Add Card
         * @param someDeck
         * Adds a card to the hand based off the deck
         * */
        public void AddCard(Deck someDeck)
        {
            if (hand.Count < MAXIMUM_CARDS)
            {
                hand.Add(someDeck.DrawNextCard());
            }
            else
            {
                throw new Exception("Your Hand is full!");
            }
        }

        /**
         * Calculates the cards remaining 
         * */
        public int CardsRemaining()
        {
            return hand.Capacity - hand.Count - 2;
        }

        /**
         * Removes the next card from the hand
         * @throws new Exception if there are no cards in the hand
         * */
        public void RemoveNextCard()
        {
            if (hand.Count != 0)
            {
                hand.RemoveAt(0);
            }
            else
            {
                throw new Exception("No more cards to remove out of your hand!");
            }
        }

        /**
         * Removes a specific card from the hand 
         * @param spot 
         * @throws if there are no cards
         * */
        public void RemoveSpecificCard(int spot)
        {
            if (hand.Count != 0)
            {
                hand.RemoveAt(spot);
            }
            else
            {
                throw new Exception("No more cards to remove out of your hand!");
            }
        }

        /**
         * Calculates the current hand size 
         * */
        public int CurrentHandSize()
        {
            return hand.Count;
        }

        /**
         * Add a set amount cards
         * @param cardsNeeded Determines how many cards are needed left
         * @param someDeck    Passes the deck that the hand will draw it's cards from
         * */
        public void AddCards(int cardsNeeded, Deck someDeck)
        {
            if (hand.Count <= MAXIMUM_CARDS)
            {
                for (int counter = 0; counter <= cardsNeeded; counter++)
                {
                    hand.Add(someDeck.DrawNextCard());
                }
            }
        }

        /**
         * Add all the cards needed to fill the maximum hand capacity
         * @param Deck      The deck used to draw the cards from
         * */
        public void AddRemaining(Deck someDeck)
        {
            int cardsNeeded = CardsRemaining() - 1;

            if (hand.Count <= MAXIMUM_CARDS)
            {
                for (int counter = 0; counter <= cardsNeeded; counter++)
                {
                    hand.Add(someDeck.DrawNextCard());
                }
            }
        }

        /**
         * Converts the hands to a string
         * */
        public override string ToString()
        {
            string currentHand = ("Hand:");
            if (hand.Count != 0)
            {
                foreach (Card card in hand)
                {
                    currentHand = currentHand + card.ToString() + ", ";
                }
            }
            else
            {
                throw new Exception("Empty Hand");
            }
            return currentHand;
        }

        /**
         * Indexes the location of the hand 
         * */
        public Card ElementAt(int index)
        {
            return hand.ElementAt(index);
        }
    }
}
