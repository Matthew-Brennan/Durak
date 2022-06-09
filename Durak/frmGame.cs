/**
 * frmGame.cs
 * author:       Tonya Chung
 *               Matthew Brennan
 *               Michael Sehdev
 *               Wesley Whitmore
 * date:         February 18, 2017
 * description:  A basic class with methods concerning a Bout
 * references:   Picture files were obtained from https://github.com/hayeah/playing-cards-assets/tree/master/png
 * features:     Please note the two additional features added
 *               Multiple decks (36, 20 and standard deck of cards 52)
 *               A log and a statistics file found in the .stats folder in the directory
 * */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DurakLibrary;
using System.IO;

namespace Durak
{
    public partial class frmGame : Form
    {

        public frmGame()
        {
            InitializeComponent();
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            DataContainer.gameOver = false;

            //Decides which deck to create and store in the data container
            if (DataContainer.DeckSize == 20)
            {
                DataContainer.deck = new Deck(20);
            }
            else if (DataContainer.DeckSize == 36)
            {
                DataContainer.deck = new Deck(36);
            }
            else if (DataContainer.DeckSize == 52)
            {
                DataContainer.deck = new Deck(52);
            }

            
            lblIntro.Text = "Loading...\nWelcome to Durak, " + DataContainer.playerName;
            DataContainer.file = new StreamWriter(DataContainer.logPath);
            DataContainer.file.Write(DateTime.Now.ToString());

            //lblIntro.Text = "Ready to play..";
            DataContainer.file.Close();
            lblIntro.Visible = false;

            lblName.Text = DataContainer.playerName;
            DataContainer.deck.Shuffle();
            DataContainer.trumpCard = DataContainer.deck.DrawNextCard();
            File.AppendAllText(DataContainer.logPath, Environment.NewLine + "Trump Card: " + DataContainer.trumpCard.ToString());
            picTrump.Image = (Image)Properties.Resources.ResourceManager.GetObject(DataContainer.trumpCard.PictureString());

            picDeck.Image = (Image)Properties.Resources.Back;

            //PictureBox[] playerPictures = new PictureBox[6];
            //PictureBox[] computerPictures = new PictureBox[6];

            DataContainer.playerPictures[0] = picCardP1;
            DataContainer.playerPictures[1] = picCardP2;
            DataContainer.playerPictures[2] = picCardP3;
            DataContainer.playerPictures[3] = picCardP4;
            DataContainer.playerPictures[4] = picCardP5;
            DataContainer.playerPictures[5] = picCardP6;
            DataContainer.computerPictures[0] = picCardC1;
            DataContainer.computerPictures[1] = picCardC2;
            DataContainer.computerPictures[2] = picCardC3;
            DataContainer.computerPictures[3] = picCardC4;
            DataContainer.computerPictures[4] = picCardC5;
            DataContainer.computerPictures[5] = pictureBox6;

            DataContainer.playerHand = new Hand(DataContainer.deck);
            DataContainer.computerHand = new Hand(DataContainer.deck);
            File.AppendAllText(DataContainer.logPath, Environment.NewLine + DataContainer.playerName + " " + DataContainer.playerHand.ToString());
            File.AppendAllText(DataContainer.logPath, Environment.NewLine + "Computer " + DataContainer.computerHand.ToString());
            lblStarter.Text = DataContainer.playingField.lowestTrump(DataContainer.playerHand, DataContainer.computerHand, DataContainer.trumpCard) ? "Player starts first" : "Computer starts first";
            LoadHands();
            playGame();


        }

        /// <summary>
        /// The following method handles the addition of adding a player card into the bout picture boxes
        /// Will solely only handle the bout picture box 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaceCard1(object sender, EventArgs e)
        {
            Card tempCard = DataContainer.playerHand.ElementAt(0);
            if (picBout1.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    picBout1.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[0].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout2.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(1);
                    picBout2.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[1].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout3.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(2);
                    picBout3.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[2].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout4.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(3);
                    picBout4.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[3].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout5.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(4);
                    picBout5.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[4].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(5);
                    picBout6.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[5].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
        }
        /// <summary>
        /// The following method handles the addition of adding a player card into the bout picture boxes
        /// Will solely only handle the bout picture box 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaceCard2(object sender, EventArgs e)
        {
            Card tempCard = DataContainer.playerHand.ElementAt(1);
            if (picBout1.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    picBout1.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[0].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout2.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(1);
                    picBout2.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[1].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout3.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(2);
                    picBout3.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[2].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout4.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(3);
                    picBout4.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[3].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout5.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(4);
                    picBout5.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[4].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(5);
                    picBout6.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[5].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
        }
        /// <summary>
        /// The following method handles the addition of adding a player card into the bout picture boxes
        /// Will solely only handle the bout picture box 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaceCard3(object sender, EventArgs e)
        {
            Card tempCard = DataContainer.playerHand.ElementAt(2);
            if (picBout1.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    picBout1.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[0].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout2.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(1);
                    picBout2.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[1].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout3.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(2);
                    picBout3.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[2].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout4.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(3);
                    picBout4.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[3].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout5.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(4);
                    picBout5.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[4].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(5);
                    picBout6.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[5].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
        }
        /// <summary>
        /// The following method handles the addition of adding a player card into the bout picture boxes
        /// Will solely only handle the bout picture box 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaceCard4(object sender, EventArgs e)
        {
            Card tempCard = DataContainer.playerHand.ElementAt(3);
            if (picBout1.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    picBout1.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[0].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout2.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(1);
                    picBout2.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[1].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout3.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(2);
                    picBout3.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[2].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout4.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(3);
                    picBout4.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[3].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout5.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(4);
                    picBout5.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[4].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(5);
                    picBout6.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[5].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
        }
        /// <summary>
        /// The following method handles the addition of adding a player card into the bout picture boxes
        /// Will solely only handle the bout picture box 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaceCard5(object sender, EventArgs e)
        {
            Card tempCard = DataContainer.playerHand.ElementAt(4);
            if (picBout1.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    picBout1.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[0].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card");
                }
            }
            else if (picBout2.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(1);
                    picBout2.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[1].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout3.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(2);
                    picBout3.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[2].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout4.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(3);
                    picBout4.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[3].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout5.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(4);
                    picBout5.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[4].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(5);
                    picBout6.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[5].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
        }
        /// <summary>
        /// The following method handles the addition of adding a player card into the bout picture boxes
        /// Will solely only handle the bout picture box 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlaceCard6(object sender, EventArgs e)
        {
            Card tempCard = DataContainer.playerHand.ElementAt(5);
            if (picBout1.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    picBout1.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[0].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card");
                }
            }
            else if (picBout2.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(1);
                    picBout2.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[1].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card");
                }
            }
            else if (picBout3.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(2);
                    picBout3.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[2].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout4.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(3);
                    picBout4.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[3].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
            else if (picBout5.Image == null)
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(4);
                    picBout5.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[4].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }

            }
            else
            {
                if (Attacker(DataContainer.playingField, DataContainer.playerHand.ElementAt(0)))
                {
                    tempCard = DataContainer.playerHand.ElementAt(5);
                    picBout6.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                    DataContainer.playerPictures[5].Image = (Image)Properties.Resources.Back;
                    DataContainer.playingField.AddAttack(tempCard);
                }
                else
                {
                    MessageBox.Show("Unable to play this card.");
                }
            }
        }


        /// <summary>
        /// Handles the rules of the game to handle if a card can be used to attack
        /// </summary>
        /// <param name="playingField"></param>
        /// <param name="attackCard"></param>
        /// <returns></returns>
        public bool Attacker(Bout playingField, Card attackCard)
        {
            bool canAttack = false;
            for (int iterate = 0; iterate < playingField.CurrentBoutSize(); iterate++)
            {
                if (attackCard.suit == playingField.ElementAt(iterate).suit)
                {
                    canAttack = true;
                }
            }
            if (DataContainer.playingField.CurrentBoutSize() < 6)
            {
                canAttack = true;
            }
            return canAttack;
        }


        /// <summary>
        /// Loads the hands
        /// Loads the images onto the form
        /// </summary>
        public void LoadHands()
        {
            for (int counter = 0; counter <= 5; counter++)
            {
                Card tempCard = DataContainer.playerHand.ElementAt(counter);
                Card tempCompCard = DataContainer.computerHand.ElementAt(counter);
                tempCompCard.faceUp = false;
                DataContainer.playerPictures[counter].Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                DataContainer.computerPictures[counter].Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCompCard.PictureString());  
            }
        }
        /// <summary>
        /// Handles the playing of the overall game
        /// </summary>
        /// <returns></returns>
        public void playGame()
        {
            DataContainer.gameOver = false;

            //If the player is an attacker
            if (DataContainer.playingField.lowestTrump(DataContainer.playerHand, DataContainer.computerHand, DataContainer.trumpCard))
            {
                lblRole.Text = "Attacker";
                lblRole2.Text = "Defender";
                //Allow the player's cards to be clicked
                //DataContainer.playerPictures[0].Click += PlaceCard1;
                //DataContainer.playerPictures[1].Click += PlaceCard2;
                //DataContainer.playerPictures[2].Click += PlaceCard3;
                //DataContainer.playerPictures[3].Click += PlaceCard4;
                //DataContainer.playerPictures[4].Click += PlaceCard5;
                //DataContainer.playerPictures[5].Click += PlaceCard6;
            }
            else if (!DataContainer.playingField.lowestTrump(DataContainer.playerHand, DataContainer.computerHand, DataContainer.trumpCard))
            {
                lblRole.Text = "Defender";
                lblRole2.Text = "Attacker";
                for(int index = 0; index <= 5; index++)
                {
                    //Allow the computer's cards to be clicked
                    DataContainer.playerPictures[0].Click -= PlaceCard1;
                    DataContainer.playerPictures[1].Click -= PlaceCard2;
                    DataContainer.playerPictures[2].Click -= PlaceCard3;
                    DataContainer.playerPictures[3].Click -= PlaceCard4;
                    DataContainer.playerPictures[4].Click -= PlaceCard5;
                    DataContainer.playerPictures[5].Click -= PlaceCard6;
                }
                Card tempCard = DataContainer.playingField.firstCard(DataContainer.playerHand, DataContainer.computerHand, DataContainer.trumpCard);
                picBout1.Image = (Image)Properties.Resources.ResourceManager.GetObject(tempCard.PictureString());
                DataContainer.playingField.AddAttack(tempCard);   
            }

            //while (DataContainer.gameOver == false)
            //{
                if (lblRole.Text == "Defender")
                {
                    Card tempCard = new Card();
                    int cardPlacedLast = 0;

                    //Finds latest card that was played
                    if (picBout2.Image == null)
                    {
                        tempCard = DataContainer.playingField.ElementAt(0);
                        cardPlacedLast = 1;
                    }
                    if (picBout3.Image == null)
                    {
                        tempCard = DataContainer.playingField.ElementAt(1);
                        cardPlacedLast = 2;
                    }
                    if (picBout4.Image == null)
                    {
                        tempCard = DataContainer.playingField.ElementAt(2);
                        cardPlacedLast = 3;
                    }
                    if (picBout5.Image == null)
                    {
                        tempCard = DataContainer.playingField.ElementAt(3);
                        cardPlacedLast = 4;
                    }
                    if (picBout6.Image == null)
                    {
                        tempCard = DataContainer.playingField.ElementAt(4);
                        cardPlacedLast = 5;
                    }


                    //Player is a defender

                    if (DataContainer.computerHand.ElementAt(0).rank > tempCard.rank && DataContainer.computerHand.ElementAt(0).suit == DataContainer.trumpCard.suit)
                    {

                    }
                //}
            }
        }

        private void CheckGameOver()
        {
            //Check if the players hand is empty as well as the deck
            if (DataContainer.playerHand.CurrentHandSize() == 0 && DataContainer.deck.Size() == 0)
            {
                DataContainer.playerWins += 1;
                DataContainer.gameOver = true;
                DataContainer.playerTotalGames = DataContainer.playerTotalGames + 1;
                DataContainer.playerPictures[0].Click -= PlaceCard1;
                DataContainer.playerPictures[1].Click -= PlaceCard2;
                DataContainer.playerPictures[2].Click -= PlaceCard3;
                DataContainer.playerPictures[3].Click -= PlaceCard4;
                DataContainer.playerPictures[4].Click -= PlaceCard5;
                DataContainer.playerPictures[5].Click -= PlaceCard6;
                lblIntro.Text = "GAME OVER";

            }
            //Checks if the computer's hand is empty as well as the deck
            if (DataContainer.computerHand.CurrentHandSize() == 0 && DataContainer.deck.Size() == 0)
            {
                DataContainer.playerLoses += 1;
                DataContainer.gameOver = true;
                DataContainer.playerTotalGames = DataContainer.playerTotalGames + 1;
                DataContainer.playerPictures[0].Click -= PlaceCard1;
                DataContainer.playerPictures[1].Click -= PlaceCard2;
                DataContainer.playerPictures[2].Click -= PlaceCard3;
                DataContainer.playerPictures[3].Click -= PlaceCard4;
                DataContainer.playerPictures[4].Click -= PlaceCard5;
                DataContainer.playerPictures[5].Click -= PlaceCard6;
                lblIntro.Text = "GAME OVER";
            }
        }

        /// <summary>
        /// Handles the end game when a user chooses to click the button
        /// This event can be triggered whether the game is over or not
        /// If the button is clicked when game is not over, a message box is shown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndGame_Click(object sender, EventArgs e)
        {
            if (!DataContainer.gameOver)
            {
                DialogResult forfeitBox = MessageBox.Show(DataContainer.playerName + " will forfeit the match. Do you wish to continue?", "Forfeit", MessageBoxButtons.YesNo);
                if (forfeitBox == DialogResult.Yes)
                {
                    DataContainer.playerLoses = DataContainer.playerLoses + 1;
                    DataContainer.playerTotalGames = DataContainer.playerTotalGames + 1;
                    frmEnd end = new frmEnd();
                    //File.Create(DataContainer.statPath);
                    File.AppendAllText(DataContainer.statPath,DataContainer.playerName + Environment.NewLine +
                                        "Total Number of Games: " + DataContainer.playerTotalGames + Environment.NewLine +
                                        "Wins: " + DataContainer.playerWins + Environment.NewLine +
                                        "Loses: " + DataContainer.playerLoses + Environment.NewLine + 
                                        "Ties: " + DataContainer.playerTies + Environment.NewLine);
                    this.Close();
                    end.Show();
                }
            
            }
            else
            {
                DataContainer.playerTotalGames = DataContainer.playerTotalGames + 1;
                frmEnd end = new frmEnd();
                File.AppendAllText(DataContainer.statPath, DataContainer.playerName + Environment.NewLine +
                                    "Total Number of Games: " + DataContainer.playerTotalGames + Environment.NewLine +
                                    "Wins: " + DataContainer.playerWins + Environment.NewLine +
                                    "Loses: " + DataContainer.playerLoses + Environment.NewLine +
                                    "Ties: " + DataContainer.playerTies + Environment.NewLine);
                this.Close();
                end.Show();
            }

        }


    }
}
