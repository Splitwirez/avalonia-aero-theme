using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using AvaloniaAero.Demo.ViewModels;

namespace AvaloniaAero.Demo
{
    public class ViewLocator : IDataTemplate
    {
        public bool SupportsRecycling => false;

        public Control Build(object data)
        {
            Control ret = null;
            
            var type = ((ViewModelBase)data).GetViewTypeName();
            
            if (type != null)
                ret = (Control)Activator.CreateInstance(type);
            
            return (ret != null)
                ? ret
                : new TextBlock
                    {
                        Text = $"Not Found: {data.GetType().FullName}"
                    };
        }

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}
