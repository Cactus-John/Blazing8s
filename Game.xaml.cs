//using MetalPerformanceShaders;
//using NetworkExtension;
using Microsoft.Maui.Layouts;
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
                if (j == 0)
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
        ImageButton myImageButtonThrowOnFirst = new ImageButton();
        myImageButtonThrowOnFirst.Source = ImageSource.FromFile(Globals.cards[temp].Image);
        Globals.Value = Globals.cards[temp].Value;
        Globals.Color = Globals.cards[temp].Color;

        var stackLayout = new StackLayout();
    }

    private bool CheckIsLegal(string temp)
    {
        if (temp[0] + "" == "s" || temp[0] + "" == "a")
        {
            Globals.Black = true;
            return true;
        }

        else if (temp[0] + "" == "s" || temp[temp.Length - 5] - '0' == Globals.Value || temp[0] == Globals.Color[0] || temp[0] + "" == "a" || Globals.Black)
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
        var temp = selectedCard.Source.ToString().Substring(6);
        Legal = CheckIsLegal(temp);

        if (Legal)
        {
            Globals.Value = temp[temp.Length - 5] - '0';
            Globals.Color = temp + "";

            CardAnimation(selectedCard);

            for (int j = 0; j < 3; j++)
            {
                FlexLayout parent = new FlexLayout();
                if (j == 2)
                    parent = BotLayout0;
                if (j == 0)
                    parent = BotLayout1;
                if (j == 1)
                    parent = BotLayout2;

                for (int i = 0; i < Globals.BotDecks[j].Count; i++)
                {
                    string Temp = Globals.BotDecks[j][i].Image;

                    if (CheckIsLegal(Globals.BotDecks[j][i].Image))
                    {
                        //Botparent.Children.RemoveAt(0);   
                        Globals.Value = Temp[Temp.Length - 5] - '0';
                        Globals.Color = Temp + "";
                        Image MyImageButtonThrowOnFirst = myImageButtonThrowOnFirst;

                        parent.Children.RemoveAt(0);
                        ImageButton newImageButton = new();
                        newImageButton.Source = ImageSource.FromFile(Globals.BotDecks[j][i].Image);
                        newImageButton.WidthRequest = 100;
                        newImageButton.HeightRequest = 150;
                        //newImageButton.AnchorX = 338;
                        //newImageButton.AnchorY = -343;
                        newImageButton.Margin = 3;
                        parent.Add(newImageButton);
                        BotCardAnimation(newImageButton);
                        await Task.Delay(2100);

                        MyImageButtonThrowOnFirst.BackgroundColor = new Color(255, 255, 255);
                        myImageButtonThrowOnFirst.Source = ImageSource.FromFile(Globals.BotDecks[j][i].Image);
                        Globals.BotDecks[j].RemoveAt(i);
                        break;

                    }
                    await Task.Delay(2100);
                }

                //Bot_Draw();
                await Task.Delay(1100);
            }
        }
    }

    private async void CardAnimation(ImageButton selectedCard)
    {

        var centerLayout = new StackLayout();
        FlexLayout parent = PlayerLayout;

        var imagePosition = new Point(centerLayout.X + myImageButtonThrowOnFirst.AnchorX, centerLayout.Y + myImageButtonThrowOnFirst.AnchorY);


        if (selectedCard.IsPressed == true)
        {

            _ = selectedCard.RotateTo(360, 750, Easing.SinInOut);

            myImageButtonThrowOnFirst.AnchorX += -40;

            if (!selectedCard.RotateTo(360, 750, Easing.SinInOut).IsCanceled)
            {

                _ = selectedCard.TranslateTo(imagePosition.X, imagePosition.Y, 100);

                int I = -1;

                for (int i = 0; i < Globals.PlayerCards.Count; i++)
                {
                    var TEMP = selectedCard.Source.ToString().Substring(6);
                    if (Globals.PlayerCards[i].Image == TEMP)
                    {
                        I = i;
                        break;
                    }
                }

                await Task.Delay(1200);
                myImageButtonThrowOnFirst.Source = selectedCard.Source;

                parent.Children.RemoveAt(I);
                Globals.PlayerCards.RemoveAt(I);

            }
        }
    }

    private static async void BotCardAnimation(ImageButton sender)
    {
        var centerLayout = new StackLayout();

        var botCardButton = sender;

        var imagePosition = new Point(centerLayout.X + botCardButton.AnchorX, centerLayout.Y + botCardButton.AnchorY);

        await Task.Delay(1100);

        if(botCardButton.IsEnabled) { _ = botCardButton.RotateTo(365, 750, Easing.BounceIn); }
        
        if(!botCardButton.RotateTo(365, 750, Easing.BounceIn).IsCanceled) 
        { 
            _ = botCardButton.TranslateTo(imagePosition.X, imagePosition.Y, 100); 
        }

        await Task.Delay(1100);
    }

    private void OnDrawButton_Clicked(object sender, EventArgs e)
    {
        FlexLayout parent = PlayerLayout;
        StackLayout parent2 = CenterLayout;

        ImageButton newImageButton = new ImageButton();
        ImageButton ImageButton = new ImageButton();
        int index = random.Next(0, Globals.CardCount);
        newImageButton.Source = ImageSource.FromFile(Globals.cards[index].Image);
        newImageButton.WidthRequest = 100;
        newImageButton.HeightRequest = 150;
        parent2.Children.Add(newImageButton);

        _ = newImageButton.TranslateTo(-500, 0,100);
        // parent = layout;
        ImageButton.Clicked += OnImageButton_Clicked;
        parent2.Children.RemoveAt(2);
        ImageButton.Source = ImageSource.FromFile(Globals.cards[index].Image);
        ImageButton.WidthRequest = 100;
        ImageButton.HeightRequest = 150;

        parent.Children.Add(ImageButton);
        Globals.PlayerCards.Add(new Card { Name = Globals.cards[index].Name, Color = Globals.cards[index].Color, Value = Globals.cards[index].Value, Image = Globals.cards[index].Image });
    }

    private void Bot_Draw()
    {
        StackLayout parent = CenterLayout;
        FlexLayout parent2 = PlayerLayout;
        ImageButton newImageButton = new ImageButton();
        newImageButton.Source = ImageSource.FromFile("cardbot.png");
        newImageButton.WidthRequest = 100;
        newImageButton.HeightRequest = 150;

        newImageButton.Clicked += OnImageButton_Clicked;
        // newImageButton. = draw.X;
        //  parent = layout2;
        parent.Children.Add(newImageButton);
        //newImageButton.TranslateTo(-500, 0);
        int index = random.Next(0, Globals.CardCount);
        Globals.BotCards.Add(new Card { Name = Globals.cards[index].Name, Color = Globals.cards[index].Color, Value = Globals.cards[index].Value, Image = Globals.cards[index].Image });
    }
}