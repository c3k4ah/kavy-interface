﻿using System;
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
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace kavy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<TextBlock> textBlocks = new List<TextBlock>();
        public MainWindow()
        {
            InitializeComponent();
            AddTextBlocks();
            textList.ItemsSource = textBlocks;
        }
        private void AddTextBlocks()
        {
            for (int i = 0; i < 5; i++)
            {
                textBlocks.Add(new TextBlock { Text = $"TextBlock {i + 1}" });
            }
        }
    }
}
