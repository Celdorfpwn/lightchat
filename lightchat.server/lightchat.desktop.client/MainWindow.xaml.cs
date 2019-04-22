﻿using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lightchat.desktop.client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        HubConnection connection;
        public MainWindow()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44392/chatserver")
                .Build();


            connection.On<string>("PingBack", message =>
            {
                Console.WriteLine(message);
            });

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await connection.StartAsync();

            await connection.InvokeAsync("Ping");
        }
    }
}
