using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ShoppingList
{
    public class MainWindowViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void SetProperty<T>(ref T field, T value,
            [CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ObservableCollection<Item> ShoppingList { get; } = new ObservableCollection<Item>();

        private string _Item;
        public string Item
        {
            get => _Item;
            set => SetProperty(ref _Item, value, nameof(Item));
        }

        private Item _SelectedItem;
        public Item SelectedItem
        {
            get => _SelectedItem;
            set => SetProperty(ref _SelectedItem, value);
        }

        public Command AddItemCommand { get; }
        public Command RemoveItemCommand { get; }
        public ICommand ChangeItemNameCommand { get; }

        private bool CanExecute { get; set; }

        public MainWindowViewModel()
        {
            
            AddItemCommand = new Command(OnAddItem);
            RemoveItemCommand = new Command(OnRemoveItem);
            ChangeItemNameCommand = new Command(OnChangeItem);

            ShoppingList.Add(new Item("Bread"));
            ShoppingList.Add(new Item("Milk"));

        }

        private void OnAddItem()
        {
            ShoppingList.Add(new Item(Item));
            CanExecute = true;
            AddItemCommand.InvokeCanExecuteChanged();
        }

        private void OnRemoveItem()
        {
            if (!(SelectedItem is null))
            {
                ShoppingList.Remove(SelectedItem);
                CanExecute = true;
                RemoveItemCommand.InvokeCanExecuteChanged();
            }

        }

        private void OnChangeItem()
        {
            Item = SelectedItem.ToString();
        }



    }
}