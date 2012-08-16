﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Library.Net.Amoeba;
using Amoeba.Properties;
using System.IO;
using Library.Net;
using Library.Security;
using Library;

namespace Amoeba.Windows
{
    /// <summary>
    /// BoxEditWindow.xaml の相互作用ロジック
    /// </summary>
    partial class BoxEditWindow : Window
    {
        private Box _box;

        public BoxEditWindow(ref Box box)
        {
            _box = box;

            var digitalSignatureCollection = new List<object>();
            digitalSignatureCollection.Add(new ComboBoxItem() { Content = "" });
            digitalSignatureCollection.AddRange(Settings.Instance.Global_DigitalSignatureCollection.Select(n => new DigitalSignatureComboBoxItem(n)).ToArray());

            InitializeComponent();

            using (FileStream stream = new FileStream(System.IO.Path.Combine(App.DirectoryPaths["Icons"], "Amoeba.ico"), FileMode.Open))
            {
                this.Icon = BitmapFrame.Create(stream);
            }

            lock (_box.ThisLock)
            {
                _nameTextBox.Text = _box.Name;
                _commentTextBox.Text = _box.Comment;
            }

            _signatureComboBox.ItemsSource = digitalSignatureCollection;
            
            var index = Settings.Instance.Global_DigitalSignatureCollection.IndexOf(Settings.Instance.Global_UploadDigitalSignature);
            _signatureComboBox.SelectedIndex = index + 1;
        }

        private void _okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

            string name = _nameTextBox.Text;
            string comment = _commentTextBox.Text;
            var digitalSignatureComboBoxItem = _signatureComboBox.SelectedItem as DigitalSignatureComboBoxItem;
            DigitalSignature digitalSignature = digitalSignatureComboBoxItem == null ? null : digitalSignatureComboBoxItem.Value;

            Settings.Instance.Global_UploadDigitalSignature = digitalSignature;
            
            lock (_box.ThisLock)
            {
                _box.Name = name;
                _box.Comment = comment;
                _box.CreationTime = DateTime.UtcNow;

                if (digitalSignature == null)
                {
                    _box.CreateCertificate(null);
                }
                else
                {
                    _box.CreateCertificate(digitalSignature);
                }
            }
        }

        private void _cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
