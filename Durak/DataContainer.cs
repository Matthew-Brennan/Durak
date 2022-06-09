using DurakLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Durak
{
    public static class DataContainer
    {
        //Holds global variable for the choice of size deck
        public static int DeckSize = 36;
        public static Deck deck;
        public static Card trumpCard;
        //public static DateTime time = new DateTime();

        //Holds the streamwriter file
        public static StreamWriter file;

        public static bool gameOver = false;

        public static Bout playingField = new Bout();

        //Holds hands
        public static Hand playerHand;
        public static Hand computerHand;

        public static PictureBox[] playerPictures = new PictureBox[6];
        public static PictureBox[] computerPictures = new PictureBox[6];

        //Holds file paths for both the statistic log and a log for the game
        public static string statPath = "../../stats/stats.log";
        public static string logPath = "../../stats/log.log";

        //Variables for the player stats file (stats.log)
        //Holds a variety of statistics for a player
        public static string playerName = "Player";
        public static int playerWins = 0;
        public static int playerTies = 0;
        public static int playerLoses = 0;
        public static int playerTotalGames = 0;
    }
}
