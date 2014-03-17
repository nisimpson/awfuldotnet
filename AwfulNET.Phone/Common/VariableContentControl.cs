using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AwfulNET.Common
{
    public class VariableContentControl : ContentControl
    {
        public VariableContentControl() : base()
        {
            DefaultStyleKey = typeof(ContentControl);
        }

        public static readonly DependencyProperty ContentTemplateSelectorProperty =
            DependencyProperty.Register(
            "ContentTemplateSelector",
            typeof(DataTemplateSelector),
            typeof(VariableContentControl),
            new PropertyMetadata(null, OnContentTemplateSelectorPropertyChanged));

        public static void OnContentTemplateSelectorPropertyChanged(DependencyObject d, 
            DependencyPropertyChangedEventArgs e)
        {
            VariableContentControl vcc = d as VariableContentControl;
            vcc.OnContentChanged(vcc.Content, vcc.Content);
        }

        public DataTemplateSelector ContentTemplateSelector
        {
            get { return GetValue(ContentTemplateSelectorProperty) as DataTemplateSelector; }
            set { SetValue(ContentTemplateSelectorProperty, value); }
        }

        protected override void OnContentChanged(object oldContent, object newContent)
        { 
            if (this.ContentTemplateSelector != null)
               this.ContentTemplate = ContentTemplateSelector.SelectTemplate(newContent, this);
            
            base.OnContentChanged(oldContent, newContent);
        }
    }

    public abstract class DataTemplateSelector : DependencyObject
    {
        public DataTemplate SelectTemplate(object content, DependencyObject container)
        {
            return SelectTemplateCore(content, container);
        }

        protected abstract DataTemplate SelectTemplateCore(object content, DependencyObject container);
    }

    public sealed class DefaultTemplateSelector : DataTemplateSelector
    {
        private DataTemplate defaultTemplate;
        public DefaultTemplateSelector(DataTemplate defaultTemplate) { this.defaultTemplate = defaultTemplate; }

        protected override DataTemplate SelectTemplateCore(object content, DependencyObject container)
        {
            return defaultTemplate;
        }
    }
}
