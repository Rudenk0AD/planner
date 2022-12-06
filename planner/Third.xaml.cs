using planner.services;
using planner.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace planner
{
    /// <summary>
    /// Логика взаимодействия для Third.xaml
    /// </summary>
    public partial class Third : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\taskData.json";
        private BindingList<TaskModel> _taskData;
        private FileIOService _fileIOService;

        public Third()
        {
            InitializeComponent();

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);

            try
            {
                _taskData = _fileIOService.LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
           
          

            dgTaskList.ItemsSource = _taskData;
            _taskData.ListChanged += _taskData_ListChanged;

        }

        private void _taskData_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemAdded)
            {
                  try
                  {
                        _fileIOService.SaveData(sender);
                  }
                 catch (Exception ex)
                  {
                        MessageBox.Show(ex.Message);
                       Close();
                  }
             }
        }
    }
}
