﻿#pragma checksum "..\..\..\RentPurposeUserControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0DABA920F47F4F015E9DC80EB13892C14C57AE62"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Lists;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Lists {
    
    
    /// <summary>
    /// RentPurposeUserControl
    /// </summary>
    public partial class RentPurposeUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 51 "..\..\..\RentPurposeUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\RentPurposeUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextBox;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\RentPurposeUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButton;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\..\RentPurposeUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox inputTextBox;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\..\RentPurposeUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button writeButton;
        
        #line default
        #line hidden
        
        
        #line 178 "..\..\..\RentPurposeUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editButton;
        
        #line default
        #line hidden
        
        
        #line 221 "..\..\..\RentPurposeUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Lists;component/rentpurposeusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\RentPurposeUserControl.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dataGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.searchTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.searchButton = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\..\RentPurposeUserControl.xaml"
            this.searchButton.Click += new System.Windows.RoutedEventHandler(this.ButtonClickSearch);
            
            #line default
            #line hidden
            return;
            case 4:
            this.inputTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.writeButton = ((System.Windows.Controls.Button)(target));
            
            #line 145 "..\..\..\RentPurposeUserControl.xaml"
            this.writeButton.Click += new System.Windows.RoutedEventHandler(this.ButtonClickAdd);
            
            #line default
            #line hidden
            return;
            case 6:
            this.editButton = ((System.Windows.Controls.Button)(target));
            
            #line 187 "..\..\..\RentPurposeUserControl.xaml"
            this.editButton.Click += new System.Windows.RoutedEventHandler(this.ButtonClickEdit);
            
            #line default
            #line hidden
            return;
            case 7:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 230 "..\..\..\RentPurposeUserControl.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.ButtonClickDelete);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

