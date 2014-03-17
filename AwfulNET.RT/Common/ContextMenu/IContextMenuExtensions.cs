using AwfulNET.RT.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace AwfulNET.Common
{
    public static class IContextMenuExtensions
    {
        public static AppBarButtonContainer ToAppBarButtonContainer(this IContextMenu source, bool isSecondary)
        {
            var menu = new AppBarButtonContainer();
            var commandsVector = isSecondary ? menu.SecondaryCommands : menu.PrimaryCommands;
            commandsVector.Clear();

            foreach (var item in source.Items)
            {
                AppBarButton button = new AppBarButton();
                commandsVector.Add(button);
                button.Label = item.Header;
                button.Command = item.Command;
                button.CommandParameter = item.CommandParameter;

                if (!string.IsNullOrEmpty(item.Icon))
                {
                    var icon = new SymbolIcon();
                    icon.Symbol = (Symbol)System.Enum.Parse(typeof(Symbol), item.Icon);
                    button.Icon = icon;
                }
                else
                    button.Icon = new SymbolIcon(Symbol.Emoji);
            }

            return menu;
        }

        public static CommandBar ToAppCommandBar(this IContextMenu source, CommandBar menu, bool isSecondary)
        {
            var commandsVector = isSecondary ? menu.SecondaryCommands : menu.PrimaryCommands;
            commandsVector.Clear();

            foreach(var item in source.Items)
            {
                AppBarButton button = new AppBarButton();
                commandsVector.Add(button);
                button.Label = item.Header;
                button.Command = item.Command;
                button.CommandParameter = item.CommandParameter;

                if (!string.IsNullOrEmpty(item.Icon))
                {
                    var icon = new SymbolIcon();
                    icon.Symbol = (Symbol)System.Enum.Parse(typeof(Symbol), item.Icon);
                    button.Icon = icon;
                }
                else
                    button.Icon = new SymbolIcon(Symbol.Emoji);
            }

            return menu;
        }

        public static CommandBar ToAppCommandBar(this IContextMenu source, bool isSecondary)
        {
            return ToAppCommandBar(source, new CommandBar(), isSecondary);
        }

        public static MenuFlyout ToMenuFlyout(this IContextMenu source, MenuFlyout flyout)
        {
            flyout.Items.Clear();
            foreach(var item in source.Items)
            {
                MenuFlyoutItem menu = new MenuFlyoutItem();
                menu.Text = item.Header;
                menu.Command = new RelayCommand<object>(
                    (param) => { flyout.Hide(); item.Command.Execute(param); },
                    (param) => { return item.Command.CanExecute(param); });
                menu.CommandParameter = item.CommandParameter;
                flyout.Items.Add(menu);
            }
            return flyout;
        }

        public static MenuFlyout ToMenuFlyout(this IContextMenu source)
        {
            MenuFlyout flyout = new MenuFlyout();
            return source.ToMenuFlyout(flyout);
        }

        public static Flyout ToPopup(this IContextMenu source)
        {
            var flyout = new Flyout();
           
            ItemsControl items = new ItemsControl();
            foreach(var item in source.Items)
            {
                Button button = new Button();
                button.Content = item.Header;
                button.Command = new RelayCommand<object>(
                    (param) => { flyout.Hide(); item.Command.Execute(param); },
                    (param) => item.Command.CanExecute(param));
                button.CommandParameter = item.CommandParameter;
                button.HorizontalAlignment = HorizontalAlignment.Stretch;
                items.Items.Add(button);
            }

            Border border = new Border();
            border.Padding = new Thickness(12);
            border.MinWidth = 480;
            border.HorizontalAlignment = HorizontalAlignment.Stretch;
            border.VerticalAlignment = VerticalAlignment.Bottom;
            border.Child = items;

            flyout.Content = border;
            return flyout;
        }
    }
}