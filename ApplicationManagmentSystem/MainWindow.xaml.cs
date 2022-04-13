using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ApplicationManagmentSystem
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ObservableCollection<Models.Technician> technicians = new ObservableCollection<Models.Technician>();
            InitializeComponent();
            dg.ItemsSource = Models.context.aGetContext().Technicians.ToList();


            dep();
        }

        private void dep()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        Models.context context = new Models.context();
                        dg.ItemsSource = context.Technicians.ToList();
                    }
                    ));
                    Thread.Sleep(5000);
                }
            }
            );

        }

        private void clAdd(object sender, RoutedEventArgs e)
        {
            var technic = new Models.Technician
            {
                Name = tbName.Text,
                Phone = tbPhone.Text
            };
            Models.context.aGetContext().Technicians.Add(technic);
            Models.context.aGetContext().SaveChanges();
            string qrtext = $"https://t.me/LastDanceBot?start={tbPhone.Text}";
            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap qrcode = encoder.Encode(qrtext);
            BitmapImage image = new BitmapImage();
            MemoryStream ms = new MemoryStream();
            ((Bitmap)qrcode).Save(ms, ImageFormat.Bmp);
            image.BeginInit();
            ms.Seek(0, SeekOrigin.Begin);
            image.StreamSource = ms;
            image.EndInit();
            img.Source = image;
        }

        private void clUpdate(object sender, RoutedEventArgs e)
        {
            Models.context context = new Models.context();
            dg.ItemsSource = context.Technicians.ToList();

        }
    }
}
