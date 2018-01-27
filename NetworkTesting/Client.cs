using GlobalGameJam2018Networking;
using Newtonsoft.Json;
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
    public partial class Client : Form
    {
        private string Username { get; }
        private AlchemyNetwork Network { get; }
        private LevelConfig LevelConfig { get; set; }
        public Client(string username, string address)
        {
            InitializeComponent();

            try
            {
                Username = username;
                Network = new AlchemyNetwork(action => this.Invoke(action));
                Network.Connect(username, address, 54046);

                Network.Connected += u => Display($"-> Connected with Plumber {u}");
                Network.LevelStarted += config => {
                    LevelConfig = config;
                    Display($"-> Start Level {JsonConvert.SerializeObject(config)}");
                };
                Network.ReceivedIngredient += (i, pipe) => Display($"-> Ingredient {JsonConvert.SerializeObject(i)} in pipe {JsonConvert.SerializeObject(pipe)}");
                Network.ReceivedMessage += message => Display($"-> Chat, message={message}");
                Network.ServerStopped += () => Display("-> Server Stopped");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sendMM_Click(object sender, EventArgs e)
        {
            if(LevelConfig == null) { Display("Wait for LevelStart"); return; }
            try
            {
                Network.SendMoneyMaker(
                    new MoneyMaker(moneyName.Text, int.Parse(goldValue.Text), (ItemType)Enum.Parse(typeof(ItemType), type.Text)),
                    LevelConfig.Pipes.Where(p => p.Direction == PipeDirection.ToPipes).First());
            }
            catch (Exception ex)
            {
                Display($"Exception: {ex.Message}");
            }
        }

        private void gameOver_Click(object sender, EventArgs e)
        {
            try
            {
                Network.GameOver(success.Checked);
            }
            catch (Exception ex)
            {
                Display($"Exception: {ex.Message}");
            }
        }

        private void send_Click(object sender, EventArgs e)
        {
            try
            {
                Network.SendMessage(message.Text);
            }
            catch (Exception ex)
            {
                Display($"Exception: {ex.Message}");
            }
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                Network.Disconnect();
            }
            catch (Exception ex)
            {
                Display($"Exception: {ex.Message}");
            }
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Network.Disconnect();
        }
    }
}
