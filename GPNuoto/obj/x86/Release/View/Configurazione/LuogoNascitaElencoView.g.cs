﻿#pragma checksum "..\..\..\..\..\View\Configurazione\LuogoNascitaElencoView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B93ED94DD00534CABE7FECA91EF4B58328DB017195B567BC6B164A7B1D4969E9"
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
using GPNuoto.Model;
using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using Microsoft.Windows.Themes;
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
    /// LuogoNascitaElencoView
    /// </summary>
    public partial class LuogoNascitaElencoView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\..\View\Configurazione\LuogoNascitaElencoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border LuoghiNascitaElenco;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\View\Configurazione\LuogoNascitaElencoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid TabellaCodici;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\..\View\Configurazione\LuogoNascitaElencoView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddPagamento;
        
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
            System.Uri resourceLocater = new System.Uri("/GPNuoto;component/view/configurazione/luogonascitaelencoview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Configurazione\LuogoNascitaElencoView.xaml"
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
            this.LuoghiNascitaElenco = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.TabellaCodici = ((System.Windows.Controls.DataGrid)(target));
            
            #line 35 "..\..\..\..\..\View\Configurazione\LuogoNascitaElencoView.xaml"
            this.TabellaCodici.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.TabellaCodici_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnAddPagamento = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
