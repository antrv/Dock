using System.Linq;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Metadata;

namespace AvaloniaDemo.Views
{
    public class Item : StyledElement
    {
        public static readonly StyledProperty<string> IdProperty =
            AvaloniaProperty.Register<Item, string>(nameof(Id));

        public static readonly StyledProperty<object> ContentProperty =
            AvaloniaProperty.Register<Item, object>(nameof(Content));

        public string Id
        {
            get { return GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        [Content]
        public object Content
        {
            get { return GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
    }

    public class MainWindowViewModel : StyledElement
    {
        public static readonly StyledProperty<AvaloniaList<Item>> Items1Property =
            AvaloniaProperty.Register<MainWindow, AvaloniaList<Item>>(nameof(Items1), new AvaloniaList<Item>());

        public static readonly StyledProperty<AvaloniaList<Item>> Items2Property =
            AvaloniaProperty.Register<MainWindow, AvaloniaList<Item>>(nameof(Items2), new AvaloniaList<Item>());

        public static readonly StyledProperty<Item> SelectedItem1Property =
            AvaloniaProperty.Register<MainWindow, Item>(nameof(SelectedItem1));

        public static readonly StyledProperty<Item> SelectedItem2Property =
            AvaloniaProperty.Register<MainWindow, Item>(nameof(SelectedItem2));

        public AvaloniaList<Item> Items1
        {
            get { return GetValue(Items1Property); }
            set { SetValue(Items1Property, value); }
        }

        public AvaloniaList<Item> Items2
        {
            get { return GetValue(Items2Property); }
            set { SetValue(Items2Property, value); }
        }

        public Item SelectedItem1
        {
            get { return GetValue(SelectedItem1Property); }
            set { SetValue(SelectedItem1Property, value); }
        }

        public Item SelectedItem2
        {
            get { return GetValue(SelectedItem2Property); }
            set { SetValue(SelectedItem2Property, value); }
        }

        public void MoveToItems1()
        {
            if (SelectedItem2 != null)
            {
                var item = SelectedItem2;
                SelectedItem2 = null;
                Items2.Remove(item);
                Items1.Add(item);
                SelectedItem2 = Items2.FirstOrDefault();
                SelectedItem1 = Items1.LastOrDefault();
            }
        }

        public void MoveToItems2()
        {
            if (SelectedItem1 != null)
            {
                var item = SelectedItem1;
                SelectedItem1 = null;
                Items1.Remove(item);
                Items2.Add(item);
                SelectedItem1 = Items1.FirstOrDefault();
                SelectedItem2 = Items2.LastOrDefault();
            }
        }
    }

    public class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.AttachDevTools();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
