using AwfulNET.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

#if !WINDOWS_PHONE
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.ObjectModel;
#else
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using System.Collections.ObjectModel;
#endif

namespace AwfulNET.DataModel
{
    public interface ICommonDataModel
    {
        string UniqueID { get; }
        string Title { get; }
        string Subtitle { get; }
        string Description { get; }
        object Content { get; }
        string DataType { get; }
        ImageSource Image { get; }
        ICommonDataGroup Group { get; }
    }

    public interface ICommonDataGroup : ICommonDataModel
    {
        IList<ICommonDataModel> Items { get; }
    }

    public interface ICommonDataRoot : ICommonDataGroup
    {
        IEnumerable<IList<ICommonDataModel>> Groups { get; }
    }

    public interface IPinnableDataModel
    {
        bool IsPinned { get; set; }
    }

    [DataContract]
    public class CommonDataModel : BindableBase, ICommonDataModel
    {
#if WINDOWS_PHONE
        private const string IMG_PREFIX = "/Assets/";
#else
        private const string IMG_PREFIX = "ms-appx:///";
#endif

        public CommonDataModel()
        {
            if (this.IsInDesignMode())
            {
                InitializeForDesignTool();
            }
        }

        public CommonDataModel(
            string uniqueID,
            string title,
            string subtitle,
            string description,
            string imagePath,
            object content,
            ICommonDataGroup group) : base()
        {
            this.uniqueID = uniqueID;
            this.title = title;
            this.subtitle = subtitle;
            this.description = description;
            this.imagePath = imagePath;
            this.content = content;
            this.group = group;
        }

        protected virtual void InitializeForDesignTool()
        {
            this.uniqueID = Guid.NewGuid().ToString();
            this.title = "Assumenda eiusmod esse pork belly, reprehenderit sriracha id do chia Cosby sweater Wes Anderson";
            this.subtitle = "Four loko meggings sriracha tempor, Helvetica tofu Portland hoodie velit wolf non id eiusmod banh mi aesthetic.";

            this.description = "Pour-over seitan laboris, salvia fugiat fashion axe synth High Life mustache craft beer PBR Godard. Tumblr kogi " +
                "kale chips hashtag Helvetica, chambray American Apparel aliqua.";
            
            this.content = "Tempor XOXO Cosby sweater voluptate locavore literally, gastropub iPhone sapiente anim et you probably haven't heard " +
                "of them placeat. Flannel Shoreditch McSweeney's asymmetrical Banksy, Thundercats food truck semiotics kitsch farm-to-table polaroid. " +
                "Assumenda eiusmod esse pork belly, reprehenderit sriracha id do chia Cosby sweater Wes Anderson. Distillery selfies esse, Vice enim Schlitz " +
                "Austin scenester Pinterest selvage ex Bushwick placeat. Tofu eu keytar sunt banjo locavore organic PBR&B Tumblr, enim leggings XOXO. Do selfies" +
                "deep v umami put a bird on it hella velit, artisan flannel bitters fashion axe. Cred culpa velit hoodie occaecat, trust fund retro banh mi narwhal " +
                "mumblecore dreamcatcher consequat excepteur four loko. Sriracha pariatur street art deep v you probably haven't heard of them Wes Anderson. Chia " +
                "slow-carb street art cupidatat eiusmod. Dreamcatcher sed Marfa, Tonx eu food truck swag gluten-free. Nisi wolf McSweeney's mollit, dolor " +
                "sustainable irure cupidatat literally dolore elit pour-over slow-carb sapiente excepteur. Gluten-free Portland squid reprehenderit. Etsy tempor" +
                "delectus Carles, voluptate non enim. Occaecat DIY readymade odio, VHS 90's gastropub PBR&B banh mi lo-fi magna farm-to-table twee.";

            this.imagePath = "ApplicationIcon.png";
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(this.title) ? base.ToString() : this.title;
        }

        private string uniqueID = string.Empty;
        [DataMember]
        public string UniqueID
        {
            get { return this.uniqueID; }
            set { this.SetProperty(ref this.uniqueID, value); }
        }

        private string title = string.Empty;
        [DataMember]
        public string Title
        {
            get { return this.title.Trim(); }
            set { this.SetProperty(ref this.title, value); }
        }

        private string subtitle = string.Empty;
        [DataMember]
        public string Subtitle
        {
            get 
            {
                string value = this.subtitle == null ? 
                    string.Empty : 
                    this.subtitle;
                return value.Trim(); 
            }
            set { this.SetProperty(ref this.subtitle, value); }
        }

        private string description = string.Empty;
        [DataMember]
        public string Description
        {
            get { return this.description.Trim(); }
            set { this.SetProperty(ref this.description, value); }
        }

        private string dataType = string.Empty;
        public string DataType
        {
            get { return this.dataType; }
            set { this.SetProperty(ref this.dataType, value); }
        }

        private object content = string.Empty;
        [DataMember]
        public object Content
        {
            get { return this.content; }
            set { this.SetProperty(ref this.content, value); }
        }

        private String imagePath = null;
        [DataMember]
        public string ImagePath
        {
            get { return imagePath; }
            set { SetImage(value); }
        }

        private ImageSource _image = null;
        [IgnoreDataMember]
        public ImageSource Image
        {
            get
            {
                if (this._image == null && !string.IsNullOrEmpty(this.imagePath))
                {
                    // is the uri local or remote?
                    if (!this.imagePath.Contains("http"))
                        this._image = new BitmapImage(new Uri(CommonDataModel.IMG_PREFIX + this.imagePath, UriKind.RelativeOrAbsolute));
                    else
                        this._image = new BitmapImage(new Uri(this.imagePath, UriKind.Absolute));
                }
                return this._image;
            }

            set
            {
                this.imagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }

        public void SetImage(String path)
        {
            this._image = null;
            if (this.imagePath != path)
            {
                this.imagePath = path;
                this.OnPropertyChanged("Image");
            }
        }

        private ICommonDataGroup group = null;
        [IgnoreDataMember]
        public ICommonDataGroup Group
        {
            get { return this.group; }
            set { this.SetProperty(ref this.group, value); }
        }
    }

    [DataContract]
    public class CommonDataGroup : CommonDataModel, ICommonDataGroup
    {
        public CommonDataGroup() : base() { }

        public CommonDataGroup(string uniqueID,
            string title,
            string subtitle,
            string description,
            string imagePath,
            object content,
            ICommonDataGroup group)
            : base(uniqueID, title, subtitle, description, imagePath, content, group) { }

        protected override void InitializeForDesignTool()
        {
            base.InitializeForDesignTool();

            for (int i = 0; i < 10; i++)
                items.Add(new CommonDataModel() { Group = this });
        }

        private IList<ICommonDataModel> items = new ObservableCollection<ICommonDataModel>();
        [DataMember]
        public IList<ICommonDataModel> Items
        {
            get { return this.items; }
            set { this.SetProperty(ref this.items, value); }
        }
    }

    public sealed class SampleDataGroup : CommonDataGroup, ICommonDataRoot
    {
        public SampleDataGroup() : base()
        {
            this.Title = "Sample Data Group";

            var groups = new CommonDataGroup[] {
                new CommonDataGroup() { Title = "Group 1" },
                new CommonDataGroup() { Title = "Group 2" },
                new CommonDataGroup() { Title = "Group 3" },
                new CommonDataGroup() { Title = "Group 4" }
            };

            var groupItems = groups.SelectMany(group => group.Items);
            foreach (var item in groupItems)
                Items.Add(item);
        }

        protected override void InitializeForDesignTool() { }

        public IEnumerable<ICommonDataModel> ItemsSource
        {
            get { return this.Items; }
        }

        public IEnumerable<IList<ICommonDataModel>> Groups
        {
            get 
            {
                return JumpListDataModel<ICommonDataModel>.CreateGroups(
                    this.Items,
                    item => item.Group.ToString(),
                    (one, two) => { return one.Title.CompareTo(two.Title); });
            }
        }
    }
}
