﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Avalonia.Markup.Xaml.Styling;
using System;
using System.Diagnostics;
using System.Linq;

namespace Avalonia.Themes.Aero.NormalColor.Sample.Views
{
    public class ScrollViewerPageView : UserControl
    {
        public ScrollViewerPageView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}