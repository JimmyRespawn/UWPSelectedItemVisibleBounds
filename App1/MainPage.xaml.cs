using System;
using System.Collections.Generic;
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
using Windows.UI.ViewManagement;
using System.Net.Http;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Media.Playback;
using Windows.Media;
using System.Xml.Linq;
using Windows.Media.Core;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Core;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.AccessCache;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.ApplicationModel.Store;
using System.Threading;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using Windows.Storage.FileProperties;
using Windows.Foundation.Metadata;
using Windows.UI.Xaml.Media.Animation;


// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace App1
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public class car
        {
            public string name { get; set; }
        }

        public static ObservableCollection<car> Collection1 = new ObservableCollection<car>();
        public static ObservableCollection<car> Collection2 = new ObservableCollection<car>();
        public static ObservableCollection<car> Collection3 = new ObservableCollection<car>();

        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            for(var i = 0; i < 5; i++)
            {
                car c = new car();
                c.name = "Tesla";
                Collection1.Add(c);
                Collection2.Add(c);
                Collection3.Add(c);
            }
            VGList.ItemsSource = Collection1;
            Whatlist.ItemsSource = Collection1;
            TopList.ItemsSource = Collection1;
        }

        private void GridView_SizeChanged5(object sender, SizeChangedEventArgs e)
        {
            var panel = (ItemsWrapGrid)TopList.ItemsPanelRoot;
            if (e.NewSize.Width < 310)
                panel.ItemWidth = e.NewSize.Width - 5;
            else if (e.NewSize.Width < 450)
                panel.ItemWidth = e.NewSize.Width / 2 - 4;
            else if (e.NewSize.Width < 590)
                panel.ItemWidth = e.NewSize.Width / 3 - 3;
            else if (e.NewSize.Width < 1210)
                panel.ItemWidth = e.NewSize.Width / 4 - 2;
            else if (e.NewSize.Width < 2150)
                panel.ItemWidth = e.NewSize.Width / 5 - 1;
            else
                panel.ItemWidth = 300;
        }

        private void GridView_SizeChanged3(object sender, SizeChangedEventArgs e)
        {
            var panel = (ItemsWrapGrid)VGList.ItemsPanelRoot;
            if (e.NewSize.Width < 310)
                panel.ItemWidth = e.NewSize.Width - 5;
            else if (e.NewSize.Width < 450)
                panel.ItemWidth = e.NewSize.Width / 2 - 4;
            else if (e.NewSize.Width < 590)
                panel.ItemWidth = e.NewSize.Width / 3 - 3;
            else if (e.NewSize.Width < 1210)
                panel.ItemWidth = e.NewSize.Width / 4 - 2;
            else if (e.NewSize.Width < 2150)
                panel.ItemWidth = e.NewSize.Width / 5 - 1;
            else
                panel.ItemWidth = 300;
        }

        private void GridView_SizeChanged4(object sender, SizeChangedEventArgs e)
        {
            var panel = (ItemsWrapGrid)Whatlist.ItemsPanelRoot;
            if (e.NewSize.Width < 310)
                panel.ItemWidth = e.NewSize.Width - 5;
            else if (e.NewSize.Width < 450)
                panel.ItemWidth = e.NewSize.Width / 2 - 4;
            else if (e.NewSize.Width < 590)
                panel.ItemWidth = e.NewSize.Width / 3 - 3;
            else if (e.NewSize.Width < 1210)
                panel.ItemWidth = e.NewSize.Width / 4 - 2;
            else if (e.NewSize.Width < 2150)
                panel.ItemWidth = e.NewSize.Width / 5 - 1;
            else
                panel.ItemWidth = 300;
        }

        private void ItemsWrapGrid_BringIntoViewRequested(UIElement sender, BringIntoViewRequestedEventArgs args)
        {
            if (args.VerticalAlignmentRatio != 0.5)  // Guard against our own request
            {
                args.Handled = true;
                // Swallow this request and restart it with a request to center the item.  We could instead have chosen
                // to adjust the TargetRect’s Y and Height values to add a specific amount of padding as it bubbles up, 
                // but if we just want to center it then this is easier.

                // (Optional) Account for sticky headers if they exist
                var headerOffset = 0.0;
                var itemsWrapGrid = sender as ItemsWrapGrid;
                if (TopList.IsGrouping && itemsWrapGrid.AreStickyGroupHeadersEnabled)
                {
                    var header = TopList.GroupHeaderContainerFromItemContainer(args.TargetElement as GridViewItem);
                    if (header != null)
                    {
                        headerOffset = ((FrameworkElement)header).ActualHeight;
                    }
                }

                // Issue a new request
                args.TargetElement.StartBringIntoView(new BringIntoViewOptions()
                {
                    AnimationDesired = true,
                    VerticalAlignmentRatio = 0.5, // a normalized alignment position (0 for the top, 1 for the bottom)
                    VerticalOffset = headerOffset, // applied after meeting the alignment ratio request
                });
            }
        }

        private void ItemsWrapGrid_BringIntoViewRequested1(UIElement sender, BringIntoViewRequestedEventArgs args)
        {
            if (args.VerticalAlignmentRatio != 0.5)  // Guard against our own request
            {
                args.Handled = true;
                // Swallow this request and restart it with a request to center the item.  We could instead have chosen
                // to adjust the TargetRect’s Y and Height values to add a specific amount of padding as it bubbles up, 
                // but if we just want to center it then this is easier.

                // (Optional) Account for sticky headers if they exist
                var headerOffset = 0.0;
                var itemsWrapGrid = sender as ItemsWrapGrid;
                if (Whatlist.IsGrouping && itemsWrapGrid.AreStickyGroupHeadersEnabled)
                {
                    var header = Whatlist.GroupHeaderContainerFromItemContainer(args.TargetElement as GridViewItem);
                    if (header != null)
                    {
                        headerOffset = ((FrameworkElement)header).ActualHeight;
                    }
                }

                // Issue a new request
                args.TargetElement.StartBringIntoView(new BringIntoViewOptions()
                {
                    AnimationDesired = true,
                    VerticalAlignmentRatio = 0.5, // a normalized alignment position (0 for the top, 1 for the bottom)
                    VerticalOffset = headerOffset, // applied after meeting the alignment ratio request
                });
            }
        }

        private void ItemsWrapGrid_BringIntoViewRequested2(UIElement sender, BringIntoViewRequestedEventArgs args)
        {
            if (args.VerticalAlignmentRatio != 0.5)  // Guard against our own request
            {
                args.Handled = true;
                // Swallow this request and restart it with a request to center the item.  We could instead have chosen
                // to adjust the TargetRect’s Y and Height values to add a specific amount of padding as it bubbles up, 
                // but if we just want to center it then this is easier.

                // (Optional) Account for sticky headers if they exist
                var headerOffset = 0.0;
                var itemsWrapGrid = sender as ItemsWrapGrid;
                if (VGList.IsGrouping && itemsWrapGrid.AreStickyGroupHeadersEnabled)
                {
                    var header = VGList.GroupHeaderContainerFromItemContainer(args.TargetElement as GridViewItem);
                    if (header != null)
                    {
                        headerOffset = ((FrameworkElement)header).ActualHeight;
                    }
                }

                // Issue a new request
                args.TargetElement.StartBringIntoView(new BringIntoViewOptions()
                {
                    AnimationDesired = true,
                    VerticalAlignmentRatio = 0.5, // a normalized alignment position (0 for the top, 1 for the bottom)
                    VerticalOffset = headerOffset, // applied after meeting the alignment ratio request
                });
            }
        }
    }
}
