﻿#pragma checksum "..\..\..\User_control\ControlBarUC.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8679FDC96F4F342D7AAE2F1383AAD79E2348B34099B38FED3CAF3857091433B6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Microsoft.Xaml.Behaviors;
using Microsoft.Xaml.Behaviors.Core;
using Microsoft.Xaml.Behaviors.Input;
using Microsoft.Xaml.Behaviors.Layout;
using Microsoft.Xaml.Behaviors.Media;
using QLBVMB.User_control;
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


namespace QLBVMB.User_control {
    
    
    /// <summary>
    /// ControlBarUC
    /// </summary>
    public partial class ControlBarUC : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\User_control\ControlBarUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal QLBVMB.User_control.ControlBarUC ucControlBar;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\User_control\ControlBarUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid gMain;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\User_control\ControlBarUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btControlBarMin;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\User_control\ControlBarUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btControlBarMax;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\User_control\ControlBarUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btControlBarRestoreDown;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\..\User_control\ControlBarUC.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btControlBarClose;
        
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
            System.Uri resourceLocater = new System.Uri("/QLBVMB;component/user_control/controlbaruc.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\User_control\ControlBarUC.xaml"
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
            this.ucControlBar = ((QLBVMB.User_control.ControlBarUC)(target));
            return;
            case 2:
            this.gMain = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.btControlBarMin = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.btControlBarMax = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\User_control\ControlBarUC.xaml"
            this.btControlBarMax.Click += new System.Windows.RoutedEventHandler(this.btControlBarMax_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btControlBarRestoreDown = ((System.Windows.Controls.Button)(target));
            
            #line 87 "..\..\..\User_control\ControlBarUC.xaml"
            this.btControlBarRestoreDown.Click += new System.Windows.RoutedEventHandler(this.btControlBarMax_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btControlBarClose = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

