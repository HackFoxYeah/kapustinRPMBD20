﻿#pragma checksum "..\..\RegionER.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E6833AEAF415E1679623C91BAD33FB0B4CDE558DB3D97BA149FA2820C25D2CCE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using KapustinRPMBDPR2;
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


namespace KapustinRPMBDPR2 {
    
    
    /// <summary>
    /// RegionER
    /// </summary>
    public partial class RegionER : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\RegionER.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RegionIdTB;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\RegionER.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RegionNameTB;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\RegionER.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddRecordBTN;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\RegionER.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CancelBTN;
        
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
            System.Uri resourceLocater = new System.Uri("/KapustinRPMBDPR2;component/regioner.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegionER.xaml"
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
            
            #line 9 "..\..\RegionER.xaml"
            ((KapustinRPMBDPR2.RegionER)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RegionIdTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.RegionNameTB = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AddRecordBTN = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\RegionER.xaml"
            this.AddRecordBTN.Click += new System.Windows.RoutedEventHandler(this.EditBTN_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.CancelBTN = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\RegionER.xaml"
            this.CancelBTN.Click += new System.Windows.RoutedEventHandler(this.CancelBTN_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
