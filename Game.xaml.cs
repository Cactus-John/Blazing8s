using Microsoft.Maui.Controls;

namespace Blazing8s;

public partial class Game : ContentPage
{
    Random shuffle = new Random();
    string[] deck = new string[14];

	public Game()
	{
		InitializeComponent();
	}

	private void OnImageButton1_Clicked(object sender, EventArgs e)
	{
        RedCard1.TranslateTo(10, 50, 35);
    }

    private void OnImageButton2_Clicked(object sender, EventArgs e)
    {
        RedCard2.TranslateTo(10, 50, 35);
    }

    private void OnImageButton3_Clicked(object sender, EventArgs e)
    {
        RedCard3.TranslateTo(10, 50, 35);
    }

    private void OnImageButton4_Clicked(object sender, EventArgs e)
    {

    }

    private void OnImageButton5_Clicked(object sender, EventArgs e)
    {

    }

    private void OnImageButton6_Clicked(object sender, EventArgs e)
    {

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