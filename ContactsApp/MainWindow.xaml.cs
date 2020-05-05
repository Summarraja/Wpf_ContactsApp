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

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Student> studentList;
        public MainWindow()
        {
            InitializeComponent();
            //initial list of Students with their associated addressBoooks
            studentList = new List<Student>()
            {
                new Student
                {
                    FullName="Summar Raja",
                    Username="Summar",
                    Password="12345",
                    addressBook= new AddressBook
                    {
                        Contacts = new List<Contact>{
                            new Contact
                            {
                                First_name = "Zulkifle",
                                Last_name = "Maroof",
                                Email = "zulkifle.maroof@gmail.com",
                                Country_code = "+92",
                                Phone = "03357867584",
                                Address = "Rawalpindi",
                                Photo_source = "Pictures/zulkifle.png",

                            },
                            new Contact
                            {
                                First_name = "Bilal",
                                Last_name = "Abbasi",
                                Email = "Bilal.abbasi@gmail.com",
                                Country_code = "+92",
                                Phone = "03358912584",
                                Address = "Rawalpindi",
                                Photo_source = "Pictures/bilal.png",
                            },
                            new Contact
                            {
                                First_name = "Uzair",
                                Last_name = "Ahmed",
                                Email = "uzair.ahmed@gmail.com",
                                Country_code = "+92",
                                Phone = "03120867588",
                                Address = "Peshawar",
                                Photo_source = "Pictures/uzair.png",
                            },
                            new Contact
                            {
                                First_name = "Talha",
                                Last_name = "Yousaf",
                                Email = "talha.yousaf@gmail.com",
                                Country_code = "+92",
                                Phone = "03123667500",
                                Address = "Sargodha",
                                Photo_source = "Pictures/talha.png",
                            },
                            new Contact
                            {
                                First_name = "Mian",
                                Last_name = "Muzammil",
                                Email = "mian.muzammil@gmail.com",
                                Country_code = "+92",
                                Phone = "03120867588",
                                Address = "Sargodha",
                                Photo_source = "Pictures/mian.png",
                            },
                            new Contact
                            {
                                First_name = "Talat",
                                Last_name = "Huaasin",
                                Email = "talat.hussain@gmail.com",
                                Country_code = "+92",
                                Phone = "03120867588",
                                Address = "Rawalpindi",
                                Photo_source = "Pictures/talat.png",
                            },
                            new Contact
                            {
                                First_name = "Muhammad",
                                Last_name = "Sawaid",
                                Email = "M.sawaid@gmail.com",
                                Country_code = "+92",
                                Phone = "03120867588",
                                Address = "Peshawar",

                            }
                        }
                    }
                },new Student
                {
                    FullName="Rajab Ali",
                    Username="Rajab",
                    Password="12345",
                    addressBook= new AddressBook
                    {
                        Contacts = new List<Contact>{
                            new Contact
                            {
                                First_name = "Zulkifle",
                                Last_name = "Maroof",
                                Email = "zulkifle.maroof@gmail.com",
                                Country_code = "+92",
                                Phone = "03357867584",
                                Address = "Rawalpindi",
                                Photo_source = "Pictures/zulkifle.png",

                            },
                            new Contact
                            {
                                First_name = "Bilal",
                                Last_name = "Abbasi",
                                Email = "Bilal.abbasi@gmail.com",
                                Country_code = "+92",
                                Phone = "03358912584",
                                Address = "Rawalpindi",
                                Photo_source = "Pictures/bilal.png",
                            },
                            new Contact
                            {
                                First_name = "Uzair",
                                Last_name = "Ahmed",
                                Email = "uzair.ahmed@gmail.com",
                                Country_code = "+92",
                                Phone = "03120867588",
                                Address = "Peshawar",
                                Photo_source = "Pictures/uzair.png",
                            },
                            new Contact
                            {
                                First_name = "Talha",
                                Last_name = "Yousaf",
                                Email = "talha.yousaf@gmail.com",
                                Country_code = "+92",
                                Phone = "03123667500",
                                Address = "Sargodha",
                                Photo_source = "Pictures/talha.png",
                            },
                            new Contact
                            {
                                First_name = "Mian",
                                Last_name = "Muzammil",
                                Email = "mian.muzammil@gmail.com",
                                Country_code = "+92",
                                Phone = "03120867588",
                                Address = "Sargodha",
                                Photo_source = "Pictures/mian.png",
                            },
                            new Contact
                            {
                                First_name = "Talat",
                                Last_name = "Huaasin",
                                Email = "talat.hussain@gmail.com",
                                Country_code = "+92",
                                Phone = "03120867588",
                                Address = "Rawalpindi",
                                Photo_source = "Pictures/talat.png",
                            },
                            new Contact
                            {
                                First_name = "Osama",
                                Last_name = "Adil",
                                Email = "Osama.Adil@gmail.com",
                                Country_code = "+92",
                                Phone = "03120867588",
                                Address = "Wah Cant",
                            }
                        }
                    }
                }
            };
        }


        //this event handler associates with login button, it validated the username and password then initiates new window
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student stdFound = studentList.Find(x => x.Username == this.username.Text);

            if (stdFound != null && stdFound.Password == this.password.Password)
            {
                    Window myContacts = new MyContacts(stdFound);
                    this.Close();
                    myContacts.DataContext = stdFound;
                    myContacts.Show();
            }
            else
                prompt.Content = "Invalid Credidentials!";
        }
        //associated with Placeholder Text in Username text Field 
        private void usernameLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.username.Text))
            {
                this.username.Visibility = System.Windows.Visibility.Collapsed;
                this.usernamePlaceHolder.Visibility = System.Windows.Visibility.Visible;

            }
        }
        //associated with Placeholder Text in Username text Field
        private void usernamePlaceholderGotFocus(object sender, RoutedEventArgs e)
        {
            this.usernamePlaceHolder.Visibility = System.Windows.Visibility.Collapsed;
            this.username.Visibility = System.Windows.Visibility.Visible;
            this.username.Focus();
        }
        //associated with Placeholder Text in Password text Field
        private void passwordLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.password.Password))
            {
                this.password.Visibility = System.Windows.Visibility.Collapsed;
                this.passwordPlaceholder.Visibility = System.Windows.Visibility.Visible;

            }
        }

        //associated with Placeholder Text in Password text Field
        private void passwordPlaceholderGotFocus(object sender, RoutedEventArgs e)
        {
            this.passwordPlaceholder.Visibility = System.Windows.Visibility.Collapsed;
            this.password.Visibility = System.Windows.Visibility.Visible;
            this.password.Focus();
        }
    }
}
