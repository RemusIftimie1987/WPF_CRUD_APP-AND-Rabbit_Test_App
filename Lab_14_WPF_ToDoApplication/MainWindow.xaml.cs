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

namespace Lab_14_WPF_ToDoApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<string> items = new List<string>();
        List<Task> tasks = new List<Task>();
        Task task = new Task();
        Task taskToAdd = new Task();
        List<Category> categories = new List<Category>();
        BrushConverter brush = new BrushConverter();
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            #region v01
            //    ListBoxTasks.ItemsSource = items;
            //    //items.Add("Hey this is an item");
            //    using (var db = new TasksDBEntities())
            //    {
            //        tasks = db.Tasks.ToList();
            //    }
            //    foreach (var item in tasks)
            //    {
            //        items.Add($"{ item.TasksID, -10}{ item.Description}{item.Done, -10 }{item.DateDone}");
            //    }
            //}
            #endregion
            using (var db = new TasksDBEntities1())
            {
                tasks = db.Tasks.ToList();
                categories = db.Categories.ToList();
            }
            ListBoxTasks.ItemsSource = tasks;
            ListBoxTasks.DisplayMemberPath = "Description";
            ComboBoxCategory.ItemsSource = categories;
            ComboBoxCategory.DisplayMemberPath = "CategoryName";

        }
        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBoxCategoryId.IsReadOnly = true;
            TextBoxCategoryId.Background = (Brush)brush.ConvertFrom("#C3FFB6");
            TextBoxDescription.IsReadOnly = true;
            TextBoxDescription.Background = (Brush)brush.ConvertFrom("#C3FFB6");


            // print out details of selected items
            //instance = (convert to Task) the item selected in listbox by user
            task = (Task)ListBoxTasks.SelectedItem;
            if (task != null)
            {
                TextBoxId.Text = task.TasksID.ToString();
                TextBoxDescription.Text = task.Description;
                TextBoxCategoryId.Text = task.CategoriesID.ToString();
                ButtonEdit.IsEnabled = true;
                ButtonDelete.IsEnabled = true;
                ButtonDelete.Content = "Delete";
                ButtonAdd.Content = "Add";
                ButtonEdit.Content = "Edit";
                TextBoxId.IsReadOnly = true;
                TextBoxCategoryId.IsReadOnly = true;
                TextBoxDescription.IsReadOnly = true;
                
                if (task.CategoriesID != null)
                {
                    ComboBoxCategory.SelectedIndex = (int)task.CategoriesID;
                }
                else
                {
                    ComboBoxCategory.SelectedItem = null;
                }
            }
        }

        private void ListBoxTasks_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            // get object
            task = (Task)ListBoxTasks.SelectedItem;
            if (task != null)
            {
                // set the boxes for edit
                TextBoxId.Text = task.TasksID.ToString();
                TextBoxDescription.Text = task.Description;
                TextBoxCategoryId.Text = task.CategoriesID.ToString();
                ButtonEdit.IsEnabled = true;
                if (task.CategoriesID != null)
                {
                    ComboBoxCategory.SelectedIndex = (int)task.CategoriesID - 1;
                }
                else
                {
                    ComboBoxCategory.SelectedItem = null;
                }
            }
            else
            {
                //complete here
            }
        }
        public void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonEdit.Content.ToString() == "Edit")
            {
                TextBoxCategoryId.IsReadOnly = false;
                TextBoxCategoryId.Background = Brushes.White;
                TextBoxDescription.IsReadOnly = false;
                TextBoxDescription.Background = Brushes.White;
                ButtonEdit.IsEnabled = true;
                ButtonEdit.Content = "Save";
            }
            else if (ButtonEdit.Content.ToString() == "Save")
            {
                using (var db = new TasksDBEntities1())
                {
                    var taskToEdit = db.Tasks.Find(task.TasksID);
                    //update description
                    taskToEdit.Description = TextBoxDescription.Text;
                    //converting category id to integer from textbox
                    //Safe way of doing a conversion: null
                    int.TryParse(TextBoxCategoryId.Text, out int categoryId);
                    taskToEdit.CategoriesID = categoryId;
                    if (task.CategoriesID != null)
                    {
                        ComboBoxCategory.SelectedIndex = (int)taskToEdit.CategoriesID;
                    }
                    else
                    {
                        ComboBoxCategory.SelectedItem = null;
                    }
                    //save changes to database
                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null; //reset listbox
                    tasks = db.Tasks.ToList();
                    ListBoxTasks.ItemsSource = tasks;
                }

                TextBoxCategoryId.IsReadOnly = true;
                TextBoxCategoryId.Background = (Brush)brush.ConvertFrom("#EEFAFF");

                TextBoxDescription.IsReadOnly = true;
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#EEFAFF");
                ButtonEdit.IsEnabled = false;
                ButtonEdit.Content = "Edit";
                ButtonDelete.IsEnabled = false;

            }
        }

        public void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonAdd.Content.ToString() == "Add")
            {
                ButtonAdd.Content = "Confirm?";
                TextBoxCategoryId.Background = Brushes.White;
                TextBoxDescription.Background = Brushes.White;
                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryId.IsReadOnly = false;
                //clear out boxes
                TextBoxId.Text = "";
                TextBoxDescription.Text = "";
                TextBoxCategoryId.Text = "";

            }
            else
            {
                ButtonAdd.Content = "Add";
                //set boxes back to readonly
                TextBoxDescription.IsReadOnly = true;
                TextBoxCategoryId.IsReadOnly = true;
                
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#C3FFB6");
                TextBoxCategoryId.Background = (Brush)brush.ConvertFrom("#C3FFB6");
                //add record to database
                int.TryParse(TextBoxCategoryId.Text, out int categoryID);
                var taskToAdd = new Task()
                {
                    Description = TextBoxDescription.Text,
                    CategoriesID = categoryID
                };
                using (var db = new TasksDBEntities1())
                {
                    db.Tasks.Add(taskToAdd);
                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null; //reset listbox
                    tasks = db.Tasks.ToList();
                    ListBoxTasks.ItemsSource = tasks;
                }

            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDelete.Content.ToString() == "Delete")
            {
                ButtonDelete.Content = "Confirm";
                //TextBoxId.Background = Brushes.OrangeRed;
                TextBoxDescription.Background = Brushes.OrangeRed;
                TextBoxCategoryId.Background = Brushes.OrangeRed;
            }
            else if (ButtonDelete.Content.ToString() == "Confirm")
            {
                using (var db = new TasksDBEntities1())
                {
                    var removeId = db.Tasks.Find(task.TasksID);
                    db.Tasks.Remove(removeId);
                    db.SaveChanges();
                    //update List
                    ListBoxTasks.ItemsSource = null; //reset listbox
                    tasks = db.Tasks.ToList();
                    ListBoxTasks.ItemsSource = tasks;
                }
                ButtonDelete.Content = "Delete";
                ButtonDelete.IsEnabled = false;
                ButtonEdit.IsEnabled = false;
            }
        }
    }
}
