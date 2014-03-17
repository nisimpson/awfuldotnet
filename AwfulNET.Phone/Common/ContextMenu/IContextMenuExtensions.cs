using AwfulNET.Phone;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace AwfulNET.Common
{
    public static class IContextMenuExtensions
    {
        public static ContextMenu ToContextMenu(this IContextMenu source, ContextMenu menu)
        {
            menu.Items.Clear();
            foreach(var item in source.Items)
            {
                MenuItem contextmenuItem = new MenuItem();
                contextmenuItem.Header = item.Header;
                contextmenuItem.Command = item.Command;
                contextmenuItem.CommandParameter = item.CommandParameter;
                menu.Items.Add(contextmenuItem);
            }

            return menu;
        }

        public static ContextMenu ToContextMenu(this IContextMenu source)
        {
            return ToContextMenu(source, new ContextMenu());
        }

        public static Popup ToPopup(this IContextMenu source)
        {
            Popup popup = new Popup();
            // this offset assumes the phone is in portrait orientation.
            popup.VerticalOffset = 32;

            ItemsControl items = new ItemsControl();
            foreach(var item in source.Items)
            {
                Button button = new Button();
                button.Content = item.Header;
                button.Command = new RelayCommand<object>(
                    (param) => { popup.IsOpen = false; item.Command.Execute(param); },
                    (param) => item.Command.CanExecute(param));

                button.CommandParameter = item.CommandParameter;
                button.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                items.Items.Add(button);
            }

            Border border = new Border();
            border.Padding = new System.Windows.Thickness(12);
            border.MinWidth = 480;
            border.Background = App.Current.Resources["PhoneChromeBrush"] as Brush;
            border.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            border.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
            border.Child = items;

            popup.Child = border;
            return popup;
        }

        public static Task ShowAsync(this Popup menu)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            PhoneApplicationFrame frame = App.Current.RootVisual as PhoneApplicationFrame;
            EventHandler<System.ComponentModel.CancelEventArgs> backKeyPress = null;
            EventHandler<System.Windows.Input.GestureEventArgs> tap = null;
            EventHandler closed = null;

            tap = (o, a) =>
                {
                    (o as Popup).Tap -= tap;
                    frame.BackKeyPress -= backKeyPress;
                    tcs.SetResult(true);
                };

            backKeyPress = (o, a) =>
                {
                   (o as PhoneApplicationFrame).BackKeyPress -= backKeyPress;
                    menu.Tap -= tap;
                    menu.IsOpen = false;
                    a.Cancel = true;
                    tcs.SetResult(true);
                };

            closed = (o, a) =>
                {
                    frame.BackKeyPress -= backKeyPress;
                    menu.Tap -= tap;
                    menu.Closed -= closed;
                    tcs.SetResult(true);
                };

            menu.Tap += tap;
            menu.Closed += closed;
            frame.BackKeyPress += backKeyPress;
            menu.IsOpen = true;
            return tcs.Task;
        }
    }
}
