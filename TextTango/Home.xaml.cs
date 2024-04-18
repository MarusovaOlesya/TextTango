using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace TextTango
{
    /// <summary>
    /// Логика взаимодействия для Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        private SqlConnection bd;
        public string Id;
        public Home(SqlConnection bd, string Id)
        {
            InitializeComponent();
            this.bd = bd;
            this.Id = Id;
            WriteName();
        }

        private void WriteName()
        {
            SqlCommand sqlCommand = new SqlCommand($"select Name from Users where Id = {Id}", bd);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            reader.Read();
            Name.Text = reader[0].ToString();
            reader.Close();
        }

        private Grid Chats()
        {
            Grid grid = new Grid();

            Button button = new Button();
            button.Height = 50;
            button.Width = 170;
            button.HorizontalAlignment = HorizontalAlignment.Left;
            button.Background = Brushes.White;
            button.Foreground = Brushes.White;

            Style style = new Style(typeof(Border));
            style.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(10)));

            button.Resources.Add(typeof(Border), style);

            Grid innerGrid = new Grid();
            innerGrid.HorizontalAlignment = HorizontalAlignment.Center;
            innerGrid.Width = 167;

            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;

            Border border = new Border();
            border.Height = 40;
            border.Width = 40;
            border.CornerRadius = new CornerRadius(30);
            border.BorderThickness = new Thickness(1);
            border.BorderBrush = Brushes.Black;

            Image image = new Image();
            image.Source = new BitmapImage(new Uri("c:\\users\\admin\\desktop\\texttango\\texttango\\images\\icons\\2.png"));

            border.Child = image;
            stackPanel.Children.Add(border);

            TextBlock textBlock = new TextBlock();
            textBlock.Text = "pinkrabbit";
            textBlock.FontSize = 20;
            textBlock.Foreground = Brushes.Black;
            textBlock.HorizontalAlignment = HorizontalAlignment.Left;
            textBlock.VerticalAlignment = VerticalAlignment.Center;
            textBlock.Margin = new Thickness(45, 0, 0, 0);

            innerGrid.Children.Add(stackPanel);
            innerGrid.Children.Add(textBlock);

            button.Content = innerGrid;

            grid.Children.Add(button);

            Content = grid;
            return grid;
        }
    }
}
