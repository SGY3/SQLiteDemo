using SQLiteDemo.MVVM.Models;
using SQLiteDemo.MVVM.Utility;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PropertyChanged;

namespace SQLiteDemo.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class ItemViewModel
    {
        private readonly Repository _repository = new();

        public ObservableCollection<Item> Items { get; set; } = new();
        public Item NewItem { get; set; } = new();
        public Item EditableItem { get; set; } = new();

        public bool IsEditPopupVisible { get; set; }

        public ICommand AddItemCommand { get; }
        public ICommand DeleteItemCommand { get; }
        public ICommand LoadItemsCommand { get; }
        public ICommand OpenEditPopupCommand { get; }
        public ICommand SaveEditedItemCommand { get; }
        public ICommand CloseEditPopupCommand { get; }

        public ItemViewModel()
        {
            AddItemCommand = new Command(AddItem);
            DeleteItemCommand = new Command<Item>(DeleteItem);
            OpenEditPopupCommand = new Command<Item>(OpenEditPopup);
            SaveEditedItemCommand = new Command(SaveEditedItem);
            CloseEditPopupCommand = new Command(CloseEditPopup);
            LoadItemsCommand = new Command(LoadItems);

            LoadItems();
        }

        private void LoadItems()
        {
            Items.Clear();
            foreach (var item in _repository.GetItems())
                Items.Add(item);
        }

        private void AddItem()
        {
            if (string.IsNullOrWhiteSpace(NewItem.Name))
                return;

            _repository.AddItem(NewItem);
            Items.Add(NewItem);
            NewItem = new Item(); // reset
        }

        private void DeleteItem(Item item)
        {
            if (item == null) return;

            _repository.DeleteItem(item.Id);
            Items.Remove(item);
        }

        private void OpenEditPopup(Item item)
        {
            if (item == null) return;

            EditableItem = new Item
            {
                Id = item.Id,
                Name = item.Name,
                ItemPrice = item.ItemPrice,
                Description = item.Description
            };

            IsEditPopupVisible = true;
        }

        private void SaveEditedItem()
        {
            if (EditableItem == null)
                return;

            _repository.UpdateItem(EditableItem);
            LoadItems();
            IsEditPopupVisible = false;
        }

        private void CloseEditPopup()
        {
            IsEditPopupVisible = false;
        }
    }
}
