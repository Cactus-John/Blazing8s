using Microsoft.Maui.Controls;
using System;

namespace Blazing8s;

public partial class Game : ContentPage
{

    public Game()
	{
		InitializeComponent();
;
        string[] cards = { "redcard1.png", "redcard2.png", "redcard3.png", "greencard1.png", "greencard2.png", "bluecard1.png", "bluecard2.png" };
        /* Random rand = new Random();
        List<string> userCards = new List<string>();

        while (userCards.Count < 4)
        {
            int index = rand.Next(cards.Length);
            string card = cards[index];
            if (!userCards.Contains(card))
            {
                userCards.Add(card);
            }
        } */
    }

	private void OnImageButton1_Clicked(object sender, EventArgs e)
	{
        if (RedCard1.IsPressed == true)
        {
            RedCard1.TranslateTo(650, -350, 500);
        }
    }

    private void OnImageButton2_Clicked(object sender, EventArgs e)
    {
        if (RedCard2.IsPressed == true)
        {
            RedCard2.TranslateTo(570, -350, 500);
        }
    }

    private void OnImageButton3_Clicked(object sender, EventArgs e)
    {
        if (RedCard3.IsPressed == true)
        {
            RedCard3.TranslateTo(490, -350, 500);
        }
    }

    private void OnImageButton4_Clicked(object sender, EventArgs e)
    {
        if (GreenCard1.IsPressed == true)
        {
            GreenCard1.TranslateTo(410, -350, 500);
        }
    }

    private void OnImageButton5_Clicked(object sender, EventArgs e)
    {
        if (GreenCard2.IsPressed == true)
        {
            GreenCard2.TranslateTo(330, -350, 500);
        }
    }

    private void OnImageButton6_Clicked(object sender, EventArgs e)
    {
        if (BlueCard1.IsPressed == true)
        {
            BlueCard1.TranslateTo(250, -350, 500);
        }
    }

    private void OnImageButton7_Clicked(object sender, EventArgs e)
    {

    }

    private void OnImageButton8_Clicked(object sender, EventArgs e)
    {

    }

    private void OnImageButton9_Clicked(object sender, EventArgs e)
    {

    }

    private void OnImageButtonChangeColor_Clicked(object sender, EventArgs e)
    {

    }

    private void OnImageButtonStop_Clicked(object sender, EventArgs e)
    {

    }

    private void OnImageButtonDirection_Clicked(object sender, EventArgs e)
    {

    }

    private void OnImageButtonAdd2_Clicked(object sender, EventArgs e)
    {

    }

    private void OnImageButtonAdd4_Clicked(object sender, EventArgs e)
    {

    }
}