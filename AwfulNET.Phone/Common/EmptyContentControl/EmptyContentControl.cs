using Microsoft.Phone.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AwfulNET.Common
{
    [TemplateVisualState(GroupName = "ViewStates", Name = "ShowContent")]
    [TemplateVisualState(GroupName = "ViewStates", Name = "ShowEmpty")]
    public class EmptyContentControl : ContentControl
    {
        public EmptyContentControl() : base()
        {
            this.DefaultStyleKey = typeof(EmptyContentControl);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (this.Content == null)
                VisualStateManager.GoToState(this, "ShowEmpty", true);
            else
                VisualStateManager.GoToState(this, "ShowContent", true);
        }

        public static readonly DependencyProperty EmptyContentTemplateProperty =
            DependencyProperty.Register(
            "EmptyContentTemplate",
            typeof(DataTemplate),
            typeof(EmptyContentControl),
            new PropertyMetadata(null));

        public DataTemplate EmptyContentTemplate
        {
            get { return this.GetValue(EmptyContentTemplateProperty) as DataTemplate; }
            set { this.SetValue(EmptyContentTemplateProperty, value); }
        }

        public static readonly DependencyProperty EmptyContentProperty =
            DependencyProperty.Register(
            "EmptyContent",
            typeof(object),
            typeof(EmptyContentControl),
            new PropertyMetadata("empty content"));

        public object EmptyContent
        {
            get { return this.GetValue(EmptyContentProperty); }
            set { this.SetValue(EmptyContentProperty, value); }
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);

            if (newContent == null)
                VisualStateManager.GoToState(this, "ShowEmpty", true);

            else
            {
                INotifyCollectionChanged oldCollection = oldContent as INotifyCollectionChanged;
                if (oldCollection != null)
                    oldCollection.CollectionChanged -= newCollection_CollectionChanged;

                ICollection newCollection = newContent as ICollection;
                
                if (newCollection != null)
                {
                    if (newCollection is INotifyCollectionChanged)
                        (newCollection as INotifyCollectionChanged).CollectionChanged += newCollection_CollectionChanged;

                    if (newCollection.Count == 0)
                        VisualStateManager.GoToState(this, "ShowEmpty", true);
                    else
                        VisualStateManager.GoToState(this, "ShowContent", true);
                }
            }
        }

        void newCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
                // delay a couple of milliseconds (observable collection property access is denied
                // when this callback is invoked), then notify view of content change
                Task.Delay(1).ContinueWith(task =>
                    {
                        this.OnContentChanged(this.Content, this.Content);
                    }, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
