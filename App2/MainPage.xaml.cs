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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnDisplay_Tapped(object sender, TappedRoutedEventArgs e)
        {
            lblStatus.Text = txtExample2.Text;
        }
    }

    public sealed class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            this.DefaultStyleKey = typeof(TextBox);
        }

        public CaseType CharacterCasing
        {
            get { return (CaseType)GetValue(CharacterCasingProperty); }
            set { SetValue(CharacterCasingProperty, value); }
        }

        public static readonly DependencyProperty CharacterCasingProperty = DependencyProperty.Register("CharacterCasing", typeof(CaseType), typeof(MyTextBox), new PropertyMetadata(CaseType.Normal,(s,e)=>
        {
            TextBox myTextBox = (TextBox)s;
            if ((CaseType)e.NewValue !=(CaseType)e.OldValue)
            {
                myTextBox.TextChanged += MyTextBox_TextChanged;
            }
            else
            {
                myTextBox.TextChanged -= MyTextBox_TextChanged;
            }
        }));

        private static void MyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            MyTextBox myTextBox = sender as MyTextBox;
            switch(myTextBox.CharacterCasing)
            {
                case CaseType.UpperCase:
                    myTextBox.Text = myTextBox.Text.ToUpper();
                    break;
                case CaseType.LowerCase:
                    myTextBox.Text = myTextBox.Text.ToLower();
                    break;
                default:
                    break;
            }
            myTextBox.SelectionStart = myTextBox.Text.Length;
        }

        public enum CaseType
        {
            Normal,
            UpperCase,
            LowerCase
        }
    }
}
