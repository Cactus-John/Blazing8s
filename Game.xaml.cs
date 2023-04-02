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
            new Card { Name = "redCard3", Color = "red", Value = 3, Image = "redcard3.png" },
            new Card { Name = "redCard4", Color = "red", Value = 4, Image = "redcard4.png" },
            new Card { Name = "redCard5", Color = "red", Value = 5, Image = "redcard5.png" },
            new Card { Name = "redCard6", Color = "red", Value = 6, Image = "redcard6.png" },
            new Card { Name = "redCard7", Color = "red", Value = 7, Image = "redcard7.png" },
            new Card { Name = "redCard8", Color = "red", Value = 8, Image = "redcard8.png" },


            new Card { Name = "blueCard1", Color = "blue", Value = 1, Image = "bluecard1.png" },
            new Card { Name = "blueCard2", Color = "blue", Value = 2, Image = "bluecard2.png" },
            new Card { Name = "blueCard3", Color = "blue", Value = 3, Image = "bluecard3.png" },
            new Card { Name = "blueCard4", Color = "blue", Value = 4, Image = "bluecard4.png" },
            new Card { Name = "blueCard5", Color = "blue", Value = 5, Image = "bluecard5.png" },
            new Card { Name = "blueCard6", Color = "blue", Value = 6, Image = "bluecard6.png" },
            new Card { Name = "blueCard7", Color = "blue", Value = 7, Image = "bluecard7.png" },
            new Card { Name = "blueCard8", Color = "blue", Value = 8, Image = "bluecard8.png" },


            new Card { Name = "greenCard1", Color = "green", Value = 1, Image = "greencard1.png" },
            new Card { Name = "greenCard2", Color = "green", Value = 2, Image = "greencard2.png" },
            new Card { Name = "greenCard3", Color = "green", Value = 3, Image = "greencard3.png" },
            new Card { Name = "greenCard4", Color = "green", Value = 4, Image = "greencard4.png" },
            new Card { Name = "greenCard5", Color = "green", Value = 5, Image = "greencard5.png" },
            new Card { Name = "greenCard6", Color = "green", Value = 6, Image = "greencard6.png" },
            new Card { Name = "greenCard7", Color = "green", Value = 7, Image = "greencard7.png" },
            new Card { Name = "greenCard8", Color = "green", Value = 8, Image = "greencard8.png" },

            new Card { Name = "yellowCard1", Color = "yellow", Value = 1, Image = "yellowcard1.png" },
            new Card { Name = "yellowCard2", Color = "yellow", Value = 2, Image = "yellowcard2.png" },
            new Card { Name = "yellowCard3", Color = "yellow", Value = 3, Image = "yellowcard3.png" },
            new Card { Name = "yellowCard4", Color = "yellow", Value = 4, Image = "yellowcard4.png" },
            new Card { Name = "yellowCard5", Color = "yellow", Value = 5, Image = "yellowcard5.png" },
            new Card { Name = "yellowCard6", Color = "yellow", Value = 6, Image = "yellowcard6.png" },
            new Card { Name = "yellowCard7", Color = "yellow", Value = 7, Image = "yellowcard7.png" },
            new Card { Name = "yellowCard8", Color = "yellow", Value = 8, Image = "yellowcard8.png" },



    };

    public static Int32 CardCount = cards.Count;
    public static string Color;
    public static int Value;
    public static List<Card> PlayerCards = new List<Card>();
    public static List<Card> BotCards = new List<Card>();
    public static List<List<Card>> BotDecks = new() { new List<Card>(), new List<Card>(), new List<Card>() };
    public static ImageButton card1 = new();
    public static bool Black = false;
    public static bool PlayerTrun = true;
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
                    parent = BotLayout1;
                if (j == 1)
                    parent = BotLayout0;
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
        ImageButton MyImageButtonThrowOnFirst = myImageButtonThrowOnFirst;
        ImageButton Draw = draw;
        draw.Source = ImageSource.FromFile("cardbot.png");
        MyImageButtonThrowOnFirst.Source = ImageSource.FromFile(Globals.cards[temp].Image);
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
        if (!Globals.PlayerTrun)
            return;
        var selectedCard = (ImageButton)sender;
        bool Legal;
        var temp = selectedCard.Source.ToString().Substring(6);
        Legal = CheckIsLegal(temp);

        if (Legal)
        {
            Globals.PlayerTrun = false;
            Globals.Value = temp[temp.Length - 5] - '0';
            Globals.Color = temp + "";

            CardAnimation(selectedCard);

            for (int j = 0; j < 3; j++)
            {
                FlexLayout parent = new FlexLayout();
                if (j == 2)
                    parent = BotLayout1;
                if (j == 1)
                    parent = BotLayout0;
                if (j == 0)
                    parent = BotLayout2;

                for (int i = 0; i < Globals.BotDecks[j].Count; i++)
                {
                    string Temp = Globals.BotDecks[j][i].Image;

                    if (CheckIsLegal(Globals.BotDecks[j][i].Image))
                    {
                        //Botparent.Children.RemoveAt(0);   
                        Globals.Value = Temp[Temp.Length - 5] - '0';
                        Globals.Color = Temp + "";
                        ImageButton MyImageButtonThrowOnFirst = myImageButtonThrowOnFirst;

                        parent.Children.RemoveAt(0);
                        ImageButton newImageButton = new();
                        newImageButton.Source = ImageSource.FromFile(Globals.BotDecks[j][i].Image);
                        newImageButton.WidthRequest = 100;
                        newImageButton.HeightRequest = 150;
                        newImageButton.Margin = 3;
                        parent.Add(newImageButton);
                        await Task.Delay(750);
                        if (j == 2)
                        {
                            Bot3CardAnimation(newImageButton);
                            await Task.Delay(2500);
                            parent.Children.Remove(newImageButton);
                        }
                        //await Task.Delay(530);
                        if (j == 0)
                        {
                            Bot2CardAnimation(newImageButton);
                            await Task.Delay(2500);
                            parent.Children.Remove(newImageButton);
                        }
                       // await Task.Delay(530);
                        if (j == 1)
                        {
                            Bot1CardAnimation(newImageButton);
                            await Task.Delay(2500);
                            parent.Children.Remove(newImageButton);
                        }

                        myImageButtonThrowOnFirst.Source = ImageSource.FromFile(Globals.BotDecks[j][i].Image);

                        await Task.Delay(1500);


                        //MyImageButtonThrowOnFirst.BackgroundColor = new Color(255, 255, 255);
                        Globals.BotDecks[j].RemoveAt(i);
                        break;

                    }
                    if (i == Globals.BotDecks[j].Count - 1)
                    {
                        if (j == 0)
                            Bot_Draw2();
                        if (j == 1)
                            Bot_Draw0();
                        if (j == 2)
                            Bot_Draw1();
                        break;
                    }


                    await Task.Delay(800);
                }


                //Bot_Draw();
                await Task.Delay(800);
                Globals.PlayerTrun = true;
            }
        }
    }

    private async void CardAnimation(ImageButton selectedCard)
    {

        var centerLayout = new StackLayout();
        FlexLayout parent = PlayerLayout;
        List<int> x = new List<int>(new int[] { -0, -20, -40, -60, -80, -100 });
        var imagePosition = new Point(centerLayout.X + myImageButtonThrowOnFirst.AnchorX, centerLayout.Y + myImageButtonThrowOnFirst.AnchorY);
        var P = 1;
        for(int i = 0; i < Globals.PlayerCards.Count; i++)
        {
            var temp = selectedCard.Source.ToString().Substring(6);
            if (Globals.PlayerCards[i].Image == temp)
                P = i;
        }
 
        if (selectedCard.IsPressed == true)
        {

            _ = selectedCard.RotateTo(360, 750, Easing.SinInOut);

            myImageButtonThrowOnFirst.AnchorX += -40;

            if (!selectedCard.RotateTo(360, 750, Easing.SinInOut).IsCanceled)
            {

                _ = selectedCard.TranslateTo(300 -P*53,- 250, 100);

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

                await Task.Delay(800);
                myImageButtonThrowOnFirst.Source = selectedCard.Source;

                parent.Children.RemoveAt(I);
                Globals.PlayerCards.RemoveAt(I);
            }
        }
    }

    private static async void Bot3CardAnimation(ImageButton sender)
    {
        List<int> x = new List<int>(new int[] { -323, -285, -230, -180, -135, -60 });
        var centerLayout = new StackLayout();
        var botCardButton = sender;
        var myImageButtonThrowOnFirst = sender;

        await Task.Delay(800);

        _ = botCardButton.RotateTo(450, 750, Easing.SinInOut);
        
        if(!botCardButton.RotateTo(450, 750, Easing.SinInOut).IsCanceled) 
        { 
            _ = botCardButton.TranslateTo(-57 * Globals.BotDecks[2].Count, 770 ,200); 
        }

        await Task.Delay(800);
    }

    private static async void Bot2CardAnimation(ImageButton sender)
    {
        List<int> x = new List<int>(new int[] { -323, -285, -230, -180, -155, - 65});
        var centerLayout = new StackLayout();
        var botCardButton = sender;
        var myImageButtonThrowOnFirst = sender;

        await Task.Delay(800);

        _ = botCardButton.RotateTo(450, 750, Easing.SinInOut);

        if (!botCardButton.RotateTo(450, 750, Easing.BounceIn).IsCanceled)
        {
            _ = botCardButton.TranslateTo(-57 * Globals.BotDecks[2].Count, -485, 200);// x[6-
        }

        await Task.Delay(800);
    }

    private static async void Bot1CardAnimation(ImageButton sender)
    {
        List<int> x = new List<int>(new int[] { -323, -275, -230, -180, -155, -65 });
        var centerLayout = new StackLayout();
        var botCardButton = sender;
        var myImageButtonThrowOnFirst = sender;

        await Task.Delay(800);

        _ = botCardButton.RotateTo(360, 750, Easing.SinInOut);

        if (!botCardButton.RotateTo(360, 750, Easing.SinInOut).IsCanceled)
        {
            _ = botCardButton.TranslateTo(-47 * Globals.BotDecks[0].Count, 300, 200);
        }

        await Task.Delay(800);
    }

    private void OnDrawButton_Clicked(object sender, EventArgs e)
    {
        if (!Globals.PlayerTrun)
            return;
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

    private void Bot_Draw0()
    {
        FlexLayout parent = BotLayout0;
        FlexLayout parent2 = PlayerLayout;
        ImageButton newImageButton = new ImageButton();
        newImageButton.Source = ImageSource.FromFile("cardbot.png");
        newImageButton.WidthRequest = 100;
        newImageButton.HeightRequest = 150;
        parent.Children.Add(newImageButton);
        int index = random.Next(0, Globals.CardCount);
        Globals.BotDecks[0].Add(new Card { Name = Globals.cards[index].Name, Color = Globals.cards[index].Color, Value = Globals.cards[index].Value, Image = Globals.cards[index].Image });
    }

    private void Bot_Draw1()
    {
        FlexLayout parent = BotLayout1;
        FlexLayout parent2 = PlayerLayout;
        ImageButton newImageButton = new ImageButton();
        newImageButton.Source = ImageSource.FromFile("cardbot.png");
        newImageButton.WidthRequest = 100;
        newImageButton.HeightRequest = 150;
        parent.Children.Add(newImageButton);
        int index = random.Next(0, Globals.CardCount);
        Globals.BotDecks[1].Add(new Card { Name = Globals.cards[index].Name, Color = Globals.cards[index].Color, Value = Globals.cards[index].Value, Image = Globals.cards[index].Image });
    }

    private void Bot_Draw2()
    {
        FlexLayout parent = BotLayout2;
        FlexLayout parent2 = PlayerLayout;
        ImageButton newImageButton = new ImageButton();
        newImageButton.Source = ImageSource.FromFile("cardbot.png");
        newImageButton.WidthRequest = 100;
        newImageButton.HeightRequest = 150;
        parent.Children.Add(newImageButton);
        int index = random.Next(0, Globals.CardCount);
        Globals.BotDecks[2].Add(new Card { Name = Globals.cards[index].Name, Color = Globals.cards[index].Color, Value = Globals.cards[index].Value, Image = Globals.cards[index].Image });
    }
}

/* 
   1. Funkcionalnost karte add2(draw2), stop i swap(promjeni smjer) I PROVJERA ZA KRAJ IGRE ----> neee
   2. Opcionalno: dodat karte da bude veci gas ----------> mozdaaaaaa
   3. Animacije su "ODLICNE" -> ne treba fiksat ==== slazem se
*/