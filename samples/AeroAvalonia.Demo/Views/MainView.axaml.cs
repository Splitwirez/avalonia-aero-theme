using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using AeroAvalonia.Demo.ViewModels;

namespace AeroAvalonia.Demo.Views
{
    public partial class MainView
        : UserControl
    {
        public TabsViewModelBase VM
        {
            get => DataContext as TabsViewModelBase;
        }


        public MainView()
        {
            InitializeComponent();
        }

        void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            Dispatcher.UIThread.Post(() => {
                var topLevel = TopLevel.GetTopLevel(this);
                topLevel.AddHandler(
                    KeyDownEvent
                    , This_KeyDown
                    , handledEventsToo: true
                );
            }, DispatcherPriority.ApplicationIdle);
        }


        void This_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.KeyModifiers.HasFlag(KeyModifiers.Control))
                return;
            
            var key = e.Key;
            if (key == Key.Tab)
            {
                if (e.KeyModifiers.HasFlag(KeyModifiers.Shift))
                    VM.PreviousTabCommand();
                else
                    VM.NextTabCommand();
            }
            else if (e.KeyModifiers.HasFlag(KeyModifiers.Shift))
            {
                return;
            }
            else if (key == Key.PageUp)
            {
                VM.PreviousTabCommand();
            }
            else if (key == Key.PageDown)
            {
                VM.NextTabCommand();
            }
            else if (IsNumericalKey(key, out int keyNumber) && VM.JumpToTab(keyNumber - 1))
#pragma warning disable CS0642
                ; //Do nothing - VM.JumpToTab call is in condition instead of body to ensure CTRL+0 is still handled elsewhere
#pragma warning restore CS0642
            /*
            else if (_ZOOM_IN_KEYS.Contains(key))
            {
                VM.AdjustScaleFactor(true);
            }
            else if (_ZOOM_OUT_KEYS.Contains(key))
            {
                VM.AdjustScaleFactor(false);
            }
            else if (_ZOOM_RESET_KEYS.Contains(key))
            {
                VM.ResetScaleFactor();
            }
            */
            else
            {
                return;
            }
            
            e.Handled = true;
        }


        static readonly char _TAB_INDEX_KEY_PREFIX_TRIM_END_CHAR = '1';
        static readonly IReadOnlyList<string> _TAB_INDEX_KEY_PREFIXES = new List<string>()
        {
            nameof(Key.D1).TrimEnd(_TAB_INDEX_KEY_PREFIX_TRIM_END_CHAR),
            nameof(Key.NumPad1).TrimEnd(_TAB_INDEX_KEY_PREFIX_TRIM_END_CHAR)
        }.AsReadOnly();
        static bool IsNumericalKey(Key key, out int keyNumber)
        {
            string keyName = Enum.GetName(typeof(Key), key);
            if (string.IsNullOrEmpty(keyName) || string.IsNullOrWhiteSpace(keyName))
                goto none;
            
            foreach (string prefix in _TAB_INDEX_KEY_PREFIXES)
            {
                if (!keyName.StartsWith(prefix))
                    continue;
                
                if (int.TryParse(keyName.Substring(prefix.Length), out keyNumber))
                    return true;
            }

            none:
            keyNumber = -1;
            return false;
        }
    }
}
