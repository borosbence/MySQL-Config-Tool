using System;
using System.Configuration;
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
using MySql.Data.MySqlClient;
using System.IO;

namespace DenTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool testConnection = false;
        private bool exeAdded = true;
        private string exeName = "DigiDent.exe";
        private string exePath;

        public MainWindow()
        {
            InitializeComponent();
            checkDigiDent();
        }

        // Check if DigiDent.exe exist
        private void checkDigiDent()
        {
            /* Same resource icon for multiple use
             *  https://docs.microsoft.com/en-us/dotnet/framework/xaml-services/x-shared-attribute
             */

            if (File.Exists(Directory.GetCurrentDirectory() + "\\" + exeName))
            {
                ImageAlertExe.Content = Application.Current.Resources["TestCoveredPassing_16x"];
                ImageAlertExe.Visibility = Visibility.Visible;
                TextBlockLoaded.Text = exeName + " " + Application.Current.Resources["Loaded"].ToString();
            }
            else
            {
                ImageAlertExe.Content = Application.Current.Resources["TestCoveredFailing_16x"];
                ImageAlertExe.Visibility = Visibility.Visible;
                TextBlockLoaded.Text = exeName + " " + Application.Current.Resources["FileNotFound"].ToString();
            }
        }
        /* Enable the Button, 
         *  when the exe and the test is correct */
        private void checkSaveButton()
        {
            if (testConnection && exeAdded == true)
            {
                ButtonSave.IsEnabled = true;
            }
        }

        private void encryptConfig(string exeName, string exePath)
        {
            try
            {
                /* https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/connection-strings-and-configuration-files
                 * Open the resource file
                 * and get the connectionStrings section. */

                Configuration config = 
                    ConfigurationManager.OpenExeConfiguration(exePath);

                ConnectionStringsSection section =
                    config.GetSection("connectionStrings")
                    as ConnectionStringsSection;

                config.ConnectionStrings.ConnectionStrings["mysqlConnectionString"].ConnectionString =
                      "server=" + TextBoxServer.Text + ";"
                    + "userid=" + TextBoxUsername.Text + ";"
                    + "password=" + PasswordBox.Password + ";"
                    + "persistsecurityinfo=True;"
                    + "database=" + TextBoxDatabase.Text;

                /*
                if (section.SectionInformation.IsProtected)
                {
                    // Decoding
                    section.SectionInformation.UnprotectSection();
                }
                */

                if (!section.SectionInformation.IsProtected)
                {
                    // Encoding
                    section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                }

                // A jelenlegi beállítás elmentése
                config.Save();
                ImageAlert.Content = Application.Current.Resources["TestCoveredPassing_16x"];
                ImageAlert.Visibility = Visibility.Visible;
                TextBlockResult.Text = Application.Current.Resources["SettingsSaved"].ToString();
            }
            catch (Exception err)
            {
                TextBlockResult.Text = err.Message;
                ImageAlert.Content = Application.Current.Resources["TestCoveredFailing_16x"];
                ImageAlert.Visibility = Visibility.Visible;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            encryptConfig(exeName, exePath);
        }

        // Check MySQL connection
        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connection = "server=" + TextBoxServer.Text + ";"
                                  + "userid=" + TextBoxUsername.Text + ";"
                                  + "password=" + PasswordBox.Password + ";"
                                  + "persistsecurityinfo=True;"
                                  + "database=" + TextBoxDatabase.Text;
                var conn = new MySqlConnection(connection);
                conn.Open();
                /* ContentControl
                 * https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/templates/data-templates/selector   */
                ImageAlert.Content = Application.Current.Resources["TestCoveredPassing_16x"];
                ImageAlert.Visibility = Visibility.Visible;
                TextBlockResult.Text = Application.Current.Resources["TestSuccess"].ToString();
                testConnection = true;
                checkSaveButton();
            }
            catch (Exception err)
            {
                ImageAlert.Content = Application.Current.Resources["TestCoveredFailing_16x"];
                ImageAlert.Visibility = Visibility.Visible;
                TextBlockResult.Text = err.Message;
            }
            
        }

        private void MenuItem_Open_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog();
            ofd.Filter = Application.Current.Resources["OpenFilter"].ToString();
            ofd.Title = Application.Current.Resources["OpenTitle"].ToString();
            ofd.ShowDialog();
            try
            {
                // Store the opened exe name and path
                exeName = ofd.SafeFileName;
                exePath = ofd.FileName;

                //Ellenőrzi az exe kiterjesztést
                if (exeName.Contains(".exe"))
                {
                    ImageAlertExe.Content = Application.Current.Resources["TestCoveredPassing_16x"];
                    ImageAlertExe.Visibility = Visibility.Visible;
                    TextBlockLoaded.Text = exeName + " " + Application.Current.Resources["Loaded"].ToString();
                    exeAdded = true;
                }
                else
                {
                    ImageAlertExe.Content = Application.Current.Resources["TestCoveredFailing_16x"];
                    ImageAlertExe.Visibility = Visibility.Visible;
                    TextBlockLoaded.Text = Application.Current.Resources["ExeInvalid"].ToString();
                    exeAdded = false;
                }
                checkSaveButton();
            }
            catch (Exception err)
            {
                ImageAlertExe.Content = Application.Current.Resources["TestCoveredFailing_16x"];
                ImageAlertExe.Visibility = Visibility.Visible;
                TextBlockResult.Text = err.Message;
            }
        }

        private void English_Click(object sender, RoutedEventArgs e)
        {
            LanguageGUI.changeLanguage("en-EN");
        }

        private void Hungarian_Click(object sender, RoutedEventArgs e)
        {
            LanguageGUI.changeLanguage("hu-HU");
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}