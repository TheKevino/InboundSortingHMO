﻿#pragma checksum "..\..\..\Arrivals.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42FF3EB6F5FB9AD85402C193014BD9EBD454D76E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using Pallets.Models;
using Prueba.UserControls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Prueba {
    
    
    /// <summary>
    /// Arrivals
    /// </summary>
    public partial class Arrivals : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 86 "..\..\..\Arrivals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border MainMenu;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\Arrivals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gridSearchCount;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\Arrivals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock hintTxtBuscar;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\Arrivals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBuscarBol;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\Arrivals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNumShipments;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Arrivals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbCountry;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\Arrivals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgInTransit;
        
        #line default
        #line hidden
        
        
        #line 227 "..\..\..\Arrivals.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblLoading;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Pallets;component/arrivals.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Arrivals.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\Arrivals.xaml"
            ((Prueba.Arrivals)(target)).Closed += new System.EventHandler(this.WindowClosed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainMenu = ((System.Windows.Controls.Border)(target));
            
            #line 86 "..\..\..\Arrivals.xaml"
            this.MainMenu.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.gridSearchCount = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.hintTxtBuscar = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.txtBuscarBol = ((System.Windows.Controls.TextBox)(target));
            
            #line 107 "..\..\..\Arrivals.xaml"
            this.txtBuscarBol.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.BusquedaShipment);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblNumShipments = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.cmbCountry = ((System.Windows.Controls.ComboBox)(target));
            
            #line 115 "..\..\..\Arrivals.xaml"
            this.cmbCountry.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbCountrySelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.dgInTransit = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 9:
            this.lblLoading = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

