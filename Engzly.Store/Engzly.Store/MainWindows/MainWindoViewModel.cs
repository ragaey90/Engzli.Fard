using Engzly.Store.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Engzly.Store.Entities;

namespace Engzly.Store.MainWindow
{
    public class MainWindoViewModel : BaseViewModel
    {
        EnzglyStoreEntities db;
        List<Entities.Store> StoresCollection = new List<Entities.Store>();
        public MainWindoViewModel()
        {
            db = new EnzglyStoreEntities();
            StoresCollection = db.Stores.ToList();
        }
        //private ICommand _doSomething;
        //public ICommand DoSomethingCommand
        //{
        //    get
        //    {
        //        if (_doSomething == null)
        //        {
        //            _doSomething = new RelayCommand(
        //                p => this.CanDoSomething,
        //                p => this.DoSomeImportantMethod());
        //        }
        //        return _doSomething;
        //    }
        //}
    }
}
