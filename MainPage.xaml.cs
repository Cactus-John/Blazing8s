namespace Blazing8s;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnButton1Clicked(object sender, EventArgs e)
	{
		Window newWindow = new Window(new Game());
		Application.Current.OpenWindow(newWindow);
	}

	private void OnButton2Clicked(object sender, EventArgs e)
	{
		Window newWindow = new Window(new Instructions());
		Application.Current.OpenWindow(newWindow);
	}
}

