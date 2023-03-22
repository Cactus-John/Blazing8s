using Microsoft.Maui.Controls;
using System;

namespace Blazing8s;

public partial class Game : ContentPage
{
    public class Card
    {
        public string Name { get; set; }
        public string Image { get; set; }
    }
    public Game()
	{
		InitializeComponent();

        var cards = new List<Card>
        {
            new Card { Name = "RedCard1", Image = "redcard1.png" },
            new Card { Name = "RedCard2", Image = "redcard2.png" },
            new Card { Name = "RedCard3", Image = "redcard2.png" },
            new Card { Name = "GreenCard1", Image = "greencard1.png" },
            new Card { Name = "GreenCard2", Image = "greencard2.png" },
            new Card { Name = "GreenCard3", Image = "greencard3.png" },
            new Card { Name = "BlueCard1", Image = "bluecard1.png" },
            new Card { Name = "BlueCard2", Image = "bluecard2.png" },
            new Card { Name = "BlueCard3", Image = "bluecard3.png" },
            new Card { Name = "Skip", Image = "stop.png" },
            new Card { Name = "Reverse", Image = "swapcard.png" },
            new Card { Name = "Draw Two", Image = "add2card.png" },
        };

        var random = new Random();
        var card = cards[random.Next(cards.Count)];

        myImageButton1.Source = ImageSource.FromFile(card.Image);
        myImageButton2.Source = ImageSource.FromFile(card.Image);
        myImageButton3.Source = ImageSource.FromFile(card.Image);
        myImageButton4.Source = ImageSource.FromFile(card.Image);
        myImageButton5.Source = ImageSource.FromFile(card.Image);
        myImageButton6.Source = ImageSource.FromFile(card.Image);
    }


    private void OnImageButtonFirst_Clicked(object sender, EventArgs e)
	{
        if (myImageButton1.IsPressed == true)
        {
            myImageButton1.TranslateTo(650, -350, 500);
            myImageButton1 = null;
        }
    }

    private void OnImageButtonSecond_Clicked(object sender, EventArgs e)
    {
        if (myImageButton2.IsPressed == true)
        {
            myImageButton2.TranslateTo(570, -350, 500);
            myImageButton2 = null;
        }
    }

    private void OnImageButtonThird_Clicked(object sender, EventArgs e)
    {
        if (myImageButton3.IsPressed == true)
        {
            myImageButton3.TranslateTo(490, -350, 500);
            myImageButton3 = null;
        }
    }

    private void OnImageButtonForth_Clicked(object sender, EventArgs e)
    {
        if (myImageButton4.IsPressed == true)
        {
            myImageButton4.TranslateTo(410, -350, 500);
            myImageButton4 = null;
        }
    }

    private void OnImageButtonFifth_Clicked(object sender, EventArgs e)
    {
        if (myImageButton5.IsPressed == true)
        {
            myImageButton5.TranslateTo(330, -350, 500);
            myImageButton5 = null;
        }
    }

    private void OnImageButtonSixth_Clicked(object sender, EventArgs e)
    {
        if (myImageButton6.IsPressed == true)
        {
            myImageButton6.TranslateTo(250, -350, 500);
            myImageButton6 = null;
        }
    } 

    /* private void OnImageButton7_Clicked(object sender, EventArgs e)
    {
        if (myImageButton7.IsPressed == true)
        {
            myImageButton7.TranslateTo(250, -350, 500);
        }
    }

    private void OnImageButton8_Clicked(object sender, EventArgs e)
    {
        if (myImageButton8.IsPressed == true)
        {
            myImageButton8.TranslateTo(250, -350, 500);
        }
    }

    private void OnImageButton9_Clicked(object sender, EventArgs e)
    {
        if (myImageButton9.IsPressed == true)
        {
            myImageButton9.TranslateTo(250, -350, 500);
        }
    }

    private void OnImageButtonChangeColor_Clicked(object sender, EventArgs e)
    {
        if (myImageButtonChangeColor.IsPressed == true)
        {
            myImageButtonChangeColor.TranslateTo(250, -350, 500);
        }
    }

    private void OnImageButtonStop_Clicked(object sender, EventArgs e)
    {
        if (myImageButtonSkip.IsPressed == true)
        {
            myImageButtonSkip.TranslateTo(250, -350, 500);
        }
    }

    private void OnImageButtonDirection_Clicked(object sender, EventArgs e)
    {
        if (myImageButtonDirection.IsPressed == true)
        {
            myImageButtonDirection.TranslateTo(250, -350, 500);
        }
    }

    private void OnImageButtonAdd2_Clicked(object sender, EventArgs e)
    {
        if (myImageButtonAdd2.IsPressed == true)
        {
            myImageButtonAdd2.TranslateTo(250, -350, 500);
        }
    }

    private void OnImageButtonAdd4_Clicked(object sender, EventArgs e)
    {
        if (myImageButtonAdd4.IsPressed == true)
        {
            myImageButtonAdd4.TranslateTo(250, -350, 500);
        }
    }           */
}