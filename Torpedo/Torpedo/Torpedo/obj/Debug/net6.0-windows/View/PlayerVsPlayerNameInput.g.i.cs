﻿#pragma checksum "..\..\..\..\View\PlayerVsPlayerNameInput.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1E4F900930561FC6163AE4F7F186BFA41B7F5BC4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
using Torpedo.View;


namespace Torpedo.View {
    
    
    /// <summary>
    /// PlayerVsPlayerNameInput
    /// </summary>
    public partial class PlayerVsPlayerNameInput : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 186 "..\..\..\..\View\PlayerVsPlayerNameInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GameNamePvsPInput;
        
        #line default
        #line hidden
        
        
        #line 207 "..\..\..\..\View\PlayerVsPlayerNameInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitButton;
        
        #line default
        #line hidden
        
        
        #line 225 "..\..\..\..\View\PlayerVsPlayerNameInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock HowGameWorks;
        
        #line default
        #line hidden
        
        
        #line 236 "..\..\..\..\View\PlayerVsPlayerNameInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstPlayerNameTextBox;
        
        #line default
        #line hidden
        
        
        #line 249 "..\..\..\..\View\PlayerVsPlayerNameInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock FirstPlayerNameTextBlock;
        
        #line default
        #line hidden
        
        
        #line 263 "..\..\..\..\View\PlayerVsPlayerNameInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GameStart;
        
        #line default
        #line hidden
        
        
        #line 283 "..\..\..\..\View\PlayerVsPlayerNameInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackButtonPvPInput;
        
        #line default
        #line hidden
        
        
        #line 301 "..\..\..\..\View\PlayerVsPlayerNameInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock SecondPlayerNameTextBlock;
        
        #line default
        #line hidden
        
        
        #line 315 "..\..\..\..\View\PlayerVsPlayerNameInput.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SecondPlayerNameTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Torpedo;component/view/playervsplayernameinput.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\PlayerVsPlayerNameInput.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.GameNamePvsPInput = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.ExitButton = ((System.Windows.Controls.Button)(target));
            
            #line 222 "..\..\..\..\View\PlayerVsPlayerNameInput.xaml"
            this.ExitButton.Click += new System.Windows.RoutedEventHandler(this.ExitButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.HowGameWorks = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.FirstPlayerNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.FirstPlayerNameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.GameStart = ((System.Windows.Controls.Button)(target));
            
            #line 278 "..\..\..\..\View\PlayerVsPlayerNameInput.xaml"
            this.GameStart.Click += new System.Windows.RoutedEventHandler(this.GameStart_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BackButtonPvPInput = ((System.Windows.Controls.Button)(target));
            
            #line 297 "..\..\..\..\View\PlayerVsPlayerNameInput.xaml"
            this.BackButtonPvPInput.Click += new System.Windows.RoutedEventHandler(this.BackButtonPvAInput_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.SecondPlayerNameTextBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.SecondPlayerNameTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

