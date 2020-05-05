using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MyContacts.xaml
    /// </summary>

    public partial class MyContacts : Window
    {
        public Student ThisStudent { get; set; }
        public string photoPath { get; set; }
        public MyContacts(Student s)
        {
            InitializeComponent();
            ThisStudent = s;
            ThisStudent.addressBook.Contacts = ThisStudent.addressBook.Contacts.OrderBy(o => o.getFullname).ToList();

            this.listElement.ItemsSource = ThisStudent.addressBook.Contacts;
            this.lblLogoutname.Content = ThisStudent.FullName;
            disableElements();
            selectContact();

        }
        //this event handler fires up when text is changed in search bar to filtr out contacts
        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            disableElements();
            string changedText = this.SearchElement.Text;
            List<Contact> searchList = ThisStudent.addressBook[changedText];
            this.listElement.ItemsSource = searchList;
            selectContact();
            Console.WriteLine("Searched");
        }
        //Associated with Plaeholder text on search bar
        private void SearchElementLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchElement.Text))
            {
                SearchElement.Visibility = System.Windows.Visibility.Collapsed;
                SearchPlaceHolderElement.Visibility= System.Windows.Visibility.Visible;

            }
        }
        //Associated with Plaeholder text on search bar

        private void SearchPlaceHolderElementGotFocus(object sender, RoutedEventArgs e)
        {
            SearchPlaceHolderElement.Visibility = System.Windows.Visibility.Collapsed;
            SearchElement.Visibility = System.Windows.Visibility.Visible;
            SearchElement.Focus();
        }
        //this event handler manages to choose a Profile picture of a contact
        //it sets selected picture's path as photo_path whick is displayed and stored later on in a object
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName.Replace("\\","/");
                this.photoPath = filename;
                this.ProfilePictureElement.ImageSource = new BitmapImage(new Uri(filename, UriKind.Absolute));
            }
            
        }
        //this enent occurs when new contact is added
        private void BtnNew_Click(object sender, RoutedEventArgs e)
        {
            this.listElement.UnselectAll();
            enableElements();
            this.BtnDelete.Visibility = System.Windows.Visibility.Hidden;
            this.BtnEdit.Visibility = System.Windows.Visibility.Hidden;


            this.BtnSave.Content = "Save";
        }

        //this event is fired when user click on ListBox, It automatically select an Item if available and changes UI accordingly
        private void listElement_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Listbox selected");
            disableElements(); 
            if (ThisStudent.addressBook.Contacts.Count > -1)
            {
                this.BtnDelete.Visibility = System.Windows.Visibility.Visible;
                this.BtnEdit.Visibility = System.Windows.Visibility.Visible;
            }
            this.ProfilePictureElement.ImageSource = null;
            this.TxtFname.BorderBrush = null;
            this.TxtLname.BorderBrush = null;
            this.TxtCc.BorderBrush = null;
            this.TxtPhone.BorderBrush = null;
            this.TxtEmail.BorderBrush = null;
            this.prompt.Content = "";
        }

        //this method manages updation and insertation of new Contact 
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (validateForm())
            {
                Contact newContact = new Contact
                {
                    First_name = this.TxtFname.Text,
                    Last_name = this.TxtLname.Text,
                    Country_code = this.TxtCc.Text,
                    Phone = this.TxtPhone.Text,
                    Address = this.TxtAddress.Text,
                    Email = this.TxtEmail.Text,
                    Job_title = this.TxtJob.Text,
                    Company = this.TxtCompany.Text,
                    Photo_source = this.photoPath
                };

                if (((Button)sender).Content == "Update")
                {
                    if (newContact.Photo_source == "")
                    {
                        newContact.Photo_source = this.TxtPhoto.Text;
                    }
                    ThisStudent.addressBook.Contacts[this.listElement.SelectedIndex] = newContact;
                }
                if (((Button)sender).Content == "Save")
                {
                    ThisStudent.addContact(newContact);
                }
                ThisStudent.addressBook.Contacts = ThisStudent.addressBook.Contacts.OrderBy(o => o.getFullname).ToList();
                this.listElement.ItemsSource = this.ThisStudent.addressBook.Contacts;
                this.listElement.Items.Refresh();
                this.ProfilePictureElement.ImageSource = null;
                this.TxtFname.BorderBrush = null;
                this.TxtLname.BorderBrush = null;
                this.TxtCc.BorderBrush = null;
                this.TxtPhone.BorderBrush = null;
                this.TxtEmail.BorderBrush = null;
                this.prompt.Content = "";
                disableElements();
                selectContact();

            }
            else
            {
                this.prompt.Content = "invalid or missing Data";
            }

        }
        private void disableElements()
        {
            this.BtnEdit.Visibility = System.Windows.Visibility.Hidden;
            this.BtnSave.Visibility = System.Windows.Visibility.Hidden;
            this.BtnDelete.Visibility = System.Windows.Visibility.Hidden;
            this.BtnSelectPhoto.Visibility = System.Windows.Visibility.Hidden;
  //          this.listElement.UnselectAll();
            this.TxtFname.IsEnabled = false;
            this.TxtCc.IsEnabled = false;
            this.TxtLname.IsEnabled = false;
            this.TxtCc.IsEnabled = false;
            this.TxtPhone.IsEnabled = false;
            this.TxtEmail.IsEnabled = false;
            this.TxtAddress.IsEnabled = false;
            this.TxtJob.IsEnabled = false;
            this.TxtCompany.IsEnabled = false;
            this.photoPath = "";
    //        if(ThisStudent.addressBook.Contacts.Count>0)
      //          this.listElement.SelectedIndex = 0;
        }
       //this function disables some UI elements Buttons and textBoxes on some conditions
        private void enableElements()
        {
            this.BtnSave.Visibility = System.Windows.Visibility.Visible;
            this.BtnSelectPhoto.Visibility = System.Windows.Visibility.Visible;
            this.BtnDelete.Visibility = System.Windows.Visibility.Visible;
            this.TxtFname.IsEnabled = true;
            this.TxtCc.IsEnabled = true;
            this.TxtLname.IsEnabled = true;
            this.TxtCc.IsEnabled = true;
            this.TxtPhone.IsEnabled = true;
            this.TxtEmail.IsEnabled = true;
            this.TxtAddress.IsEnabled = true;
            this.TxtJob.IsEnabled = true;
            this.TxtCompany.IsEnabled = true;
        }
        //this method makes a contact editable 
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            enableElements();
            this.BtnSave.Content = "Update";
            this.photoPath = "";
        }

        //this method manages delete operation of a specific contact
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete this contact?", "Delete Contact", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                ThisStudent.addressBook.Contacts.RemoveAt(this.listElement.SelectedIndex);
                ThisStudent.addressBook.Contacts = ThisStudent.addressBook.Contacts.OrderBy(o => o.getFullname).ToList();
                this.listElement.ItemsSource = this.ThisStudent.addressBook.Contacts;
                this.listElement.Items.Refresh();
                disableElements();
                selectContact();
            }
        }
        
        //this function automatically selects an item in a listbox
        private void selectContact()
        {
            if (this.listElement.Items.Count > 0)
            {
                this.listElement.SelectedIndex = 0;
                this.BtnDelete.Visibility = System.Windows.Visibility.Visible;
                this.BtnEdit.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.BtnDelete.Visibility = System.Windows.Visibility.Hidden;
                this.BtnEdit.Visibility = System.Windows.Visibility.Hidden;
            }
        }
       
        // this event handler Logouts the current student
        //after log out the changes data is lost
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to logout your session", "Logout Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {

                Window login = new MainWindow();
                
                this.Close();
                login.Show();
            }
        }
        //this functions validated the input form of Contact and apply some changes on UI accordingly
        private bool validateForm()
        {
            string fname = this.TxtFname.Text;
            string lname = this.TxtLname.Text;
            string cc = this.TxtCc.Text;
            string phone = this.TxtPhone.Text;
            string email = this.TxtEmail.Text;
            string address = this.TxtAddress.Text;
            string job = this.TxtJob.Text;
            string company = this.TxtCompany.Text;
            bool check = true;
            if(fname=="" || !fname.Any(char.IsLetter) || fname.Any(char.IsPunctuation))
            {
                this.TxtFname.BorderBrush = Brushes.Red;
                check = false;
            }
            if (!lname.Any(char.IsLetter) || lname.Any(char.IsPunctuation))
            {
                this.TxtLname.BorderBrush = Brushes.Red;
                check = false;
            }
            if(cc.Any(char.IsLetter)|| cc.Any(char.IsWhiteSpace)|| !cc.Any(c=>c=='+'))
            {
                this.TxtCc.BorderBrush = Brushes.Red;
                check = false;
            }
            if (!phone.Any(char.IsDigit))
            {
                this.TxtPhone.BorderBrush = Brushes.Red;
                check = false;
            }
            if (!new EmailAddressAttribute().IsValid(email))
            {
                this.TxtEmail.BorderBrush = Brushes.Red;

                check = false;
            }
            return check;

        }

    }
}
