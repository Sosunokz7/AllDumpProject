﻿#pragma checksum "..\..\..\..\Pagings\Auk.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "027EB8D57D44309686D6D8B3D7BA042A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.1026
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjcForAukt.Pagings;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace ProjcForAukt.Pagings {
    
    
    /// <summary>
    /// Auk
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class Auk : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\Pagings\Auk.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bac;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Pagings\Auk.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NameLota;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Pagings\Auk.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PhotLota;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\..\Pagings\Auk.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BuyLot;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Pagings\Auk.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Test;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjcForAukt;component/pagings/auk.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pagings\Auk.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Bac = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\..\Pagings\Auk.xaml"
            this.Bac.Click += new System.Windows.RoutedEventHandler(this.Bac_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NameLota = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.PhotLota = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.BuyLot = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.Test = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\..\Pagings\Auk.xaml"
            this.Test.Click += new System.Windows.RoutedEventHandler(this.Test_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

