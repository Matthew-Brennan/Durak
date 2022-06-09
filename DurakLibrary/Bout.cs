/**
 * Deck.cs
 * Defines a bout, the cards played in the middle of the game
 * author:       Tonya Chung
 *               Matthew Brennan
 *               Michael Sehdev
 *               Wesley Whitmore
 * date:         February 18, 2017
 * description:  A basic class with methods concerning a Bout
 * methods:      AddAttack()         - Adds card to the hand
 *               ToString()          - Converts the bout into a string (as if it were a hand)
 *               CurrentBoutSize()   - Determines the current size of the bout
 *               ElementAt()         - Indexes the element in a bout
 *               LowestTrump()       - Determines the lowest trump card between the two hands
 *               FirstCard()         - Determines the first card to be added into the boutls
 * */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakLibrary
{
    public class Bout : IEnumerable
    {
        List<Card> bout = new List<Card>();
        public Bout()
        {

        }

        public Bout(Card firstCard)
        {
            bout.Add(firstCard);
        }

        public IEnumerator<Card> GetEnumerator()
        {
            return bout.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return bout.GetEnumerator();
        }

        /**
         * Adds a card to the bout
         * @param cardToAttack
         * */
        public void AddAttack(Card cardToAdd)
        {
            bout.Add(cardToAdd);
        }

        /**
         * Displays the bout into a string
         * @return the bout into a string
         * */
        public override string ToString()
        {
            string playingCards = "";

            if (bout.Count != 0)
            {
                foreach (Card card in bout)
                {
                    playingCards = playingCards + card.ToString() + ", ";
                }
            }
            return playingCards;
        }

        /**
         * Determines the current size
         * @return the size of the bout
         * */
        public int CurrentBoutSize()
        {
            return bout.Count;
        }

        /**
         * Indexes the card specific in the bout
         * @param index
         * */
        public Card ElementAt(int index)
        {
            return bout.ElementAt(index);
        }

        /**
         *  Determines which hand (attackerhand = true, defender = false) hast he lowest trump card
         *  @param attackerHand 
         *  @param defender
         *  @param trumpCard
         *  @return boolean
         * */
        public bool lowestTrump(Hand attackerHand, Hand defender, Card trumpCard)
        {
            bool hasTrump = true;
            Card tempCardA = new Card();
            Card tempCardB = new Card();
            if (trumpCard.suit == 0)
            {
                tempCardA.suit = 0;
                tempCardA.rank = 13;
                tempCardB.suit = 0;
                tempCardB.rank = 13;
            }
            if (trumpCard.suit != 0)
            {
                tempCardA.suit = 3;
                tempCardA.rank = 13;
                tempCardB.suit = 3;
                tempCardB.rank = 13;
            }

            for (int iterate = 0; attackerHand.CurrentHandSize() < iterate; iterate++)
            {
                if (trumpCard.suit == attackerHand.ElementAt(iterate).suit)
                {
                    if (attackerHand.ElementAt(iterate).rank < tempCardA.rank)
                    {
                        tempCardA.rank = attackerHand.ElementAt(iterate).rank;
                        tempCardA.suit = attackerHand.ElementAt(iterate).suit;
                    }
                }

            }

            for (int counter = 0; defender.CurrentHandSize() < counter; counter++)
            {

                if (trumpCard.suit == defender.ElementAt(counter).suit)
                {
                    if (defender.ElementAt(counter).rank < tempCardA.rank)
                    {
                        tempCardB.rank = defender.ElementAt(counter).rank;
                        tempCardB.suit = defender.ElementAt(counter).suit;
                    }
                }
            }

            if (tempCardA.suit == trumpCard.suit && tempCardB.suit == trumpCard.suit)
            {
                if (tempCardA.rank < tempCardB.rank)
                {
                    hasTrump = true;
                }
                else
                {
                    hasTrump = false;
                }
            }
            else if (tempCardA.suit == trumpCard.suit && tempCardB.suit != trumpCard.suit)
            {
                //The player gets to start, when no one has trump card
                hasTrump = true;
            }
            else if (tempCardA.suit != trumpCard.suit && tempCardB.suit == trumpCard.suit)
            {
                //The computer has the lowest trump card
                hasTrump = false;
            }
            else //Neither hands have the trump card, by default the player gets to start first
            {
                hasTrump = true;
            }
            return hasTrump;
        }

        /**
         * Determines the exact first card to be placed depending on the hand with the lowest trump card
         * @param attackerHand
         * @param defender
         * @param trumpCard
         * @return the card that would be played first
         * */
        public Card firstCard(Hand attackerHand, Hand defender, Card trumpCard)
        {
            bool trumpHand = lowestTrump(attackerHand, defender, trumpCard);
            Card aCard = new Card();
            if (trumpCard.suit == 0)
            {
                aCard.suit = 0;
                aCard.rank = 13;
            }
            if (trumpCard.suit != 0)
            {
                aCard.suit = 3;
                aCard.rank = 13;
            }

            if (trumpHand)
            {
                for (int iterate = 0; iterate < attackerHand.CurrentHandSize(); iterate++)
                {
                    if (attackerHand.ElementAt(iterate).suit == trumpCard.suit)
                    {
                        if (attackerHand.ElementAt(iterate).rank < aCard.rank)
                        {
                            aCard.rank = attackerHand.ElementAt(iterate).rank;
                            aCard.suit = attackerHand.ElementAt(iterate).suit;
                        }
                    }
                }
                if (aCard.suit != trumpCard.suit)
                {
                    for (int iterate = 0; iterate < attackerHand.CurrentHandSize(); iterate++)
                    {
                        if (attackerHand.ElementAt(iterate) < aCard)
                        {
                            aCard.rank = attackerHand.ElementAt(iterate).rank;
                            aCard.suit = attackerHand.ElementAt(iterate).suit;
                        }
                    }
                }
            }
            if (!trumpHand)
            {
                for (int iterate = 0; iterate < defender.CurrentHandSize(); iterate++)
                {
                    if (defender.ElementAt(iterate).suit == trumpCard.suit)
                    {
                        if (defender.ElementAt(iterate).rank < aCard.rank)
                        {
                            aCard.rank = defender.ElementAt(iterate).rank;
                            aCard.suit = defender.ElementAt(iterate).suit;
                        }
                    }
                }
            }
            return aCard;

        }

    }
}
