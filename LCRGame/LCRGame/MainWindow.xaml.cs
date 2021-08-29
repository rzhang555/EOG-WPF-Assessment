using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace LCRGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        Player[] players;
        int totalGames = 0;
        int totalPlayers = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SetUpGames()
        {
            totalPlayers = int.Parse(tbxNumPlayers.Text);  //input box has been set up to input number only
            totalGames = int.Parse(tbxNumGames.Text); //input box has been set up to input number only
            players = new Player[totalPlayers];
            lblMsg.Visibility = Visibility.Collapsed;
        }

        private void InitPlayers()
        {
            for (int i = 0; i < totalPlayers; i++)
            {
                players[i] = new Player();
            }
        }

        private void PlayGame()
        {
            int gameTurns = 0;
            int totalTurns = 0;
            int minGameTurns = -1;
            int maxGameTurns = 0;
            for(int game = 0; game < totalGames; game++)
            {
                InitPlayers();
                do
                {
                    for (int i = 0; i < totalPlayers; i++)
                    {
                        players[i].ThrowDices();
                        gameTurns++;
                        MoveChips(i);
                        if (IsGameEnded())
                            break;
                    }
                } while (!IsGameEnded());

                if (gameTurns < minGameTurns || minGameTurns < 0)
                    minGameTurns = gameTurns;
                if (gameTurns > maxGameTurns)
                    maxGameTurns = gameTurns;

                totalTurns += gameTurns;
                gameTurns = 0;                
            } 

            float averageTurns = (float)totalTurns / totalGames;

            lblShortest.Content = "Shortest Turns: " + minGameTurns.ToString();
            lblLongest.Content = "Longest Turns: " + maxGameTurns.ToString();
            lblAverage.Content = "Average Turns: " + averageTurns.ToString();
        }


        private void MoveChips(int playerIndex)
        {
            int left, right;

            if (playerIndex == 0)
            {
                left = 1;
                right = totalPlayers - 1;
            }
            else if(playerIndex == totalPlayers - 1)
            {
                left = 0;
                right = totalPlayers - 2;
            }
            else
            {
                left = playerIndex + 1;
                right = playerIndex - 1;
            }

            foreach(char c in players[playerIndex].ThrowResults)
            {
                if (c == 'L')
                {
                    players[left].Chips++;
                    players[playerIndex].Chips--;
                }
                else if (c == 'R')
                {
                    players[right].Chips++;
                    players[playerIndex].Chips--;
                }
                else if (c == 'C')
                {
                    players[playerIndex].Chips--;  //put to center
                }
            }
        }

        private bool IsGameEnded()
        {
            int num_player_has_chips = 0;

            for (int i=0; i<totalPlayers; i++)
            {
                if (players[i].Chips != 0)
                {
                    num_player_has_chips++;
                    if (num_player_has_chips > 1)
                        return false;
                }
            }

            return true;
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            SetUpGames();
            if (!CheckInput())
            {
                spResults.Visibility = Visibility.Collapsed;
                return;
            }
            spResults.Visibility = Visibility.Visible;
            PlayGame();
        }

        private bool CheckInput()
        {
            if (totalPlayers < 3)
            {
                lblMsg.Content = "Error: must have at least 3 or more players.";
                lblMsg.Visibility = Visibility.Visible;
                return false;
            }
            if (totalGames < 1)
            {
                lblMsg.Content = "Error: must play at least 1 or more games.";
                lblMsg.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }

    class Player
    {
        public int Chips { set; get; }
        public List<char> ThrowResults;

        public Player()
        {
            Chips = 3;
            ThrowResults = new List<char>();
        }

        public void ThrowDices()
        {
            ThrowResults.Clear();
            if (Chips == 0)
                return;
            else
            {
                Random rnd = new Random();
                int num;
                for (int i = 0; i < Chips; i++)
                {
                    num = rnd.Next(1, 7);  //random number between 1-6
                    MatchSide(num);
                }
            }
        }

        private void MatchSide(int num)
        {

            switch (num)
            {
                case 1:
                    ThrowResults.Add('L');
                    break;
                case 2:
                    ThrowResults.Add('C');
                    break;
                case 3:
                    ThrowResults.Add('R');
                    break;
                default:
                    ThrowResults.Add('.');
                    break;
            }
        }
    }
}
