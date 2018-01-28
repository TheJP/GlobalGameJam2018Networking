using GlobalGameJam2018Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkTesting
{
    public partial class Server : Form
    {
        private string Username { get; }
        private PipesNetwork Network { get; }
        private LevelConfig LevelConfig { get; set; }

        public Server(string username)
        {
            InitializeComponent();
            try
            {
                Username = username;
                Network = new PipesNetwork(action => this.Invoke(action));
                Network.Start(username, 54046);

                Network.AlchemistConnected += u => Display($"-> {u} connected");
                Network.AlchemistDisconnected += () => Display("-> Client disconnected");
                Network.GameOver += success => Display($"-> GameOver, success={success}");
                Network.ReceivedMessage += message => Display($"-> Chat, message={message}");
                Network.ReceivedMoneyMaker += (mm, pipe) =>
                    Display($"-> Got Moneymaker {{ Name: {mm.Name}, GoldValue: {mm.GoldValue}, Type: {mm.Type} }} at Pipe {{ Id: {pipe.Id}, Direction: {pipe.Direction}, Order: {pipe.Order} }}");
            }
            catch (Exception ex)
            {
                Display($"Exception: {ex.Message}");
            }
        }

        private void Display(string text)
        {
            infoText.Text = $"{text}\r\n{infoText.Text}";
        }

        private void startLevel_Click(object sender, EventArgs e)
        {
            try
            {
                LevelConfig = LevelConfig.Builder(levelName.Text)
                    .AddPipe(PipeDirection.ToAlchemist, 0)
                    .AddPipe(PipeDirection.ToAlchemist, 2)
                    .AddPipe(PipeDirection.ToPipes, 4).Create();
                Network.StartLevel(LevelConfig);
            }
            catch (Exception ex)
            {
                Display($"Exception: {ex.Message}");
            }
        }

        private void sendIngredient_Click(object sender, EventArgs e)
        {
            try
            {
                if (LevelConfig == null)
                {
                    Display("Start a level first");
                    return;
                }
                Network.SendIngredient(
                    new Ingredient(
                        (ItemType)Enum.Parse(typeof(ItemType), type.SelectedItem.ToString()),
                        (IngredientColour)Enum.Parse(typeof(IngredientColour), colour.SelectedItem.ToString())),
                    LevelConfig.PipesDictionary.Values.Where(p => p.Direction == PipeDirection.ToAlchemist).First());
            }
            catch (Exception ex)
            {
                Display($"Exception: {ex.Message}");
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            Network.Stop();
        }

        private void sendChat_Click(object sender, EventArgs e)
        {
            Network.SendMessage(chat.Text);
        }

        private void Server_FormClosed(object sender, FormClosedEventArgs e)
        {
            Network.Stop();
        }
    }
}
