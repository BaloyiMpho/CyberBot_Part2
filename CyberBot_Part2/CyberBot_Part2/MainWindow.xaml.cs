using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using Test.Services;
using Test.Models;


namespace CyberBot_Part2;

public partial class MainWindow : Window
{
    private RespondingServices _respondingServices;
    private UserProfile _userProfile;


    public MainWindow()
    {
        InitializeComponent();
        _userProfile = new UserProfile();
        _respondingServices = new RespondingServices();
        AddMessage(_userProfile.GetArt(), false);

    }


    private void Button1_Click(object sender, RoutedEventArgs e)
    {
        chatPanel.Children.Clear();
    }

    private async void Button2_Click(object sender, RoutedEventArgs e)
    {

        {
            string userMessage = inputMessage.Text.Trim();

            if (string.IsNullOrWhiteSpace(userMessage))
                return;


            AddMessage(userMessage, true);


            AddMessage("Thinking...", false);

            await Task.Delay(1500);


            if (chatPanel.Children.Count > 0)
                chatPanel.Children.RemoveAt(chatPanel.Children.Count - 1);

            string botReply = _respondingServices.GetResponse(userMessage);

            AddMessage(botReply, false);

            inputMessage.Clear();

        }

    }
    public void AddMessage(string message, bool isUser)
    {
        Border bubble = new Border
        {
            Background = isUser ? System.Windows.Media.Brushes.LightBlue : System.Windows.Media.Brushes.LightGray,
            CornerRadius = new CornerRadius(12),
            Padding = new Thickness(10),
            Margin = new Thickness(0, 5, 0, 5),
            HorizontalAlignment = isUser ? HorizontalAlignment.Right : HorizontalAlignment.Left,
            MaxWidth = 250
        };
        TextBlock text = new TextBlock
        {
            Text = message,
            TextWrapping = TextWrapping.Wrap
        };
        bubble.Child = text;
        chatPanel.Children.Add(bubble);
    }
}

