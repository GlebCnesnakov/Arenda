﻿#pragma checksum "..\..\..\BuildingUserControl.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "537E8DC7239F09C14325CF7EA9322FB3CFFC6229"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Premises;
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


namespace Premises {
    
    
    /// <summary>
    /// BuildingUserControl
    /// </summary>
    public partial class BuildingUserControl : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 52 "..\..\..\BuildingUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGrid;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\BuildingUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextBox;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\BuildingUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButton;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\BuildingUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button writeButton;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\BuildingUserControl.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button editButton;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\..\BuildingUserControl.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Premises;component/buildingusercontrol.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\BuildingUserControl.xaml"
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
            
            #line 102 "..\..\..\BuildingUserControl.xaml"
            this.searchButton.Click += new System.Windows.RoutedEventHandler(this.ButtonClickSearch);
            
            #line default
            #line hidden
            return;
            case 4:
            this.writeButton = ((System.Windows.Controls.Button)(target));
            
            #line 149 "..\..\..\BuildingUserControl.xaml"
            this.writeButton.Click += new System.Windows.RoutedEventHandler(this.ButtonClickAdd);
            
            #line default
            #line hidden
            return;
            case 5:
            this.editButton = ((System.Windows.Controls.Button)(target));
            
            #line 191 "..\..\..\BuildingUserControl.xaml"
            this.editButton.Click += new System.Windows.RoutedEventHandler(this.ButtonClickEdit);
            
            #line default
            #line hidden
            return;
            case 6:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 234 "..\..\..\BuildingUserControl.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.ButtonClickDelete);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

