using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planner.Tasks
{
    class TaskModel: INotifyPropertyChanged
    {
        private DateTime _creationDate;
        public DateTime CreationDate
        {
            get { return _creationDate; }
            set 
            {
                if (_creationDate == value)
                    return;
                _creationDate = value;
                OnPropertyChanged("CreationDate");
            }
        }

        private bool _isDone;
        public bool IsDone
        {
            get { return _isDone; }
            set 
            {
                if (_isDone == value)
                    return;
                _isDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        private string _text;

        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                    return;
                _text = value;
                OnPropertyChanged("Text");
            }
    }

        public event PropertyChangedEventHandler PropertyChanged;
         
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }       
    }
}
