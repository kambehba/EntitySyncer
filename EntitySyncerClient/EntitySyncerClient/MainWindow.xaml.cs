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
        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            

            socket = IO.Socket("http://localhost:3000");

           

            socket.On(Quobject.SocketIoClientDotNet.Client.Socket.EVENT_CONNECT, () =>
            {
              //  UpdateStatus("Connected");
            });


        }


        //private void UpdateStatus(string text)
        //{
        //    t1.Dispatcher.Invoke(new Action(() => { t1.Text = "eeeeeeeeeee"; }));
        //}

        private void CreateEntity_Click(object sender, RoutedEventArgs e)
        {
            AddEntity();
            //socket.Emit("ff", "Kam Parsen");
        }


        private void AddEntity()
        {
            var randomPoint = GenerateRandomPoint();
            var gg = new Ellipse();
            gg.Height = 100;
            gg.Width = 100;
            gg.Stroke = Brushes.Red;
            EntityCanvas.Children.Add(gg);
            Canvas.SetLeft(gg, randomPoint.X);
            Canvas.SetTop(gg, randomPoint.Y);

        }

        private Point GenerateRandomPoint()
        {
            var p = new Point();
            var canvasWidth = EntityCanvas.Width;
            var canvasHeight = EntityCanvas.Height;
            Random rnd = new Random();
            int x = rnd.Next(0, Int32.Parse(canvasWidth.ToString()));
            int y = rnd.Next(0, Int32.Parse(canvasHeight.ToString()));
            p.X = x;
            p.Y = y;

            return p;
        }



    }
}
