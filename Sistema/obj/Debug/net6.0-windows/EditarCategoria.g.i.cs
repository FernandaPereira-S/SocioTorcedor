﻿#pragma checksum "..\..\..\EditarCategoria.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E5C266BDE4E5F339EB704356A8AA852777396D4D"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using Sistema_SocioTorcedor;
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


namespace Sistema_SocioTorcedor {
    
    
    /// <summary>
    /// EditarCategoria
    /// </summary>
    public partial class EditarCategoria : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 31 "..\..\..\EditarCategoria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DgdCategorias;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\EditarCategoria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtNome;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\EditarCategoria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtPreco;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\EditarCategoria.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxtBeneficios;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Sistema_SocioTorcedor;component/editarcategoria.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\EditarCategoria.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\EditarCategoria.xaml"
            ((Sistema_SocioTorcedor.EditarCategoria)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.EditarCategoriaIsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DgdCategorias = ((System.Windows.Controls.DataGrid)(target));
            
            #line 32 "..\..\..\EditarCategoria.xaml"
            this.DgdCategorias.SelectedCellsChanged += new System.Windows.Controls.SelectedCellsChangedEventHandler(this.DgdCategoriasSelectedCellsChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TxtNome = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TxtPreco = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.TxtBeneficios = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 80 "..\..\..\EditarCategoria.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AlterarClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 89 "..\..\..\EditarCategoria.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoverClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

