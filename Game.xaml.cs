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
using Microsoft.UI.Xaml.Media.Imaging;

using ImageButton = Microsoft.Maui.Controls.ImageButton;
using StackLayout = Microsoft.Maui.Controls.StackLayout;
using AbsoluteLayout = Microsoft.Maui.Controls.AbsoluteLayout;
using System.Text.RegularExpressions;

namespace Blazing8s;

public partial class Game : ContentPage
{

    public Random random = new();
    public Animation animation = new();

    public Game()
    {

        InitializeComponent();

        var cards = new List<Card>
        {
            new Card { Name = "RedCard1", Color = "red", Value = 1, Image = "redcard1.png" },
            new Card { Name = "RedCard2", Color = "red", Value = 2, Image = "redcard2.png" },
            new Card { Name = "RedCard3", Color = "red", Value = 3, Image = "redcard2.png" },
            new Card { Name = "GreenCard1", Color = "green", Value = 1, Image = "greencard1.png" },
            new Card { Name = "GreenCard2", Color = "green", Value = 2, Image = "greencard2.png" },
            new Card { Name = "GreenCard3", Color = "green", Value = 3, Image = "greencard3.png" },
            new Card { Name = "BlueCard1", Color = "blue", Value = 1, Image = "bluecard1.png" },
            new Card { Name = "BlueCard2", Color = "blue", Value = 2, Image = "bluecard2.png" },
            new Card { Name = "BlueCard3",Color = "blue", Value = 3, Image = "bluecard3.png" },
            new Card { Name = "Skip", Color = "black", Value = 0, Image = "stop.png" },
            new Card { Name = "Reverse", Color = "black", Value = 0, Image = "swapcard.png" },
            new Card { Name = "Draw Two", Color = "black", Value = 0, Image = "add2card.png" },
        };

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
        myImageButton6.BindingContext = card7;

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

        if (CheckIsLegal(selectedCard) == true)
        {
            if (selectedCard.IsPressed == true)
            {
                animation = new Animation
                {
                    { 0, 0.5, new Animation(f => selectedCard.Scale = f, 1, 1.5) },
                    { 0.5, 1, new Animation(f => selectedCard.Scale = f, 1.5, 1) }
                };

                animation.Commit(this, "ImageButtonAnimation", length: 1000, easing: Easing.SinInOut, finished: (d, b) =>
                {
                    selectedCard.TranslateTo(450, -150, 100);
                });

                myImageButtonThrowOnFirst = selectedCard;
            }
        }
    }

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

    private class Card
    {

        public string Name { get; set; }

        public string Color { get; set; }

        public int Value { get; set; }

        public string Image { get; set; }

    }

    private bool CheckIsLegal(ImageButton selectedCard)
    {
        if (selectedCard.BackgroundColor == myImageButtonThrowOnFirst.BackgroundColor
           || myImageButtonThrowOnFirst.Source is FileImageSource imageSource1 && imageSource1.File == "stop.png"
           || myImageButtonThrowOnFirst.Source is FileImageSource imageSource2 && imageSource2.File == "add2card.png"
           || myImageButtonThrowOnFirst.Source is FileImageSource imageSource3 && imageSource3.File == "swapcard.png"
           || selectedCard.Source is FileImageSource imageSource4 && imageSource4.File == "stop.png"
           || selectedCard.Source is FileImageSource imageSource5 && imageSource5.File == "add2card.png"
           || selectedCard.Source is FileImageSource imageSource6 && imageSource6.File == "swapcard.png"
           || (selectedCard.Source is FileImageSource imageSource7 && imageSource7.File == "redcard1.png" &&
              myImageButtonThrowOnFirst.Source is FileImageSource imageSource8 && imageSource8.File == "greencard1.png")     //red1 i green1 oba smjera
           || (myImageButtonThrowOnFirst.Source is FileImageSource imageSource9 && imageSource9.File == "redcard1.png" &&
              selectedCard.Source is FileImageSource imageSource10 && imageSource10.File == "greencard1.png")
           || (selectedCard.Source is FileImageSource imageSource11 && imageSource11.File == "redcard2.png" &&
              myImageButtonThrowOnFirst.Source is FileImageSource imageSource12 && imageSource12.File == "greencard2.png")  // red2 i green2 oba smjera
           || (myImageButtonThrowOnFirst.Source is FileImageSource imageSource13 && imageSource13.File == "redcard2.png" &&
              selectedCard.Source is FileImageSource imageSource14 && imageSource14.File == "greencard2.png")
           || (selectedCard.Source is FileImageSource imageSource15 && imageSource15.File == "redcard3.png" &&
              myImageButtonThrowOnFirst.Source is FileImageSource imageSource16 && imageSource16.File == "greencard3.png")  // red3 i green3 oba smjera
           || (myImageButtonThrowOnFirst.Source is FileImageSource imageSource17 && imageSource17.File == "redcard3.png" &&
              selectedCard.Source is FileImageSource imageSource18 && imageSource18.File == "greencard3.png")
           || (selectedCard.Source is FileImageSource imageSource19 && imageSource19.File == "redcard1.png" &&
              myImageButtonThrowOnFirst.Source is FileImageSource imageSource20 && imageSource20.File == "bluecard1.png")  // red1 i blue1 oba smjera
           || (myImageButtonThrowOnFirst.Source is FileImageSource imageSource21 && imageSource21.File == "redcard1.png" &&
              selectedCard.Source is FileImageSource imageSource22 && imageSource22.File == "bluecard1.png")
           || (selectedCard.Source is FileImageSource imageSource23 && imageSource23.File == "redcard2.png" &&
              myImageButtonThrowOnFirst.Source is FileImageSource imageSource24 && imageSource24.File == "bluecard2.png")  // red2 i blue2 oba smjera
           || (myImageButtonThrowOnFirst.Source is FileImageSource imageSource25 && imageSource25.File == "redcard2.png" &&
              selectedCard.Source is FileImageSource imageSource26 && imageSource26.File == "bluecard2.png")
           || (selectedCard.Source is FileImageSource imageSource27 && imageSource27.File == "redcard3.png" &&
              myImageButtonThrowOnFirst.Source is FileImageSource imageSource28 && imageSource28.File == "bluecard3.png")  // red3 i blue3 oba smjera
           || (myImageButtonThrowOnFirst.Source is FileImageSource imageSource29 && imageSource29.File == "redcard3.png" &&
              selectedCard.Source is FileImageSource imageSource30 && imageSource30.File == "bluecard3.png")
           || (selectedCard.Source is FileImageSource imagesource1 && imagesource1.File == "bluecard1.png" &&
              myImageButtonThrowOnFirst.Source is FileImageSource imagesource2 && imagesource2.File == "greencard1.png")  // blue1 i green1 oba smjera
           || (myImageButtonThrowOnFirst.Source is FileImageSource imagesource3 && imagesource3.File == "bluecard1.png" &&
              selectedCard.Source is FileImageSource imagesource4 && imagesource4.File == "greencard1.png")
           || (selectedCard.Source is FileImageSource imagesource5 && imagesource5.File == "bluecard2.png" &&
              myImageButtonThrowOnFirst.Source is FileImageSource imagesource6 && imagesource6.File == "greencard2.png")  // blue2 i green2 oba smjera
           || (myImageButtonThrowOnFirst.Source is FileImageSource imagesource7 && imagesource7.File == "bluecard2.png" &&
              selectedCard.Source is FileImageSource imagesource8 && imagesource8.File == "greencard2.png")
           || (selectedCard.Source is FileImageSource imagesource9 && imagesource9.File == "bluecard3.png" &&
              myImageButtonThrowOnFirst.Source is FileImageSource imagesource10 && imagesource10.File == "greencard3.png")  // blue3 i green3 oba smjera
           || (myImageButtonThrowOnFirst.Source is FileImageSource imagesource11 && imagesource11.File == "bluecard3.png" &&
              selectedCard.Source is FileImageSource imagesource12 && imagesource12.File == "greencard3.png"))
        { return true; }

        return false;
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