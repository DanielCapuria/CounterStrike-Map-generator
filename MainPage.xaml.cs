

namespace CSMapAPP
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        string[] maps = { "Mirage", "Nuke", "Vertigo", "Ancient", "Dust II", "Anubis" };
        string[] headsOrTails = { "heads", "tails" };
        public MainPage()
        {
            InitializeComponent();
            this.BackgroundColor = Colors.WhiteSmoke;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Random r = new Random();

            int randomMapIndex = r.Next(0, maps.Length);
            string randomMap = maps[randomMapIndex];

            RandomItemLabel.Text = randomMap;


            SemanticScreenReader.Announce(RandomItemLabel.Text);
        }
        private void HeadsOrTailsClick(object sender, EventArgs e)
        {
            string[] allowedWords = { "Heads", "Tails" };
            string userInput = UserInputEntry.Text;
            Random r = new Random();
            int coinFlip = r.Next(0, headsOrTails.Length);
            string randomFlip = headsOrTails[coinFlip];
            ResponseLabel.Text = $"You entered {userInput}";

            if (string.IsNullOrWhiteSpace(userInput))
            {
                ResponseLabel.Text = "Please enter heads or tails";
                return;
            }
            else if (!allowedWords.Contains(userInput, StringComparer.OrdinalIgnoreCase))
            {
                ResponseLabel.Text = "Invalid input. Please enter 'Heads' or 'Tails'.";
                return;
            }
            if (userInput.Equals(randomFlip, StringComparison.OrdinalIgnoreCase))
            {
                ResponseLabel.Text = $"The coin landed on {randomFlip} you won the coin toss, you can choose between CT or T side.";
            }
            else
            {
                ResponseLabel.Text = $"The coin landed on {randomFlip} you loose the coin toss, the other team gets to pick between CT or T side!";
            }


        }
    }

}


