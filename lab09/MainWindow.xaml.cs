using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;

namespace lab09
{
    public partial class MainWindow : Window
    {
        private List<Ball> balls = new List<Ball>();
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            // Tworzenie kilku piłek
            balls.Add(Ball.CreateBall(50, 50, 20, 3, 2));
            balls.Add(Ball.CreateBall(150, 100, 30, -2, 3));
            balls.Add(Ball.CreateBall(250, 150, 25, 4, -3));

            foreach (var ball in balls)
            {
                Canva.Children.Add(ball.Ref);
            }

            // Timer zamiast Thread
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(16); // ~60 FPS
            timer.Tick += Update;
            timer.Start();

            PauseBtn.Content = "Pause";
        }

        private void Update(object? sender, EventArgs e)
        {
            double width = Canva.ActualWidth;
            double height = Canva.ActualHeight;

            foreach (var ball in balls)
            {
                ball.Move();
                ball.Bounce(width, height);
            }
        }

        private void PauseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                PauseBtn.Content = "Resume";
            }
            else
            {
                timer.Start();
                PauseBtn.Content = "Pause";
            }
        }
    }
}
