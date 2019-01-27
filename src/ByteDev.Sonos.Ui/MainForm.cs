using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ByteDev.Sonos.Device;
using ByteDev.Sonos.Models;
using ByteDev.Sonos.Upnp.Discovery;

namespace ByteDev.Sonos.Ui
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource _cts;
        private Task _task;

        private SonosControllerFactory _sonosControllerFactory;
        private SonosDiscoveryService _discoveryService;
        private SonosDeviceService _deviceService;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            shutUpButton.Enabled = true;
            stopButton.Enabled = false;

            toolStripStatusLabel.Text = string.Empty;

            _discoveryService = new SonosDiscoveryService();
            _discoveryService.PlayersChanged += PlayersChanged;

            _deviceService = new SonosDeviceService();

            _sonosControllerFactory = new SonosControllerFactory();
        }

        private async void getDeviceButton_Click(object sender, EventArgs e)
        {
            try
            {
                var device = await _deviceService.GetDeviceAsync(ipAddressTextBox.Text);

                PrintOutput(device);
                PrintOutput();
            }
            catch (Exception ex)
            {
                PrintOutput("Problem getting device description for: " + ipAddressTextBox.Text);
                PrintOutput(ex.Message);
                PrintOutput();
            }
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            ResetOutput();
            PrintOutput("Scaning...");
            _discoveryService.StartScan();
        }

        private async void getVolumeButton_Click(object sender, EventArgs e)
        {
            var sonosController = _sonosControllerFactory.Create(ipAddressTextBox.Text);

            var volume = await sonosController.GetVolumeAsync();

            volTextBox.Text = volume.Value.ToString();
        }

        private async void setVolButton_Click(object sender, EventArgs e)
        {
            var sonosController = _sonosControllerFactory.Create(ipAddressTextBox.Text);

            await sonosController.SetVolumeAsync(new SonosVolume(int.Parse(volTextBox.Text)));
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            _cts.Cancel();
        }

        private void shutUpButton_Click(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();
            shutUpButton.Enabled = false;
            stopButton.Enabled = true;

            _task = Task.Factory.StartNew(() => EventLoop(_cts.Token, ipAddressTextBox.Text), _cts.Token);
        }

        private void EventLoop(CancellationToken token, string ipAddress)
        {
            var counter = 0;
            var seconds = int.Parse(intervalTextBox.Text);

            while (!token.IsCancellationRequested)
            {
                if (statusStrip.InvokeRequired)
                {
                    PrintStatusDelegate d = PrintStatus;
                    Invoke(d, string.Format("Rebooting {0}...", ipAddress));
                }
                
                var result = new SonosDeviceService().RebootAsync(ipAddress).Result;        // TODO: change to await
                counter++;

                if (statusStrip.InvokeRequired)
                {
                    PrintStatusDelegate d = PrintStatus;
                    Invoke(d, string.Format("Rebooted {0} {1}x. Pausing {2} seconds.", ipAddress, counter, intervalTextBox.Text));
                }

                for(var i = 0; i < seconds; i++)
                {
                    Thread.Sleep(1000);
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }
                }
            }

            if (shutUpButton.InvokeRequired)
            {
                EnableShutUpButtonDelegate d = EnableShutUpButton;
                Invoke(d);
            }

            if (statusStrip.InvokeRequired)
            {
                PrintStatusDelegate d = PrintStatus;
                Invoke(d, "Done.");
            }

            token.ThrowIfCancellationRequested();
        }


        delegate void EnableShutUpButtonDelegate();
        delegate void PrintStatusDelegate(string nessage);
        delegate void PrintOutputDelegate(string message);
        delegate void ResetOutputDelegate();

        private void EnableShutUpButton()
        {
            shutUpButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void PrintStatus(string message)
        {
            toolStripStatusLabel.Text = message;
            statusStrip.Update();
        }
        
        private void PrintOutput(string message)
        {
            outputTextBox.Text += message + Environment.NewLine;
        }

        private void PrintOutput()
        {
            PrintOutput(string.Empty);
        }

        private void ResetOutput()
        {
            outputTextBox.Text = string.Empty;
        }

        private void PlayersChanged()
        {
            if (outputTextBox.InvokeRequired)
            {
                ResetOutputDelegate d = ResetOutput;
                Invoke(d);
            }

            foreach (var player in _discoveryService.Players)
            {
                if (outputTextBox.InvokeRequired)
                {
                    PrintOutputDelegate d = PrintOutput;
                    Invoke(d, player.FriendlyName);
                }
            }
        }

        private async void getQueueButton_Click(object sender, EventArgs e)
        {
            var controller = _sonosControllerFactory.Create(ipAddressTextBox.Text);

            var response = await controller.GetQueueAsync();

            ResetOutput();

            foreach (var item in response.Items)
            {
                PrintOutput($"{item.Id}) {item.Creator} - {item.Title} [{item.Album}]");
            }

            PrintOutput($"{response.Items.Count} items in queue.");
        }

        private async void removeQueueTrackButton_Click(object sender, EventArgs e)
        {
            var controller = _sonosControllerFactory.Create(ipAddressTextBox.Text);

            await controller.RemoveQueueTrackAsync(int.Parse(trackNumberTextBox.Text));

            PrintOutput($"Track {trackNumberTextBox.Text} removed from queue.");
        }

        private async void fadeButton_Click(object sender, EventArgs e)
        {
            var controller = _sonosControllerFactory.Create(ipAddressTextBox.Text);

            await controller.FadeAsync(new SonosVolume(int.Parse(fadeTargetVolumeTextBox.Text)));
        }

        private async void rebootButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Sure you want to reboot device '{ipAddressTextBox.Text}'?",
                "Reboot?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                var sonosDeviceService = new SonosDeviceService();

                PrintOutput($"Rebooting {ipAddressTextBox.Text}...");
                await sonosDeviceService.RebootAsync(ipAddressTextBox.Text);
            }
        }

        private void PrintOutput(SonosDevice device)
        {
            ResetOutput();
            PrintOutput("IpAddress:" + device.IpAddress);
            PrintOutput("Udn: " + device.Udn);
            PrintOutput("DeviceType: " + device.DeviceType);
            PrintOutput("FriendlyName: " + device.FriendlyName);
            PrintOutput("HardwareVersion: " + device.HardwareVersion);
            PrintOutput("SoftwareVersion: " + device.SoftwareVersion);
            PrintOutput("ModelName: " + device.ModelName);
            PrintOutput("ModelDescription: " + device.ModelDescription);
            PrintOutput("ModelNumber: " + device.ModelNumber);
            PrintOutput("RoomName: " + device.RoomName);
            PrintOutput("SerialNumber: " + device.SerialNumber);
        }
    }
}
