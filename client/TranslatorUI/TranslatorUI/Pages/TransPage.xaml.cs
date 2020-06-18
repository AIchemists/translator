﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TranslatorUI.Pages
{
    /// <summary>
    /// TransPage.xaml 的交互逻辑
    /// </summary>
    public partial class TransPage : UserControl
    {
        private readonly RisCaptureLib.ScreenCaputre screenCaputre = new RisCaptureLib.ScreenCaputre();
        private Size? lastSize;
        List<string> language = new List<string>();
        public TransPage()
        {
            InitializeComponent();
            language.Add("Chinese");
            language.Add("English");
            language.Add("Spanish");
            language.Add("Japanese");
            language.Add("French");
            this.languageBeforeTrans.DataContext = language;
            this.languageAfterTrans.ItemsSource = language;

            screenCaputre.ScreenCaputred += OnScreenCaputred;
            screenCaputre.ScreenCaputreCancelled += OnScreenCaputreCancelled;
        }

        private void OnScreenCaputreCancelled(object sender, System.EventArgs e)
        {
            //Show(); 这里是显示当前页面
            Focus();
        }

        private void OnScreenCaputred(object sender, RisCaptureLib.ScreenCaputredEventArgs e)
        {
            //set last size
            lastSize = new Size(e.Bmp.Width, e.Bmp.Height);


            //Show();  这里是显示当前页面

            //test
            var bmp = e.Bmp;
            var win = new Window { SizeToContent = SizeToContent.WidthAndHeight, ResizeMode = ResizeMode.NoResize };

            var canvas = new Canvas { Width = bmp.Width, Height = bmp.Height, Background = new ImageBrush(bmp) };

            win.Content = canvas;
            win.Show();
        }
        private void cutScreen_btn_Click(object sender, RoutedEventArgs e)
        {
            //Hide();  这里是隐藏当前页面
            Thread.Sleep(300);
            screenCaputre.StartCaputre(30, lastSize);
        }
    }

}
