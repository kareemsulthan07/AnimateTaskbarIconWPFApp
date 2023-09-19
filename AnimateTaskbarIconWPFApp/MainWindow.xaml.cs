using System;
using System.Windows;
using Forms = System.Windows.Forms;
using System.Timers;


namespace AnimateTaskbarIconWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Forms.NotifyIcon notifyIcon;
        Timer timer;
        int icoCount;


        public MainWindow()
        {
            InitializeComponent();

            timer = new Timer(150)
            {
                AutoReset = true,
            };

            timer.Elapsed += Timer_Elapsed;


            var contextMenuStrip = new Forms.ContextMenuStrip()
            {
            };

            contextMenuStrip.Items.Add("Open", null, OnNotifyIconToolStripMenuItemClicked);
            contextMenuStrip.Items.Add("Exit", null, OnNotifyIconToolStripMenuItemClicked);

            icoCount = 1;

            notifyIcon = new Forms.NotifyIcon()
            {
                Text = "Notify Me",
                Icon = Properties.Resources._01
            };

            icoCount++;

            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;

            this.Closing += MainWindow_Closing;
        }

        private void Timer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            try
            {
                this.Dispatcher.Invoke(() =>
                {
                    switch (icoCount)
                    {
                        case 1:
                            notifyIcon.Icon = Properties.Resources._01;
                            break;

                        case 2:
                            notifyIcon.Icon = Properties.Resources._02;
                            break;

                        case 3:
                            notifyIcon.Icon = Properties.Resources._03;
                            break;

                        case 4:
                            notifyIcon.Icon = Properties.Resources._04;
                            break;

                        case 5:
                            notifyIcon.Icon = Properties.Resources._05;
                            break;

                        case 6:
                            notifyIcon.Icon = Properties.Resources._06;
                            break;

                        case 7:
                            notifyIcon.Icon = Properties.Resources._07;
                            break;

                        case 8:
                            notifyIcon.Icon = Properties.Resources._08;
                            break;

                        case 9:
                            notifyIcon.Icon = Properties.Resources._09;
                            break;

                        case 10:
                            notifyIcon.Icon = Properties.Resources._10;
                            break;

                        default:
                            break;
                    }

                    icoCount++;

                    if (icoCount > 10)
                        icoCount = 1;
                });
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void OnNotifyIconToolStripMenuItemClicked(object? sender, EventArgs e)
        {
            try
            {
                if (sender is Forms.ToolStripMenuItem item)
                {
                    switch (item.Text)
                    {
                        case "Open":
                            {
                                this.Show();
                            }
                            break;

                        case "Exit":
                            {
                                if (timer != null)
                                {
                                    timer.Stop();
                                    timer.Dispose();
                                }

                                Application.Current.Shutdown();
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void NotifyIcon_MouseDoubleClick(object? sender, Forms.MouseEventArgs e)
        {
            try
            {
                this.Show();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                this.Hide();
                notifyIcon.Visible = true;
                e.Cancel = true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                timer.Start();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
