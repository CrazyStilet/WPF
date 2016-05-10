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
using System.Windows.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Homework2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NotifyIcon myNotifyIcon;
        DispatcherTimer timer = null;
        DateTime time = new DateTime();
        
        public MainWindow()
        {
            InitializeComponent();
            myNotifyIcon = new System.Windows.Forms.NotifyIcon();
            myNotifyIcon.Icon = new System.Drawing.Icon("Icon.ico");
            myNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(MyNotifyIcon_MouseDoubleClick);
        }

        void MyNotifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if(this.WindowState == WindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                myNotifyIcon.BalloonTipTitle = "Minimize Sucessful";
                myNotifyIcon.BalloonTipText = "Minimized the app";
                myNotifyIcon.ShowBalloonTip(400);
                myNotifyIcon.Visible = true;
            }
            else if(this.WindowState == WindowState.Normal)
            {
                myNotifyIcon.Visible = false;
                this.ShowInTaskbar = true;
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            btnRound.IsEnabled = true;
            btnStop.Content = "Стоп";
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            time = time.AddMilliseconds(1);
            lblTime.Content = time.ToString("HH:mm:ss:fff");

            CommandManager.InvalidateRequerySuggested();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            
            if(btnStop.Content != "Сброс" && time!=new DateTime(0))
            {
                timer.Stop();
                btnStop.Content = "Сброс";
            }
            else
            {
                time = new DateTime(0);
                lblTime.Content = time.ToString("HH:mm:ss.fff");
                btnStop.Content = "Стоп";
                btnRound.IsEnabled = false;
                lbResult.Items.Clear();
            }
        }

        private void btnRound_Click(object sender, RoutedEventArgs e)
        {
            string res;
            string time = "-й круг! Время: ";
            res = (lbResult.Items.Count + 1) + time + lblTime.Content;
            lbResult.Items.Add(res);
        }
    }
}
