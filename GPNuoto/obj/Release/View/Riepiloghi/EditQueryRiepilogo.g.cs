﻿#pragma checksum "..\..\..\..\View\Riepiloghi\EditQueryRiepilogo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6FA4A40587A5BB17DC34460A40C068DECA64B4DC52A5B46C8724BA5C938338F8"
//------------------------------------------------------------------------------
// <auto-generated>
//     Il codice è stato generato da uno strumento.
//     Versione runtime:4.0.30319.42000
//
//     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
//     il codice viene rigenerato.
// </auto-generated>
//------------------------------------------------------------------------------

using GPNuoto.Converters;
using MahApps.Metro.Controls;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
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


namespace GPNuoto {
    
    
    /// <summary>
    /// EditQueryRiepilogo
    /// </summary>
    public partial class EditQueryRiepilogo : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\..\View\Riepiloghi\EditQueryRiepilogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtQuery;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\View\Riepiloghi\EditQueryRiepilogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRipristina;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\View\Riepiloghi\EditQueryRiepilogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSaveQuery;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\View\Riepiloghi\EditQueryRiepilogo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAnnulla;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GPNuoto;component/view/riepiloghi/editqueryriepilogo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\Riepiloghi\EditQueryRiepilogo.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\View\Riepiloghi\EditQueryRiepilogo.xaml"
            ((GPNuoto.EditQueryRiepilogo)(target)).Loaded += new System.Windows.RoutedEventHandler(this.MetroWindow_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtQuery = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.btnRipristina = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\View\Riepiloghi\EditQueryRiepilogo.xaml"
            this.btnRipristina.Click += new System.Windows.RoutedEventHandler(this.btnRipristina_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnSaveQuery = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\View\Riepiloghi\EditQueryRiepilogo.xaml"
            this.btnSaveQuery.Click += new System.Windows.RoutedEventHandler(this.btnConferma_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnAnnulla = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\..\View\Riepiloghi\EditQueryRiepilogo.xaml"
            this.btnAnnulla.Click += new System.Windows.RoutedEventHandler(this.btnAnnulla_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

