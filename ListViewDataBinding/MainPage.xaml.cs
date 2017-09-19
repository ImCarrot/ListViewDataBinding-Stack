using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ListViewDataBinding
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += (s, e) =>
            {
                ItemsCollection = new ObservableCollection<ItemsClass>(new List<ItemsClass>()
                {
                    new ItemsClass(){ ItemName="Espresso" ,ItemDescription = "The espresso (aka “short black”) is the foundation and the most important part to every espresso based drink.", IsFavorite = true },
                    new ItemsClass(){ ItemName="Short Macchiato", ItemDescription = "A short macchiato is similar to an espresso but with a dollop of steamed milk and foam to mellow the harsh taste of an espresso.", IsFavorite = true },
                    new ItemsClass(){ ItemName = "Ristretto",ItemDescription = "A ristretto is an espresso shot that is extracted with the same amount of coffee but half the amount of water.", IsFavorite = false},
                    new ItemsClass(){ ItemName = "Café Latte",ItemDescription ="A café latte, or “latte” for short, is an espresso based drink with steamed milk and micro-foam added to the coffee.", IsFavorite = false },
                });

            };
        }



        private ObservableCollection<ItemsClass> itemsCollection;
        internal ObservableCollection<ItemsClass> ItemsCollection
        {
            get { return itemsCollection; }
            set { itemsCollection = value; RaisePropertyChanged(nameof(ItemsCollection)); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void ItemSelected(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is ItemsClass selectedItem)
                selectedItem.IsFavorite = !selectedItem.IsFavorite;
        }
    }
}
