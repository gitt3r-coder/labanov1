using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace labanov1
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

        private void BtnSaveProfile_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtName.Text) || string.IsNullOrWhiteSpace(TxtSurname.Text))
            {
                MessageBox.Show("Ой! Ты забыла ввести имя и фамилию! 😿", "Мяу-ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (DpBirthDate.SelectedDate.HasValue && DpBirthDate.SelectedDate.Value > DateTime.Now)
            {
                MessageBox.Show("Котики не умеют путешествовать в будущее! 🕰️", "Мяу-ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            MessageBox.Show("Анкета супер-успешно сохранена! Ты умница! 💖", "Ура!", MessageBoxButton.OK, MessageBoxImage.Information);
            StatusText.Text = "Сохранено в " + DateTime.Now.ToShortTimeString() + " 🎀";
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            TxtName.Clear();
            TxtSurname.Clear();
            DpBirthDate.SelectedDate = null;
            CmbEducation.SelectedIndex = -1;
            PbPassword.Clear();
            ListHobbies.UnselectAll();
            RbActivityMedium.IsChecked = true;
            ChkNotifications.IsChecked = false;
            ChkPublicStats.IsChecked = false;
        }

        private void BtnLoadAvatar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Картинки (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                ImgAvatar.Source = new BitmapImage(fileUri);
                StatusText.Text = "Красивое фото добавлено! 🌸";
            }
        }

        private void ToggleEditMode_Changed(object sender, RoutedEventArgs e)
        {
            if (ToggleEditMode.IsChecked == true)
            {
                TxtName.IsEnabled = true;
                TxtSurname.IsEnabled = true;
                StatusText.Text = "Можно писать! ✏️";
            }
            else
            {
                TxtName.IsEnabled = false;
                TxtSurname.IsEnabled = false;
                StatusText.Text = "Режим чтения 📖";
            }
        }

        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl && StatusText != null)
            {
                TabItem selectedItem = MainTabControl.SelectedItem as TabItem;
                if (selectedItem != null)
                {
                    StatusText.Text = "Смотрим: " + selectedItem.Header.ToString() + " 🐾";
                }
            }
        }

       
        private void MenuDarkTheme_Click(object sender, RoutedEventArgs e)
        {
            RootPanel.Background = new SolidColorBrush(Color.FromRgb(240, 240, 240));
            StatusText.Text = "Скучная серая тема включена 🌧️";
        }

        private void MenuLightTheme_Click(object sender, RoutedEventArgs e)
        {
            RootPanel.Background = new SolidColorBrush(Color.FromRgb(255, 240, 245)); // Возвращаем KittyBackground
            StatusText.Text = "Розовая магия вернулась! 🎀";
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            BtnSaveProfile_Click(sender, e);
        }
    }
}
