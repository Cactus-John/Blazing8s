using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Layouts;
using System;
using System.Reflection.Metadata;
using Windows.UI.ViewManagement;
using System.Xml.Linq;
using Windows.Networking.Vpn;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui;

namespace Blazing8s;

// BoxView?, 

public partial class Game : ContentPage
{

    public Random random = new();
    public Animation animation = new();


    public class Card
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public int Value { get; set; }

        public string Image { get; set; }

    }

    public Game()
    {

        InitializeComponent();

        var cards = new List<Card>
        {
            new Card { Name = "RedCard1", Color = "red", Value = 1, Image = "redcard1.png" },              // 0
            new Card { Name = "RedCard2", Color = "red", Value = 2, Image = "redcard2.png" },              // 1
            new Card { Name = "RedCard3", Color = "red", Value = 3, Image = "redcard2.png" },              // 2
            new Card { Name = "GreenCard1", Color = "green", Value = 1, Image = "greencard1.png" },        // 3
            new Card { Name = "GreenCard2", Color = "green", Value = 2, Image = "greencard2.png" },        // 4
            new Card { Name = "GreenCard3", Color = "green", Value = 3, Image = "greencard3.png" },        // 5
            new Card { Name = "BlueCard1", Color = "blue", Value = 1, Image = "bluecard1.png" },           // 6
            new Card { Name = "BlueCard2", Color = "blue", Value = 2, Image = "bluecard2.png" },           // 7
            new Card { Name = "BlueCard3",Color = "blue", Value = 3, Image = "bluecard3.png" },            // 8
            new Card { Name = "Skip", Image = "stop.png", Value = 0},                                      // 9
            new Card { Name = "Reverse", Image = "swapcard.png", Value = 0 },                              // 10
            new Card { Name = "Draw Two", Image = "add2card.png" , Value = 0},                             // 11
        };

        int rand = random.Next(cards.Count - 3);

        myImageButtonThrowOnFirst.Source = ImageSource.FromFile(cards[rand].Image);

        myImageButton1.Source = ImageSource.FromFile(cards[random.Next(cards.Count)].Image);
        myImageButton2.Source = ImageSource.FromFile(cards[random.Next(cards.Count)].Image);
        myImageButton3.Source = ImageSource.FromFile(cards[random.Next(cards.Count)].Image);
        myImageButton4.Source = ImageSource.FromFile(cards[random.Next(cards.Count)].Image);
        myImageButton5.Source = ImageSource.FromFile(cards[random.Next(cards.Count)].Image);
        myImageButton6.Source = ImageSource.FromFile(cards[random.Next(cards.Count)].Image);
    }

    private void OnImageButtonFirst_Clicked(object sender, EventArgs e)
	{
        if (myImageButton1.IsPressed == true)
        {
            animation = new Animation
            {
                { 0, 0.5, new Animation(f => myImageButton1.Scale = f, 1, 1.5) },
                { 0.5, 1, new Animation(f => myImageButton1.Scale = f, 1.5, 1) }
            };

            animation.Commit(this, "ImageButtonAnimation", length: 1000, easing: Easing.SinInOut, finished: (d, b) =>
            {
                myImageButton1.TranslateTo(300, -200, 100);
            });
        }
    }

    private void OnImageButtonSecond_Clicked(object sender, EventArgs e)
    {
        if (myImageButton2.IsPressed == true)
        {
            animation = new Animation
            {
                { 0, 0.5, new Animation(f => myImageButton2.Scale = f, 1, 1.5) },
                { 0.5, 1, new Animation(f => myImageButton2.Scale = f, 1.5, 1) }
            };

            animation.Commit(this, "ImageButtonAnimation", length: 600, easing: Easing.SinIn, finished: (d, b) =>
            {
                myImageButton2.TranslateTo(300, -200, 100);
            });
        }
    }

    private void OnImageButtonThird_Clicked(object sender, EventArgs e)
    {
        if (myImageButton3.IsPressed == true)
        {
            animation = new Animation
            {
                { 0, 0.5, new Animation(f => myImageButton3.Scale = f, 1, 1.5) },
                { 0.5, 1, new Animation(f => myImageButton3.Scale = f, 1.5, 1) }
            };

            animation.Commit(this, "ImageButtonAnimation", length: 900, easing: Easing.BounceIn, finished: (d, b) =>
            {
                myImageButton3.TranslateTo(300, -200, 100);
            });
        }
    }

    private void OnImageButtonForth_Clicked(object sender, EventArgs e)
    {
        if (myImageButton4.IsPressed == true)
        {
            animation = new Animation
            {
                { 0, 0.5, new Animation(f => myImageButton4.Scale = f, 1, 1.5) },
                { 0.5, 1, new Animation(f => myImageButton4.Scale = f, 1.5, 1) }
            };

            animation.Commit(this, "ImageButtonAnimation", length: 800, easing: Easing.BounceOut, finished: (d, b) =>
            {
                myImageButton4.TranslateTo(300, -200, 100);
            });
        }
    }

    private void OnImageButtonFifth_Clicked(object sender, EventArgs e)
    {
        if (myImageButton5.IsPressed == true)
        {
            animation = new Animation
            {
                { 0, 0.5, new Animation(f => myImageButton5.Scale = f, 1, 1.5) },
                { 0.5, 1, new Animation(f => myImageButton5.Scale = f, 1.5, 1) }
            };

            animation.Commit(this, "ImageButtonAnimation", length: 900, easing: Easing.CubicIn, finished: (d, b) =>
            {
                myImageButton5.TranslateTo(300, -200, 100);
            });
        }
    }

    private void OnImageButtonSixth_Clicked(object sender, EventArgs e)
    {
        if (myImageButton6.IsPressed == true)
        {
            animation = new Animation
            {
                { 0, 0.5, new Animation(f => myImageButton6.Scale = f, 1, 1.5) },
                { 0.5, 1, new Animation(f => myImageButton6.Scale = f, 1.5, 1) }
            };

            animation.Commit(this, "ImageButtonAnimation", length: 1000, easing: Easing.CubicInOut, finished: (d, b) =>
            {
                myImageButton6.TranslateTo(300, -200, 100);
            });
        }
    } 

    private void OnDrawButton_Clicked(object sender, EventArgs e)
    {
        XDocument doc = XDocument.Load("W:\\Projects\\Ivan\\VS\\Blazing8s\\Game.xaml");
        XElement root = new XElement("Snippet");
        root.Add(new XAttribute("name", "name goes here"));
        root.Add(new XElement("SnippetCode", "SnippetCode"));
        doc.Element("Snippets").Add(root);
        doc.Save("W:\\Projects\\Ivan\\VS\\Blazing8s\\Game.xaml");
    }
}