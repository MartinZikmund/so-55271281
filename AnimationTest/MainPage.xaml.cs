using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AnimationTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void AnimatePlayerMovement()
        {
            //This will hold hour animation
            Piece.RenderTransform = new CompositeTransform();

            //New storyboard
            Storyboard storyboard = new Storyboard();

            //New DoubleAnimation - Y
            DoubleAnimation translateYAnimation = new DoubleAnimation();
            translateYAnimation.From = 0;
            translateYAnimation.To = 100;

            translateYAnimation.EasingFunction = new ExponentialEase();
            translateYAnimation.EasingFunction.EasingMode = EasingMode.EaseOut;

            translateYAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            Storyboard.SetTarget(translateYAnimation, Piece);
            Storyboard.SetTargetProperty(translateYAnimation, "(UIElement.RenderTransform).(CompositeTransform.TranslateY)");

            storyboard.Children.Add(translateYAnimation);

            //New DoubleAnimation - X 
            DoubleAnimation translateXAnimation = new DoubleAnimation();
            translateXAnimation.From = 0;
            translateXAnimation.To = 100;
            translateXAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));

            Storyboard.SetTarget(translateXAnimation, Piece);
            Storyboard.SetTargetProperty(translateXAnimation, "(UIElement.RenderTransform).(CompositeTransform.TranslateX)");

            storyboard.Children.Add(translateXAnimation);

            storyboard.Begin();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AnimatePlayerMovement();
        }
    }
}
