using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;
using Microsoft.Maui.Layouts;
using System;
using System.Reflection.Metadata;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Maui.Platform;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Compatibility;
using System.Globalization;

using ImageButton = Microsoft.Maui.Controls.ImageButton;
using StackLayout = Microsoft.Maui.Controls.StackLayout;
using Microsoft.UI.Xaml.Media.Imaging;

namespace Blazing8s;

public partial class Game : ContentPage
{

    public Random random = new();
    public Animation animation = new();

    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string colorString)
            {
                if (Color.TryParse(colorString, out Color color))
                {
                    return color;
                }
            }

            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class Card
    {

        public string Name { get; set; }

        public string Color { get; set; }

        public int Value { get; set; }

        public string Image { get; set; }

    }

    public void Deck()
    {

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
            new Card { Name = "Skip", Color = "black", Image = "stop.png", Value = 0},                                      // 9
            new Card { Name = "Reverse", Color = "black", Image = "swapcard.png", Value = 0 },                              // 10
            new Card { Name = "Draw Two", Color = "black", Image = "add2card.png" , Value = 0},                             // 11
        };

        // int rand = random.Next(cards.Count - 3);

        Card card1 = new();
        Card card2 = new();
        Card card3 = new();
        Card card4 = new();
        Card card5 = new();
        Card card6 = new();
        Card card7 = new();

        myImageButtonThrowOnFirst.BindingContext = card1;
        myImageButton1.BindingContext = card2;
        myImageButton2.BindingContext = card3;
        myImageButton3.BindingContext = card4;
        myImageButton4.BindingContext = card5;
        myImageButton5.BindingContext = card6;
        myImageButton6.BindingContext = card7;

        myImageButtonThrowOnFirst.SetBinding(BackgroundColorProperty, new Binding("Color", converter: new StringToColorConverter()));
        myImageButton1.SetBinding(BackgroundColorProperty, new Binding("Color", converter: new StringToColorConverter()));
        myImageButton2.SetBinding(BackgroundColorProperty, new Binding("Color", converter: new StringToColorConverter()));
        myImageButton3.SetBinding(BackgroundColorProperty, new Binding("Color", converter: new StringToColorConverter()));
        myImageButton4.SetBinding(BackgroundColorProperty, new Binding("Color", converter: new StringToColorConverter()));
        myImageButton5.SetBinding(BackgroundColorProperty, new Binding("Color", converter: new StringToColorConverter()));
        myImageButton6.SetBinding(BackgroundColorProperty, new Binding("Color", converter: new StringToColorConverter()));

        card1 = cards[random.Next(cards.Count)];
        myImageButtonThrowOnFirst.Source = ImageSource.FromFile(card1.Image);
        myImageButtonThrowOnFirst.BindingContext = card1;

        card2 = cards[random.Next(cards.Count)];
        myImageButton1.Source = ImageSource.FromFile(card2.Image);
        myImageButton1.BindingContext = card2;

        card3 = cards[random.Next(cards.Count)];
        myImageButton2.Source = ImageSource.FromFile(card3.Image);
        myImageButton2.BindingContext = card3;

        card4 = cards[random.Next(cards.Count)];
        myImageButton3.Source = ImageSource.FromFile(card4.Image);
        myImageButton3.BindingContext = card4;

        card5 = cards[random.Next(cards.Count)];
        myImageButton4.Source = ImageSource.FromFile(card5.Image);
        myImageButton4.BindingContext = card5;

        card6 = cards[random.Next(cards.Count)];
        myImageButton5.Source = ImageSource.FromFile(card6.Image);
        myImageButton5.BindingContext = card6;

        card7 = cards[random.Next(cards.Count)];
        myImageButton6.Source = ImageSource.FromFile(card7.Image);
        myImageButton6.BindingContext = card7; ;

        var stackLayout = new StackLayout();

        foreach (var card in cards)
        {
            var imageButton = new ImageButton
            {
                Source = ImageSource.FromFile(card.Image),
                WidthRequest = 100,
                HeightRequest = 150
            };

            imageButton.Clicked += OnImageButton_Clicked;

            stackLayout.Children.Add(imageButton);
        }
    }

    private void OnImageButton_Clicked(object sender, EventArgs e)
    {
        var selectedCard = (ImageButton)sender;

        if  (selectedCard.BackgroundColor == myImageButtonThrowOnFirst.BackgroundColor 
            || selectedCard.Source is FileImageSource imageSource1 && imageSource1.File == "stop.png" 
            || selectedCard.Source is FileImageSource imageSource2 && imageSource2.File == "add2card.png" 
            || selectedCard.Source is FileImageSource imageSource3 && imageSource3.File == "swapcard.png")
        {
            //else if (selectedCard.BackgroundColor != myImageButtonThrowOnFirst.BackgroundColor)
            // // ---> karta se baca samo jednom po potezu ---> stavit ovu provjeru u funkciju ---> dodat provjeru za "crnu boju" odnosno (stop, draw two...)
            // // ---> provjera za vrijednost karte (red 5 -> green 5, red 5 != green 6) 

            if (selectedCard.IsPressed == true)
            {
                animation = new Animation
                {
                    { 0, 0.5, new Animation(f => selectedCard.Scale = f, 1, 1.5) },
                    { 0.5, 1, new Animation(f => selectedCard.Scale = f, 1.5, 1) }
                };

                animation.Commit(this, "ImageButtonAnimation", length: 1000, easing: Easing.SinInOut, finished: (d, b) =>
                {

                    selectedCard.TranslateTo(250, -370, 100);

                    selectedCard = this.myImageButtonThrowOnFirst;

                });
            }
            /* 
             else
            {

            } */
        }
    }

    private void OnDrawButton_Clicked(object sender, EventArgs e)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("W:\\Projects\\Ivan\\VS\\Blazing8s\\Game.xaml");
        XmlNode xmlNode = doc.SelectSingleNode("//StackLayout");
        XmlElement ImageButton = doc.CreateElement("ImageButton");
        xmlNode.InsertAfter(ImageButton, doc.GetElementsByTagName("StackLayout")[0]);
        doc.Save("W:\\Projects\\Ivan\\VS\\Blazing8s\\Game.xaml");
    }

}