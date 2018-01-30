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
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net;
using Quobject.SocketIoClientDotNet.Client;
namespace EntitySyncerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
           
        }
        private Quobject.SocketIoClientDotNet.Client.Socket socket { get; set; } 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            socket = IO.Socket("http://localhost:3000");

           

            socket.On(Quobject.SocketIoClientDotNet.Client.Socket.EVENT_CONNECT, () =>
            {
                UpdateStatus("Connected");
            });


        }


        private void UpdateStatus(string text)
        {
            t1.Dispatcher.Invoke(new Action(() => { t1.Text = "eeeeeeeeeee"; }));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            socket.Emit("ff", "Kam Parsen");
        }
    }
}
