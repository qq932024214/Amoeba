﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Windows;
using Amoeba.Service;
using Omnius;
using Omnius.Collections;
using Omnius.Security;

namespace Amoeba.Interface
{
    [DataContract(Name = nameof(CrowdStateInfo))]
    partial class CrowdStateInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public CrowdStateInfo() { }

        private string _location;

        [DataMember(Name = nameof(Location))]
        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                if (_location != value)
                {
                    _location = value;
                    this.OnPropertyChanged(nameof(Location));
                }
            }
        }
    }
    [DataContract(Name = nameof(ServiceOptionsInfo))]
    partial class ServiceOptionsInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ServiceOptionsInfo() { }

        private ServiceTcpOptionsInfo _tcp;

        [DataMember(Name = nameof(Tcp))]
        public ServiceTcpOptionsInfo Tcp
        {
            get
            {
                if (_tcp == null)
                    _tcp = new ServiceTcpOptionsInfo();

                return _tcp;
            }
        }

        private ServiceAccountOptionsInfo _account;

        [DataMember(Name = nameof(Account))]
        public ServiceAccountOptionsInfo Account
        {
            get
            {
                if (_account == null)
                    _account = new ServiceAccountOptionsInfo();

                return _account;
            }
        }
    }
    [DataContract(Name = nameof(ServiceTcpOptionsInfo))]
    partial class ServiceTcpOptionsInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ServiceTcpOptionsInfo() { }

        private string _proxyUri;

        [DataMember(Name = nameof(ProxyUri))]
        public string ProxyUri
        {
            get
            {
                return _proxyUri;
            }
            set
            {
                if (_proxyUri != value)
                {
                    _proxyUri = value;
                    this.OnPropertyChanged(nameof(ProxyUri));
                }
            }
        }

        private bool _ipv4IsEnabled;

        [DataMember(Name = nameof(Ipv4IsEnabled))]
        public bool Ipv4IsEnabled
        {
            get
            {
                return _ipv4IsEnabled;
            }
            set
            {
                if (_ipv4IsEnabled != value)
                {
                    _ipv4IsEnabled = value;
                    this.OnPropertyChanged(nameof(Ipv4IsEnabled));
                }
            }
        }

        private ushort _ipv4Port;

        [DataMember(Name = nameof(Ipv4Port))]
        public ushort Ipv4Port
        {
            get
            {
                return _ipv4Port;
            }
            set
            {
                if (_ipv4Port != value)
                {
                    _ipv4Port = value;
                    this.OnPropertyChanged(nameof(Ipv4Port));
                }
            }
        }

        private bool _ipv6IsEnabled;

        [DataMember(Name = nameof(Ipv6IsEnabled))]
        public bool Ipv6IsEnabled
        {
            get
            {
                return _ipv6IsEnabled;
            }
            set
            {
                if (_ipv6IsEnabled != value)
                {
                    _ipv6IsEnabled = value;
                    this.OnPropertyChanged(nameof(Ipv6IsEnabled));
                }
            }
        }

        private ushort _ipv6Port;

        [DataMember(Name = nameof(Ipv6Port))]
        public ushort Ipv6Port
        {
            get
            {
                return _ipv6Port;
            }
            set
            {
                if (_ipv6Port != value)
                {
                    _ipv6Port = value;
                    this.OnPropertyChanged(nameof(Ipv6Port));
                }
            }
        }
    }
    [DataContract(Name = nameof(ServiceAccountOptionsInfo))]
    partial class ServiceAccountOptionsInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ServiceAccountOptionsInfo() { }

        private DigitalSignature _digitalSignature;

        [DataMember(Name = nameof(DigitalSignature))]
        public DigitalSignature DigitalSignature
        {
            get
            {
                return _digitalSignature;
            }
            set
            {
                if (_digitalSignature != value)
                {
                    _digitalSignature = value;
                    this.OnPropertyChanged(nameof(DigitalSignature));
                }
            }
        }
    }
    [DataContract(Name = nameof(ChatCategoryInfo))]
    partial class ChatCategoryInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ChatCategoryInfo() { }

        private string _name;

        [DataMember(Name = nameof(Name))]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    this.OnPropertyChanged(nameof(Name));
                }
            }
        }

        private bool _isExpanded;

        [DataMember(Name = nameof(IsExpanded))]
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged(nameof(IsExpanded));
                }
            }
        }

        private ObservableCollection<ChatInfo> _chatInfos;

        [DataMember(Name = nameof(ChatInfos))]
        public ObservableCollection<ChatInfo> ChatInfos
        {
            get
            {
                if (_chatInfos == null)
                    _chatInfos = new ObservableCollection<ChatInfo>();

                return _chatInfos;
            }
        }

        private ObservableCollection<ChatCategoryInfo> _categoryInfos;

        [DataMember(Name = nameof(CategoryInfos))]
        public ObservableCollection<ChatCategoryInfo> CategoryInfos
        {
            get
            {
                if (_categoryInfos == null)
                    _categoryInfos = new ObservableCollection<ChatCategoryInfo>();

                return _categoryInfos;
            }
        }
    }
    [DataContract(Name = nameof(ChatInfo))]
    partial class ChatInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ChatInfo() { }

        private Tag _tag;

        [DataMember(Name = nameof(Tag))]
        public Tag Tag
        {
            get
            {
                return _tag;
            }
            set
            {
                if (_tag != value)
                {
                    _tag = value;
                    this.OnPropertyChanged(nameof(Tag));
                }
            }
        }

        private LockedList<ChatMessageInfo> _messages;

        [DataMember(Name = nameof(Messages))]
        public LockedList<ChatMessageInfo> Messages
        {
            get
            {
                if (_messages == null)
                    _messages = new LockedList<ChatMessageInfo>();

                return _messages;
            }
        }
    }
    [DataContract(Name = nameof(ChatMessageInfo))]
    partial class ChatMessageInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ChatMessageInfo() { }

        private ChatMessageState _state;

        [DataMember(Name = nameof(State))]
        public ChatMessageState State
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    this.OnPropertyChanged(nameof(State));
                }
            }
        }

        private MulticastMessage<ChatMessage> _message;

        [DataMember(Name = nameof(Message))]
        public MulticastMessage<ChatMessage> Message
        {
            get
            {
                return _message;
            }
            set
            {
                if (_message != value)
                {
                    _message = value;
                    this.OnPropertyChanged(nameof(Message));
                }
            }
        }
    }
    [DataContract(Name = nameof(UploadStoreCategoryInfo))]
    partial class UploadStoreCategoryInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public UploadStoreCategoryInfo() { }

        private string _name;

        [DataMember(Name = nameof(Name))]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    this.OnPropertyChanged(nameof(Name));
                }
            }
        }

        private bool _isExpanded;

        [DataMember(Name = nameof(IsExpanded))]
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged(nameof(IsExpanded));
                }
            }
        }

        private ObservableCollection<UploadStoreInfo> _storeInfos;

        [DataMember(Name = nameof(StoreInfos))]
        public ObservableCollection<UploadStoreInfo> StoreInfos
        {
            get
            {
                if (_storeInfos == null)
                    _storeInfos = new ObservableCollection<UploadStoreInfo>();

                return _storeInfos;
            }
        }

        private ObservableCollection<UploadStoreCategoryInfo> _categoryInfos;

        [DataMember(Name = nameof(CategoryInfos))]
        public ObservableCollection<UploadStoreCategoryInfo> CategoryInfos
        {
            get
            {
                if (_categoryInfos == null)
                    _categoryInfos = new ObservableCollection<UploadStoreCategoryInfo>();

                return _categoryInfos;
            }
        }
    }
    [DataContract(Name = nameof(UploadStoreInfo))]
    partial class UploadStoreInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public UploadStoreInfo() { }

        private string _path;

        [DataMember(Name = nameof(Path))]
        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                if (_path != value)
                {
                    _path = value;
                    this.OnPropertyChanged(nameof(Path));
                }
            }
        }

        private string _name;

        [DataMember(Name = nameof(Name))]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    this.OnPropertyChanged(nameof(Name));
                }
            }
        }

        private bool _isExpanded;

        [DataMember(Name = nameof(IsExpanded))]
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged(nameof(IsExpanded));
                }
            }
        }

        private bool _isUpdated;

        [DataMember(Name = nameof(IsUpdated))]
        public bool IsUpdated
        {
            get
            {
                return _isUpdated;
            }
            set
            {
                if (_isUpdated != value)
                {
                    _isUpdated = value;
                    this.OnPropertyChanged(nameof(IsUpdated));
                }
            }
        }

        private ObservableCollection<SeedInfo> _seedInfos;

        [DataMember(Name = nameof(SeedInfos))]
        public ObservableCollection<SeedInfo> SeedInfos
        {
            get
            {
                if (_seedInfos == null)
                    _seedInfos = new ObservableCollection<SeedInfo>();

                return _seedInfos;
            }
        }

        private ObservableCollection<BoxInfo> _boxInfos;

        [DataMember(Name = nameof(BoxInfos))]
        public ObservableCollection<BoxInfo> BoxInfos
        {
            get
            {
                if (_boxInfos == null)
                    _boxInfos = new ObservableCollection<BoxInfo>();

                return _boxInfos;
            }
        }
    }
    [DataContract(Name = nameof(DownloadStoreCategoryInfo))]
    partial class DownloadStoreCategoryInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public DownloadStoreCategoryInfo() { }

        private string _name;

        [DataMember(Name = nameof(Name))]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    this.OnPropertyChanged(nameof(Name));
                }
            }
        }

        private bool _isExpanded;

        [DataMember(Name = nameof(IsExpanded))]
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged(nameof(IsExpanded));
                }
            }
        }

        private ObservableCollection<DownloadStoreInfo> _storeInfos;

        [DataMember(Name = nameof(StoreInfos))]
        public ObservableCollection<DownloadStoreInfo> StoreInfos
        {
            get
            {
                if (_storeInfos == null)
                    _storeInfos = new ObservableCollection<DownloadStoreInfo>();

                return _storeInfos;
            }
        }

        private ObservableCollection<DownloadStoreCategoryInfo> _categoryInfos;

        [DataMember(Name = nameof(CategoryInfos))]
        public ObservableCollection<DownloadStoreCategoryInfo> CategoryInfos
        {
            get
            {
                if (_categoryInfos == null)
                    _categoryInfos = new ObservableCollection<DownloadStoreCategoryInfo>();

                return _categoryInfos;
            }
        }
    }
    [DataContract(Name = nameof(DownloadStoreInfo))]
    partial class DownloadStoreInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public DownloadStoreInfo() { }

        private Signature _signature;

        [DataMember(Name = nameof(Signature))]
        public Signature Signature
        {
            get
            {
                return _signature;
            }
            set
            {
                if (_signature != value)
                {
                    _signature = value;
                    this.OnPropertyChanged(nameof(Signature));
                }
            }
        }

        private string _name;

        [DataMember(Name = nameof(Name))]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    this.OnPropertyChanged(nameof(Name));
                }
            }
        }

        private bool _isExpanded;

        [DataMember(Name = nameof(IsExpanded))]
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged(nameof(IsExpanded));
                }
            }
        }

        private bool _isUpdated;

        [DataMember(Name = nameof(IsUpdated))]
        public bool IsUpdated
        {
            get
            {
                return _isUpdated;
            }
            set
            {
                if (_isUpdated != value)
                {
                    _isUpdated = value;
                    this.OnPropertyChanged(nameof(IsUpdated));
                }
            }
        }

        private ObservableCollection<SeedInfo> _seedInfos;

        [DataMember(Name = nameof(SeedInfos))]
        public ObservableCollection<SeedInfo> SeedInfos
        {
            get
            {
                if (_seedInfos == null)
                    _seedInfos = new ObservableCollection<SeedInfo>();

                return _seedInfos;
            }
        }

        private ObservableCollection<BoxInfo> _boxInfos;

        [DataMember(Name = nameof(BoxInfos))]
        public ObservableCollection<BoxInfo> BoxInfos
        {
            get
            {
                if (_boxInfos == null)
                    _boxInfos = new ObservableCollection<BoxInfo>();

                return _boxInfos;
            }
        }
    }
    [DataContract(Name = nameof(BoxInfo))]
    partial class BoxInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public BoxInfo() { }

        private string _name;

        [DataMember(Name = nameof(Name))]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    this.OnPropertyChanged(nameof(Name));
                }
            }
        }

        private bool _isExpanded;

        [DataMember(Name = nameof(IsExpanded))]
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged(nameof(IsExpanded));
                }
            }
        }

        private ObservableCollection<SeedInfo> _seedInfos;

        [DataMember(Name = nameof(SeedInfos))]
        public ObservableCollection<SeedInfo> SeedInfos
        {
            get
            {
                if (_seedInfos == null)
                    _seedInfos = new ObservableCollection<SeedInfo>();

                return _seedInfos;
            }
        }

        private ObservableCollection<BoxInfo> _boxInfos;

        [DataMember(Name = nameof(BoxInfos))]
        public ObservableCollection<BoxInfo> BoxInfos
        {
            get
            {
                if (_boxInfos == null)
                    _boxInfos = new ObservableCollection<BoxInfo>();

                return _boxInfos;
            }
        }
    }
    [DataContract(Name = nameof(SeedInfo))]
    partial class SeedInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public SeedInfo() { }

        private string _name;

        [DataMember(Name = nameof(Name))]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    this.OnPropertyChanged(nameof(Name));
                }
            }
        }

        private long _length;

        [DataMember(Name = nameof(Length))]
        public long Length
        {
            get
            {
                return _length;
            }
            set
            {
                if (_length != value)
                {
                    _length = value;
                    this.OnPropertyChanged(nameof(Length));
                }
            }
        }

        private DateTime _creationTime;

        [DataMember(Name = nameof(CreationTime))]
        public DateTime CreationTime
        {
            get
            {
                return _creationTime;
            }
            set
            {
                if (_creationTime != value)
                {
                    _creationTime = value;
                    this.OnPropertyChanged(nameof(CreationTime));
                }
            }
        }

        private Metadata _metadata;

        [DataMember(Name = nameof(Metadata))]
        public Metadata Metadata
        {
            get
            {
                return _metadata;
            }
            set
            {
                if (_metadata != value)
                {
                    _metadata = value;
                    this.OnPropertyChanged(nameof(Metadata));
                }
            }
        }
    }
}
