using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using System.Reflection;
using System.IO;

namespace Bang_Revolution_Client
{
    public partial class frmMain : Form
    {
        User thisUser = new User();
        Player thisPlayer = new Player();
        List<Player> players = new List<Player>();
        Card selectedCard = new Card();
        public frmMain()
        {
            InitializeComponent();
            players = Program.generateDummyData(); // DUMMY DATA
            getThisPlayer();
            updateBoard();
        }

        public void getThisPlayer()
        {
            thisUser.id = 4; // DUMMY DATA
            foreach (Player player in players)
            {
                if (player.id == thisUser.id)
                {
                    thisPlayer = player;
                    break;
                }
            }
        }

        public void updateBoard()
        {
            updatePlayers();
            updateActions();
            updateHand();
        }

        public void updatePlayers()
        {
            pnlPlayers.Controls.Clear();
            int thisPlayerPos = 3;
            for (int i = 0; i < players.Count; i++)
            {
                if (players.ElementAt(i).id == thisPlayer.id)
                {
                    thisPlayerPos = i;
                }
            }
            int loc = 0;
            for (int i = thisPlayerPos + 1; i != thisPlayerPos;)
            {
                string path = getImagePath(players.ElementAt(i).character.img);
                Bitmap image1 = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("Bang_Revolution_Client.Resources." + path));
                Label charImage = new Label();
                charImage.Size = new Size(150, 231);
                charImage.Image = (Image)(new Bitmap(image1, charImage.Size));
                charImage.Location = new Point(loc * 150 + 30 * (loc + 1), 0);
                pnlPlayers.Controls.Add(charImage);
                Label playerName = new Label();
                playerName.Size = new Size(150, 24);
                playerName.Location = new Point(loc * 150 + 30 * (loc + 1), 250);
                playerName.Text = players.ElementAt(i).name;
                pnlPlayers.Controls.Add(playerName);

                Label playerHP = new Label();
                playerHP.Size = new Size(150, 24);
                playerHP.Location = new Point(loc * 150 + 30 * (loc + 1), 274);
                playerHP.Text = "HP: " + players.ElementAt(i).currentHP + "/" + players.ElementAt(i).maxHP;
                pnlPlayers.Controls.Add(playerHP);

                Label playerCards = new Label();
                playerCards.Size = new Size(150, 24);
                playerCards.Location = new Point(loc * 150 + 30 * (loc + 1), 298);
                playerCards.Text = "Cards on hand: " + players.ElementAt(i).cardsOnHand.Count;
                pnlPlayers.Controls.Add(playerCards);

                loc++;
                if (i < players.Count - 1)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
        }

        public void updateActions()
        {
            pnlActions.Controls.Clear();
            int thisPlayerPos = 3;
            for (int i = 0; i < players.Count; i++)
            {
                if (players.ElementAt(i).id == thisPlayer.id)
                {
                    thisPlayerPos = i;
                }
            }
            int loc = 0;
            for (int i = thisPlayerPos + 1; i != thisPlayerPos;)
            {
                if (canBangPlayer(players.ElementAt(i)))
                {
                    Button btnBang = new Button();
                    btnBang.Location = new Point(loc * 150 + 30 * (loc + 1), 0);
                    btnBang.Size = new Size(150, 24);
                    btnBang.Text = "BANG!";
                    btnBang.Tag = i;
                    btnBang.Click += new EventHandler(btnBangClicked);
                    pnlActions.Controls.Add(btnBang);
                }
                else if (canPanicPlayer(players.ElementAt(i)))
                {
                    Button btnPanic = new Button();
                    btnPanic.Location = new Point(loc * 150 + 30 * (loc + 1), 0);
                    btnPanic.Size = new Size(150, 24);
                    btnPanic.Text = "Panic!";
                    btnPanic.Tag = i;
                    btnPanic.Click += new EventHandler(btnPanicClicked);
                    pnlActions.Controls.Add(btnPanic);
                }
                else if (canCatBalou(players.ElementAt(i)))
                {
                    Button btnCatBalou = new Button();
                    btnCatBalou.Location = new Point(loc * 150 + 30 * (loc + 1), 0);
                    btnCatBalou.Size = new Size(150, 24);
                    btnCatBalou.Text = "Cat Balou";
                    btnCatBalou.Tag = i;
                    btnCatBalou.Click += new EventHandler(btnCatBalouClicked);
                    pnlActions.Controls.Add(btnCatBalou);
                }
                loc++;
                if (i < players.Count - 1)
                {
                    i++;
                }
                else
                {
                    i = 0;
                }
            }
            if (pnlActions.Controls.Count == 0 && selectedCard.name != null)
            {
                Button btnUseCard = new Button();
                btnUseCard.Location = new Point(pnlActions.Width / 2 - 100, 0);
                btnUseCard.Size = new Size(200, 24);
                btnUseCard.Text = "Use card";
                btnUseCard.Click += new EventHandler(btnUsedCardClicked);
                pnlActions.Controls.Add(btnUseCard);
            }
        }

        public void updateHand()
        {
            pnlHand.Controls.Clear();
            for (int i = 0; i < thisPlayer.cardsOnHand.Count; i++)
            {
                string path = getImagePath(thisPlayer.cardsOnHand.ElementAt(i).img);
                Bitmap image1 = new Bitmap(Assembly.GetExecutingAssembly().GetManifestResourceStream("Bang_Revolution_Client.Resources." + path));
                Label label1 = new Label();
                label1.Size = new Size(150, 231);
                label1.Image = (Image)(new Bitmap(image1, label1.Size));
                label1.Location = new Point(i * 150 + 10 * (i + 1) + 150, 24);
                pnlHand.Controls.Add(label1);
                RadioButton rdb = new RadioButton();
                rdb.Size = new Size(150, 24);
                rdb.Location = new Point(i * 150 + 10 * (i + 1) + 150, 0);
                rdb.CheckAlign = ContentAlignment.MiddleCenter;
                rdb.Tag = i;
                rdb.CheckedChanged += new EventHandler(selectedCardChanged);
                pnlHand.Controls.Add(rdb);
                if (thisPlayer.cardsOnHand.Count > thisPlayer.currentHP)
                {
                    Button btnDiscard = new Button();
                    btnDiscard.Size = new Size(150, 24);
                    btnDiscard.Text = "Discard";
                    btnDiscard.Location = new Point(i * 150 + 10 * (i + 1), 255);
                    btnDiscard.Tag = i;
                    btnDiscard.Click += new EventHandler(btnDiscardClicked);
                    pnlHand.Controls.Add(btnDiscard);
                }
            }
            if (thisPlayer.cardsOnHand.Count <= thisPlayer.currentHP)
            {
                Button btnEndTurn = new Button();
                btnEndTurn.Size = new Size(150, 24);
                btnEndTurn.Text = "End turn";
                btnEndTurn.Location = new Point(pnlHand.Width - btnEndTurn.Width, 255);
                btnEndTurn.Click += new EventHandler(btnEndTurnClicked);
                pnlHand.Controls.Add(btnEndTurn);
            }
        }

        public string getImagePath(string path)
        {
            string[] pathParts = path.Split('\\');
            for (int j = 0; j < pathParts.Count() - 1; j++)
            {
                pathParts[j] = pathParts[j].Replace(" ", "_");
                pathParts[j] += ".";
            }
            path = "";
            foreach (string pathPart in pathParts)
            {
                path += pathPart;
            }
            return path;
        }

        public void sendUseCard(Card card, Player thisPlayer, Player target)
        {
            // Send use card to game server
        }

        public void discardCard(Card card, Player thisPlayer)
        {
            // Discard card to server
        }

        public bool canBangPlayer(Player target)
        {
            if (selectedCard.effectID != 6)
            {
                return false;
            }
            if (thisPlayer.usedBang)
            {
                return false;
            }
            bool hasBangOnHand = false;
            foreach (Card card in thisPlayer.cardsOnHand)
            {
                if (card.effectID == 6)
                {
                    hasBangOnHand = true;
                    break;
                }
            }
            if (!hasBangOnHand)
            {
                return false;
            }
            int thisPlayerPos = 0;
            int targetPos = 0;
            for (int i = 0; i < players.Count; i++)
            {
                if (thisPlayer.id == players.ElementAt(i).id)
                {
                    thisPlayerPos = i;
                }
                if (target.id == players.ElementAt(i).id)
                {
                    targetPos = i;
                }
            }
            if (Math.Abs(thisPlayerPos - targetPos) + target.distance - thisPlayer.scope <= thisPlayer.range ||
                Math.Abs(thisPlayerPos + 7 - targetPos) + target.distance - thisPlayer.scope <= thisPlayer.range ||
                Math.Abs(thisPlayerPos - 7 - targetPos) + target.distance - thisPlayer.scope <= thisPlayer.range)
            {
                return true;
            }
            return false;
        }

        public bool canPanicPlayer(Player target)
        {
            if (selectedCard.effectID != 9)
            {
                return false;
            }
            if (target.cardsOnHand.Count <= 0 && target.currentEquip.Count <= 0)
            {
                return false;
            }
            bool hasPanicOnHand = false;
            foreach (Card card in thisPlayer.cardsOnHand)
            {
                if (card.effectID == 9)
                {
                    hasPanicOnHand = true;
                    break;
                }
            }
            if (!hasPanicOnHand)
            {
                return false;
            }
            int thisPlayerPos = 0;
            int targetPos = 0;
            for (int i = 0; i < players.Count; i++)
            {
                if (thisPlayer.id == players.ElementAt(i).id)
                {
                    thisPlayerPos = i;
                }
                if (target.id == players.ElementAt(i).id)
                {
                    targetPos = i;
                }
            }
            if (Math.Abs(thisPlayerPos - targetPos) + target.distance - thisPlayer.scope <= 1 ||
                Math.Abs(thisPlayerPos + 7 - targetPos) + target.distance - thisPlayer.scope <= 1 ||
                Math.Abs(thisPlayerPos - 7 - targetPos) + target.distance - thisPlayer.scope <= 1)
            {
                return true;
            }
            return false;
        }

        public bool canCatBalou(Player target)
        {
            if (selectedCard.effectID != 10)
            {
                return false;
            }
            if (target.cardsOnHand.Count <= 0 && target.currentEquip.Count <= 0)
            {
                return false;
            }
            bool hasCatBalouOnHand = false;
            foreach (Card card in thisPlayer.cardsOnHand)
            {
                if (card.effectID == 10)
                {
                    hasCatBalouOnHand = true;
                    break;
                }
            }
            if (!hasCatBalouOnHand)
            {
                return false;
            }
            return true;
        }

        void btnBangClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                sendUseCard(selectedCard, thisPlayer, players.ElementAt((int)button.Tag));
            }
        }

        void btnPanicClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                sendUseCard(selectedCard, thisPlayer, players.ElementAt((int)button.Tag));
            }
        }

        void btnCatBalouClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                sendUseCard(selectedCard, thisPlayer, players.ElementAt((int)button.Tag));
            }
        }

        void btnUsedCardClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                sendUseCard(selectedCard, thisPlayer, null);
            }
        }

        void btnDiscardClicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                discardCard(selectedCard, thisPlayer);
            }
        }

        void btnEndTurnClicked(object sender, EventArgs e)
        {
            selectedCard = new Card();
            updateHand();
            updateActions();
            pnlHand.Enabled = false;
        }

        void selectedCardChanged(object sender, EventArgs e)
        {
            RadioButton rdb = sender as RadioButton;
            if (rdb.Checked)
            {
                selectedCard = thisPlayer.cardsOnHand.ElementAt((int)rdb.Tag);
                updateActions();
            }
        }
    }
}
