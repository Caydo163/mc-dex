﻿#pragma checksum "..\..\..\PopUpListObject.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4380A2406DF766D2BE9384E26E9A58B594D2C602"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WPF_App;
using WPF_App.converter;


namespace WPF_App {
    
    
    /// <summary>
    /// PopUpListObject
    /// </summary>
    public partial class PopUpListObject : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\PopUpListObject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush backgroundPopUpList;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\PopUpListObject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ImageBrush backgroundMenuPopUpList;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\PopUpListObject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_RechercheItem;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\PopUpListObject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ButtonValider;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\PopUpListObject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TEST;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\PopUpListObject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxItem;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPF_App;component/popuplistobject.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PopUpListObject.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.backgroundPopUpList = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 2:
            this.backgroundMenuPopUpList = ((System.Windows.Media.ImageBrush)(target));
            return;
            case 3:
            this.textBox_RechercheItem = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\..\PopUpListObject.xaml"
            this.textBox_RechercheItem.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.RechercheItem);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ButtonValider = ((System.Windows.Controls.Border)(target));
            return;
            case 5:
            
            #line 52 "..\..\..\PopUpListObject.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonClose);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TEST = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.listBoxItem = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

