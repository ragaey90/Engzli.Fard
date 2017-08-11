using Engzly.Store.Base;
using Engzly.Store.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Engzly.Store.Stores
{
    public class StoreByIDViewModel : BaseViewModel
    {
        private int StoreId { get; set; }
        private EnzglyStoreEntities db;

        public StoreByIDViewModel(int id)
        {
            db = new EnzglyStoreEntities();
            ItemCollection = new ObservableCollection<Item>();
            StoreId = id;
            FillStoreGrid();
        }
        public ObservableCollection<Item> ItemCollection { get; set; }

        //private ObservableCollection<Item> _itemCollection;
        //public ObservableCollection<Item> ItemCollection
        //{
        //    get { return _itemCollection; }
        //    set
        //    {
        //        if (value != _itemCollection)
        //        {
        //            _itemCollection = value;
        //            OnPropertyChanged("ItemCollection");
        //        }
        //    }
        //}


        private void FillStoreGrid()
        {
            var query = db.Items.Where(n => n.storeId == StoreId).ToList();
            foreach (var item in query)
            {
                ItemCollection.Add(item);
            }
        }
    }
}
