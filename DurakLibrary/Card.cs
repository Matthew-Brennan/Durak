/**
 * Card.cs
 * Defines a standard playing card
 * author:       Tonya Chung
 *               Matthew Brennan
 *               Michael Sehdev
 *               Wesley Whitmore
 * date:         February 18, 2017
 * description:  A basic class for the card class
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurakLibrary
{
    public class Card : IComparable<Card>, IEquatable<Card>
    {
        //Constant read-only variables for the suits and ranks of a card
        public static readonly string[] SUITS = { "Spades", "Hearts", "Diamonds", "Clubs" };
        public static readonly string[] RANKS = {"Not Used", "Two", "Three", "Four", "Five",
                                                    "Six", "Seven", "Eight", "Nine", "Ten", "Jack",
                                                    "Queen", "King", "Ace"};
        //Maxmium and minimum values for the rank and suits
        const int MINIMUM_RANK = 1;  //Ace    - in respect to the RANK[]
        const int MAXIMUM_RANK = 13; //King   - in respect to the RANK[]
        const int MINIMUM_SUIT = 0;  //Spades - in respect to the SUITS[]
        const int MAXIMUM_SUIT = 3;  //Clubs  - in respect to the SUITS[]

        /// <summary>
        /// Card()
        /// Constructor for a card that automatically sets a playing card to a Ace Spades
        /// </summary>
        public Card()
        {
            this.myRank = 1;
            this.mySuit = 1;
            this.myFaceUp = true;
        }

        /// <summary>
        /// Card()
        /// Parameterized constructor for a card
        /// </summary>
        /// <param name="newRank"></param>
        /// <param name="newSuit"></param>
        /// <param name="isFaceUp"></param>
        public Card(int newRank, int newSuit, bool isFaceUp)
        {
            rank = newRank;
            suit = newSuit;
            myFaceUp = isFaceUp;
        }

        /// <summary>
        /// Card()
        /// Parameterized Constructor for a card
        /// Note: Automatically sets the card to be face up
        /// </summary>
        /// <param name="newRank"></param>
        /// <param name="newSuit"></param>
        public Card(int newRank, int newSuit)
        {
            rank = newRank;
            suit = newSuit;
            myFaceUp = true;
        }

        /// <summary>
        /// Property for myRank for a card
        /// </summary>
        private int myRank;
        public int rank
        {
            //Accessors to obtain the rank of the card
            get
            {
                return myRank;
            }
            //Mutator to set a rank for a card object
            set
            {
                //Checks if the rank is valid
                if (value < MINIMUM_RANK || value > MAXIMUM_RANK)
                {
                    throw (new ArgumentOutOfRangeException(value + " is out of range." + " Rank of a card must be between " + MINIMUM_RANK + " and " + MAXIMUM_RANK));
                }
                else
                {
                    myRank = value;
                }
            }
        }
        /// <summary>
        /// Property for mySuit for a card
        /// </summary>
        private int mySuit;
        public int suit
        {
            //Accessor for mySuit
            get
            {
                return mySuit;
            }
            //Mutator to set a rank for a card object
            set
            {
                //Checks if the suit is valid
                if (value < MINIMUM_SUIT || value > MAXIMUM_SUIT)
                {
                    throw (new ArgumentOutOfRangeException(value + " is out of range." + " Suit of a card must be between " + MINIMUM_SUIT + " and " + MAXIMUM_SUIT));
                }
                else
                {
                    mySuit = value;
                }
            }
        }
        /// <summary>
        /// Property for myFaceUp
        /// </summary>
        private bool myFaceUp;
        public bool faceUp
        {
            //Accessor to check if the card is face up
            get
            {
                return myFaceUp;
            }
            //Mutator to set myFaceUp accordingly
            set
            {
                this.myFaceUp = value;
            }
        }
        /// <summary>
        /// getRankString()
        /// Gets the rank in a string format as opposed to an integer
        /// </summary>
        /// <returns>string - RANKS[myRank]</returns>
        public string getRankString()
        {
            return RANKS[myRank];
        }

        /// <summary>
        /// getSuitString()
        /// </summary>
        /// <returns>string - SUIT[mySuit]</returns>
        public string getSuitString()
        {
            return SUITS[mySuit];
        }
        /// <summary>
        /// CompareTo()
        /// Compares a card object to another card object
        /// </summary>
        /// <param name="otherCard"></param>
        /// <returns></returns>
        public int CompareTo(Card otherCard)
        {
            int value;
            if (rank == otherCard.rank && suit == otherCard.suit)
            {
                value = 0;
            }
            else if (rank > otherCard.rank)
            {
                value = 1;
            }
            else
            {
                value = -1;
            }
            return value;
        }
        /// <summary>
        /// Equals()
        /// Compares two card objects and determines if they are equal to one another
        /// </summary>
        /// <param name="secondCard"></param>
        /// <returns></returns>
        public bool Equals(Card secondCard)
        {
            return (rank == secondCard.rank && suit == secondCard.suit);
        }
        /// <summary>
        /// >
        /// Overloaded operator to determine if one card object is greater than another card object
        /// </summary>
        /// <param name="cardOne"></param>
        /// <param name="cardTwo"></param>
        /// <returns></returns>
        public static bool operator >(Card cardOne, Card cardTwo)
        {
            return cardOne.CompareTo(cardTwo) > 0;
        }
        /// <summary>
        /// Overloaded operator to determine if one card object is less than another card object
        /// </summary>
        /// <param name="cardOne"></param>
        /// <param name="cardTwo"></param>
        /// <returns>bool </returns>
        public static bool operator <(Card cardOne, Card cardTwo)
        {
            return cardOne.CompareTo(cardTwo) < 0;
        }
        /// <summary>
        /// ==
        /// Overloaded operator to determine if one card object is equal to another card object
        /// </summary>
        /// <param name="cardOne"></param>
        /// <param name="cardTwo"></param>
        /// <returns></returns>
        public static bool operator ==(Card cardOne, Card cardTwo)
        {
            return cardOne.Equals(cardTwo);
        }
        /// <summary>
        /// !=
        /// Overloaded operator to determine if one card object does not equal another card object
        /// </summary>
        /// <param name="cardOne"></param>
        /// <param name="cardTwo"></param>
        /// <returns></returns>
        public static bool operator !=(Card cardOne, Card cardTwo)
        {
            return !cardOne.Equals(cardTwo);
        }

        /// <summary>
        /// toString()
        /// Overriden method to display a card
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string cardString;
            if (faceUp)
            {
                cardString = getRankString() + " " + getSuitString();
            }
            else
            {
                cardString = "Face-Down";
            }
            return cardString;
        }

        public string PictureString()
        {
            string nameString = "";
            if (faceUp)
            {
                nameString = getRankString() + getSuitString();
            }
            else
            {
                nameString = "Back";
            }
            return nameString;
        }
    }
}
