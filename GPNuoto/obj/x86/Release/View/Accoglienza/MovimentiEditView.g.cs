﻿#pragma checksum "..\..\..\..\..\View\Accoglienza\MovimentiEditView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "397E9A09C18F82F4872DD7D54D3AD6BB978DBC555DF6DEBBC98BEEBB188B9F9A"
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
using GPNuoto.Report;
using GPNuoto.ViewModel;
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
    /// MovimentiEditView
    /// </summary>
    public partial class MovimentiEditView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\..\..\..\View\Accoglienza\MovimentiEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Descrizione;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\View\Accoglienza\MovimentiEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TotalePagamentoTextbox;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\..\View\Accoglienza\MovimentiEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ScontoTextbox;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\..\..\..\View\Accoglienza\MovimentiEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TotaleRicevutaTextbox;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\..\..\View\Accoglienza\MovimentiEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDettagli;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\..\..\View\Accoglienza\MovimentiEditView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConferma;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\..\..\View\Accoglienza\MovimentiEditView.xaml"
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
            System.Uri resourceLocater = new System.Uri("/GPNuoto;component/view/accoglienza/movimentieditview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\Accoglienza\MovimentiEditView.xaml"
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
            this.Descrizione = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TotalePagamentoTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ScontoTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TotaleRicevutaTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnDettagli = ((System.Windows.Controls.Button)(target));
            
            #line 97 "..\..\..\..\..\View\Accoglienza\MovimentiEditView.xaml"
            this.btnDettagli.Click += new System.Windows.RoutedEventHandler(this.btnDettagli_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnConferma = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\..\..\..\View\Accoglienza\MovimentiEditView.xaml"
            this.btnConferma.Click += new System.Windows.RoutedEventHandler(this.btnConfermaPagamento_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnAnnulla = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\..\..\..\View\Accoglienza\MovimentiEditView.xaml"
            this.btnAnnulla.Click += new System.Windows.RoutedEventHandler(this.btnAnnulla_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

