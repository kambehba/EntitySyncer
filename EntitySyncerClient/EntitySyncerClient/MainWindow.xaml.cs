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
using System.Windows.Threading;

namespace EntitySyncerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string clientId { get; set; }
        private Dispatcher _dispatcher { get; set; }
        private delegate void AddEntityDelegate();
        public MainWindow()
        {
            InitializeComponent();
            _dispatcher = Dispatcher.CurrentDispatcher;
            StatusLable.Content = "Disconnected";
            StatusLable.Foreground = Brushes.Red;
            clientId = "id-1";
        }
       
        private Quobject.SocketIoClientDotNet.Client.Socket socket { get; set; } 
        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            //socket = IO.Socket("http://localhost:3000");
            socket = IO.Socket("http://192.168.12.120:3000");
            socket.On("EntityAdded",(data)=> 
            {
                clientId = data.ToString();
                _dispatcher.BeginInvoke(DispatcherPriority.Normal, new AddEntityDelegate(AddEntity));
            });


            socket.On(Quobject.SocketIoClientDotNet.Client.Socket.EVENT_CONNECT, () =>
            {
                StatusLable.Dispatcher.Invoke(new Action(()=>{ StatusLable.Content = "Connected"; StatusLable.Foreground = Brushes.Green; }));
                
            });
        }

        private void CreateEntity_Click(object sender, RoutedEventArgs e)
        {
            clientId = "id-1";
            _dispatcher.BeginInvoke(DispatcherPriority.Normal, new AddEntityDelegate(AddEntity));
            socket.Emit("EntityAdded", "id-1");
        }

    
        private void AddEntity()
        {
            var randomPoint = GenerateRandomPoint();
            var entity = new Ellipse();
            entity.Height = 50;
            entity.Width = 50;


            if (clientId.Equals("id-2")) { entity.Fill = Brushes.Blue; entity.Stroke = Brushes.Blue; }
            else {entity.Fill = Brushes.Red; entity.Stroke = Brushes.Red; }

            EntityCanvas.Children.Add(entity);
            Canvas.SetLeft(entity, randomPoint.X);
            Canvas.SetTop(entity, randomPoint.Y);
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
