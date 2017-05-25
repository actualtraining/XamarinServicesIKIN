using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinServicesIKIN.Model
{
    public class TodoItem : BindableObject
    {
        private string id;
        public string ID
        {
            get { return id; }
            set { id = value; OnPropertyChanged("ID"); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }


        private string notes;
        public string Notes
        {
            get { return notes; }
            set { notes = value; OnPropertyChanged("Notes"); }
        }

        private bool done;
        public bool Done
        {
            get { return done; }
            set { done = value; OnPropertyChanged("Done"); }
        }
    }
}
