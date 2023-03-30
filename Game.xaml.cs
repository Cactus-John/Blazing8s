using System.Globalization;
using System.IO;
using Windows.Storage.Streams;
using ImageButton = Microsoft.Maui.Controls.ImageButton;
using StackLayout = Microsoft.Maui.Controls.StackLayout;


namespace Blazing8s;

public class Card
{
    public string Name { get; set; }
    public string Color { get; set; }

    public int Value { get; set; }

    public string Image { get; set; }

}
public class Globals
{

    public static List<Card> cards = new()
    {
            new Card { Name = "RedCard1", Color = "Red", Value = 1, Image = "redcard1.png" },
            new Card { Name = "RedCard2", Color = "Red", Value = 2, Image = "redcard2.png" },
            new Card { Name = "RedCard3", Color = "Red", Value = 3, Image = "redcard2.png" },
            new Card { Name = "GreenCard1", Color = "Green", Value = 1, Image = "greencard1.png" },
            new Card { Name = "GreenCard2", Color = "Green", Value = 2, Image = "greencard2.png" },
            new Card { Name = "GreenCard3", Color = "Green", Value = 3, Image = "greencard3.png" },
            new Card { Name = "BlueCard1", Color = "Blue", Value = 1, Image = "bluecard1.png" },
            new Card { Name = "BlueCard2", Color = "Blue", Value = 2, Image = "bluecard2.png" },
            new Card { Name = "BlueCard3",Color = "Blue", Value = 3, Image = "bluecard3.png" },
            new Card { Name = "Skip", Color = "black", Value = 0, Image = "stop.png" },
            new Card { Name = "Reverse", Color = "black", Value = 0, Image = "swapcard.png" },
            new Card { Name = "Draw Two", Color = "black", Value = 0, Image = "add2card.png" },
    };

    public static Int32 CardCount = cards.Count;
    public static string Color;
    public static int Value;
    public static List<Card> PlayerCards = new List<Card>();
    public static List<Card> BotCards = new List<Card>();
    public static ImageButton card1 = new();
}

public partial class Game : ContentPage
{
    public bool PlayerTurn = true;
    public Random random = new();
    public Animation animation = new();

    public Game()
    {

        InitializeComponent();

        for (int i = 0; i < 6; i++)
        {
            int index = random.Next(0, Globals.CardCount);
            Globals.BotCards.Add(new Card { Name = Globals.cards[index].Name, Color = Globals.cards[index].Color, Value = Globals.cards[index].Value, Image = Globals.cards[index].Image });
            index = random.Next(0, Globals.CardCount);
            Globals.PlayerCards.Add(new Card { Name = Globals.cards[index].Name, Color = Globals.cards[index].Color, Value = Globals.cards[index].Value, Image = Globals.cards[index].Image });
            StackLayout parent;
            ImageButton newImageButton = new ImageButton();
            newImageButton.Source = ImageSource.FromFile(Globals.cards[index].Image);
            newImageButton.WidthRequest = 100;
            newImageButton.HeightRequest = 150;
            newImageButton.Clicked += OnImageButton_Clicked;
            parent = layout;
            parent.Children.Add(newImageButton);
        }

        int temp = random.Next(Globals.cards.Count - 3);
        myImageButtonThrowOnFirst.Source = ImageSource.FromFile(Globals.cards[temp].Image);
        Globals.Value = Globals.cards[temp].Value;
        Globals.Color = Globals.cards[temp].Color;

        var stackLayout = new StackLayout();
        int turns = 0;
    }

    private bool CheckIsLegal(Card Card)
    {
        string temp = Card.Name;
        if (temp[1] +"" == "s" || Convert.ToInt32(temp[temp.Length - 4]) == Globals.Value || temp[1] == Globals.Color[0] || temp[1] + "" == "a")
            return true;
        else
            return false;
    }

    private void OnImageButton_Clicked(object sender, EventArgs e)
    {
        var selectedCard = (ImageButton)sender;
        bool Legal = false;
        var temp = selectedCard.Source.ToString().Substring(5);
        Legal = CheckIsLegal(new Card { Name = temp, Color = "Card", Value = 1, Image = "Card" });
        StackLayout layout3 = new();

        if (Legal)
        {
            Globals.Value = temp[temp.Length - 4] - '0';
            Globals.Color = temp[1] + "";
            if (selectedCard.IsPressed == true)
            {
                animation = new Animation
                {
                    { 0, 0.5, new Animation(f => selectedCard.Scale = f, 1, 1.5) },
                    { 0.5, 1, new Animation(f => selectedCard.Scale = f, 1.5, 1) }
                };

                animation.Commit(this, "ImageButtonAnimation", length: 1000, easing: Easing.SinInOut, finished: (d, b) =>
                {
                    layout3.Children.Add(selectedCard);
                    selectedCard.IsEnabled = false;

                    layout3.Children.Remove(selectedCard);
                });

                myImageButtonThrowOnFirst = selectedCard;
            }
        }
    }

    private void OnDrawButton_Clicked(object sender, EventArgs e)
    {
        StackLayout parent;
        ImageButton newImageButton = new ImageButton();
        int index = random.Next(0, Globals.CardCount);
        newImageButton.Source = ImageSource.FromFile(Globals.cards[index].Image);
        newImageButton.WidthRequest = 100;
        newImageButton.HeightRequest = 150;
        newImageButton.Clicked += OnImageButton_Clicked;
        parent = layout;
        parent.Children.Add(newImageButton);
        Globals.PlayerCards.Add(new Card { Name = Globals.cards[index].Name, Color = Globals.cards[index].Color, Value = Globals.cards[index].Value, Image = Globals.cards[index].Image });
    }

    private void Bot_Draw()
    {
        StackLayout parent;
        ImageButton newImageButton = new ImageButton();
        newImageButton.Source = ImageSource.FromFile("cardbot.png");
        newImageButton.WidthRequest = 100;
        newImageButton.HeightRequest = 150;
        newImageButton.Clicked += OnImageButton_Clicked;
        parent = layout2;
        parent.Children.Add(newImageButton);
        int index = random.Next(0, Globals.CardCount);
        Globals.BotCards.Add(new Card { Name = Globals.cards[index].Name, Color = Globals.cards[index].Color, Value = Globals.cards[index].Value, Image = Globals.cards[index].Image });
    }

}