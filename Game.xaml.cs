using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Layouts;
using System;
using System.Reflection.Metadata;
using Windows.UI.ViewManagement;

namespace Blazing8s;

// BoxView?, 

public partial class Game : ContentPage
{
    public class Card
    {
        public string Name { get; set; }

        public string Color { get; set; }

        public string Image { get; set; }

    }

    public Game()
    {

        InitializeComponent();

        var cards = new List<Card>
        {
            new Card { Name = "RedCard1", Color = "red", Image = "redcard1.png" },
            new Card { Name = "RedCard2", Color = "red", Image = "redcard2.png" },
            new Card { Name = "RedCard3", Color = "red", Image = "redcard2.png" },
            new Card { Name = "GreenCard1", Color = "green", Image = "greencard1.png" },
            new Card { Name = "GreenCard2", Color = "green", Image = "greencard2.png" },
            new Card { Name = "GreenCard3", Color = "green", Image = "greencard3.png" },
            new Card { Name = "BlueCard1", Color = "blue",Image = "bluecard1.png" },
            new Card { Name = "BlueCard2", Color = "blue",Image = "bluecard2.png" },
            new Card { Name = "BlueCard3",Color = "blue", Image = "bluecard3.png" },
            new Card { Name = "Skip", Image = "stop.png" },
            new Card { Name = "Reverse", Image = "swapcard.png" },
            new Card { Name = "Draw Two", Image = "add2card.png" },
        };

        var random = new Random();

        myImageButtonThrowOnFirst.Source = ImageSource.FromFile(cards[random.Next(cards.Count)].Image);

        string cardToDelete1 = ImageSource.FromFile(cards[9].Image).ToString();
        string cardToDelete2 = ImageSource.FromFile(cards[10].Image).ToString();
        string cardToDelete3 = ImageSource.FromFile(cards[11].Image).ToString();

        bool areEqual1 = (myImageButtonThrowOnFirst.Source.ToString() == cardToDelete1);
        bool areEqual2 = (myImageButtonThrowOnFirst.Source.ToString() == cardToDelete2);
        bool areEqual3 = (myImageButtonThrowOnFirst.Source.ToString() == cardToDelete3);

        if (areEqual1 == true || areEqual2 == true || areEqual3 == true)
        {
            myImageButtonThrowOnFirst.Source = ImageSource.FromFile(cards[random.Next(cards.Count)].Image);
        }

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
            myImageButton1.TranslateTo(650, -350, 50);
            myImageButton1 = null;
        }
    }

    private void OnImageButtonSecond_Clicked(object sender, EventArgs e)
    {
        if (myImageButton2.IsPressed == true)
        {
            myImageButton2.TranslateTo(570, -350, 50);
            myImageButton2 = null;
        }
    }

    private void OnImageButtonThird_Clicked(object sender, EventArgs e)
    {
        if (myImageButton3.IsPressed == true)
        {
            myImageButton3.TranslateTo(490, -350, 50);
            myImageButton3 = null;
        }
    }

    private void OnImageButtonForth_Clicked(object sender, EventArgs e)
    {
        if (myImageButton4.IsPressed == true)
        {
            myImageButton4.TranslateTo(410, -350, 50);
            myImageButton4 = null;
        }
    }

    private void OnImageButtonFifth_Clicked(object sender, EventArgs e)
    {
        if (myImageButton5.IsPressed == true)
        {
            myImageButton5.TranslateTo(330, -350, 50);
            myImageButton5 = null;
        }

        if (myImageButton5 == null)
        {

        }
    }

    private void OnImageButtonSixth_Clicked(object sender, EventArgs e)
    {
        if (myImageButton6.IsPressed == true)
        {
            myImageButton6.TranslateTo(250, -350, 50);
            myImageButton6 = null;
        }
    } 
}