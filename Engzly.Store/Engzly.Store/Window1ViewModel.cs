using Engzly.Store.Base;
using Engzly.Store.Entities;
using Engzly.Store.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Engzly.Store
{
    public class Window1ViewModel : BaseViewModel
    {
        EnzglyStoreEntities db;
        public ObservableCollection<Entities.Store> StoresCollection { get; set; }
        // public ICommand ButtonCommand { get; private set; }

        public Window1ViewModel()
        {
            db = new EnzglyStoreEntities();
            var Stores = db.Stores.ToList();
            StoresCollection = new ObservableCollection<Entities.Store>();
            foreach (var item in Stores)
            {
                StoresCollection.Add(item);
            }
            _canExecute = true;
        }



        public ICommand MyButtonClickCommand
        {
            get; 
        }

        private void FuncToCall(object context)
        {
            //this is called when the button is clicked
        }

        private bool FuncToEvaluate(object context)
        {                                                                                                                                                                                                                                                                                                   
            //this is called to evaluate whether FuncToCall can be called
            //for example you can return true or false based on some validation logic
            return true;
        }

        private ICommand _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), _canExecute));
            }
        }
        private bool _canExecute;
        public void MyAction()
        {

        }
        

        private Entities.Store _selectedStore;
        public  Entities.Store SelectedStore
        {
            get { return _selectedStore; }
            set
            {
                if (value != _selectedStore)
                {
                    _selectedStore = value;
                    OnPropertyChanged("SelectedStore");
                    StoreByIDWindow StoreByIDWidow = new StoreByIDWindow(SelectedStore.Id);
                    StoreByIDWidow.Show();
                }
            }
        }

        public ObservableCollection<string> SomeCollection { get; set; }
        public ICommand TestCommand
        {
            get; private set;
        }

        private ICommand _doSomething;
        public ICommand ButtonCommand
        {
            get
            {
                if (_doSomething == null)
                {

                }
                return _doSomething;
            }
        }

        CommandHandler _saveCommand;
        //public ICommand SaveCommand
        //{
        //    get
        //    {
        //        if (_saveCommand == null)
        //        {
        //            _saveCommand = new RelayCommand(param => this.Save(),
        //                param => true);
        //        }
        //        return _saveCommand;
        //    }
        //}

        public void Save()
        {

        }
    }
    class StoreViewModel
    {
        public int Id { get; set; }
        public string storeName { get; set; }
        public string storeAddresse { get; set; }
        public string storeDetails { get; set; }
    }
}
