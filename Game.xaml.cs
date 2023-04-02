//using MetalPerformanceShaders;
//using NetworkExtension;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml.Linq;
//using Windows.Storage.Streams;
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
            new Card { Name = "redCard1", Color = "red", Value = 1, Image = "redcard1.png" },
            new Card { Name = "redCard2", Color = "red", Value = 2, Image = "redcard2.png" },
            new Card { Name = "redCard3", Color = "red", Value = 3, Image = "redcard2.png" },
            new Card { Name = "greenCard1", Color = "green", Value = 1, Image = "greencard1.png" },
            new Card { Name = "greenCard2", Color = "green", Value = 2, Image = "greencard2.png" },
            new Card { Name = "greenCard3", Color = "green", Value = 3, Image = "greencard3.png" },
            new Card { Name = "blueCard1", Color = "blue", Value = 1, Image = "bluecard1.png" },
            new Card { Name = "blueCard2", Color = "blue", Value = 2, Image = "bluecard2.png" },
            new Card { Name = "blueCard3",Color = "blue", Value = 3, Image = "bluecard3.png" },
            new Card { Name = "skip", Color = "black", Value = 0, Image = "stop.png" },
            new Card { Name = "reverse", Color = "black", Value = 0, Image = "swapcard.png" },
            new Card { Name = "draw Two", Color = "black", Value = 0, Image = "add2card.png" },
    };

    public static Int32 CardCount = cards.Count;
    public static string Color;
    public static int Value;
    public static List<Card> PlayerCards = new List<Card>();
    public static List<Card> BotCards = new List<Card>();
    public static List<List<Card>> BotDecks = new() { new List<Card>(), new List<Card>(), new List<Card>() };
    public static ImageButton card1 = new();
    public static bool Black = false;

}

public partial class Game : ContentPage
{
    public bool PlayerTurn = true;
    public Random random = new();
    public Animation animation = new();
    public Game()
    {

        InitializeComponent();

        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < 6; i++)
            {
                FlexLayout parent = new FlexLayout();
                if(j == 0)
                    parent = BotLayout0;
                if (j == 1)
                    parent = BotLayout1;
                if (j == 2)
                    parent = BotLayout2;
                int index = random.Next(0, Globals.CardCount);
                Globals.BotDecks[j].Add(new Card { Name = Globals.cards[index].Name, Color = Globals.cards[index].Color, Value = Globals.cards[index].Value, Image = Globals.cards[index].Image });
                ImageButton newImageButton = new ImageButton();
                newImageButton.WidthRequest = 100;
                newImageButton.HeightRequest = 150;
                newImageButton.Clicked += OnImageButton_Clicked;
                newImageButton.Margin = 3;
                newImageButton.Source = "cardbot.png";
                parent.Children.Add(newImageButton);
            }
        }

        for (int i = 0; i < 6; i++)
        {
            int index = random.Next(0, Globals.CardCount);
            Globals.PlayerCards.Add(new Card { Name = Globals.cards[index].Name, Color = Globals.cards[index].Color, Value = Globals.cards[index].Value, Image = Globals.cards[index].Image });
            FlexLayout parent = PlayerLayout;
            ImageButton newImageButton = new ImageButton();
            newImageButton.Source = ImageSource.FromFile(Globals.cards[index].Image);
            newImageButton.WidthRequest = 100;
            newImageButton.HeightRequest = 150;
            newImageButton.Clicked += OnImageButton_Clicked;
            newImageButton.Margin = 3;
            parent.Children.Add(newImageButton);
        }

        int temp = random.Next(Globals.cards.Count - 3);
        //myImageButtonThrowOnFirst.Source = ImageSource.FromFile(Globals.cards[temp].Image);
        Globals.Value = Globals.cards[temp].Value;
        Globals.Color = Globals.cards[temp].Color;

        var stackLayout = new StackLayout();
    }

    private bool CheckIsLegal(Card Card)
    {
        string temp = Card.Name;
        if (temp[1] + "" == "s" || temp[1] + "" == "a")
        {
            Globals.Black = true;
            return true;
        }

        if (temp[1] + "" == "s" || temp[temp.Length - 5] - '0' == Globals.Value || temp[1] == Globals.Color[0] || temp[1] + "" == "a")
        {
            Globals.Black = false;
            return true;
        }
        else
            return false;
    }

    private async void OnImageButton_Clicked(object sender, EventArgs e)
    {
        var selectedCard = (ImageButton)sender;
        bool Legal;
        var temp = selectedCard.Source.ToString().Substring(5);
        Legal = CheckIsLegal(new Card { Name = temp, Color = "Card", Value = 1, Image = "Card" });

        if (Legal)
        {
            if (!Globals.Black)
            {
                Globals.Value = temp[temp.Length - 4] - '0';
                Globals.Color = temp[1] + "";
            }

            if (selectedCard.IsPressed == true)
            {
                selectedCard.WidthRequest = 100;
                selectedCard.HeightRequest = 150;
                //FlexLayout parent;
                //parent = layout3;

               // _= selectedCard.TranslateTo(-parent.WidthRequest, -parent.HeightRequest);
                //parent.Children.Add(selectedCard);
              //  layout3.WidthRequest = -parent.WidthRequest;
               // layout3.HeightRequest = -parent.HeightRequest;
                selectedCard.IsEnabled = false;
                await Task.Delay(555);
              //  if (!selectedCard.IsEnabled)
            //       parent.Children.Remove(selectedCard);

              //  myImageButtonThrowOnFirst = selectedCard;
            }

            await Task.Delay(750);
           // StackLayout Botparent = layout2;
            //foreach (var card in Globals.BotCards)// rucni for sa i lolo
            for(int i = 0; i < Globals.BotCards.Count; i++)
            {
          
                string Temp = Globals.BotCards[i].Image;
                if (Temp[1] + "" == "s" || Temp[1] + "" == "a")
                {
                    Globals.Black = true;

                  //  Botparent.Children.RemoveAt(0);
                    return;
                }

                if (Temp[0] + "" == "s" || Temp[Temp.Length - 5] - '0' == Globals.Value || Temp[0] == Globals.Color[0] || Temp[0] + "" == "a")
                {
                    Globals.Black = false;
                    Globals.Value = Temp[temp.Length - 4] - '0';
                    Globals.Color = Temp[1] + "";
                  //  Botparent.Children.RemoveAt(0);
                    return;
                }
                Bot_Draw();

                await Task.Delay(750);
            }
        }
    }

    private void OnDrawButton_Clicked(object sender, EventArgs e)
    {
        FlexLayout parent;
        ImageButton newImageButton = new ImageButton();
        int index = random.Next(0, Globals.CardCount);
        newImageButton.Source = ImageSource.FromFile(Globals.cards[index].Image);
        newImageButton.WidthRequest = 100;
        newImageButton.HeightRequest = 150;
        newImageButton.Clicked += OnImageButton_Clicked;
      /// parent = layout;
       // parent.Children.Add(newImageButton);
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
      //  parent = layout2;
      //  parent.Children.Add(newImageButton);
        int index = random.Next(0, Globals.CardCount);
        Globals.BotCards.Add(new Card { Name = Globals.cards[index].Name, Color = Globals.cards[index].Color, Value = Globals.cards[index].Value, Image = Globals.cards[index].Image });
    }
}