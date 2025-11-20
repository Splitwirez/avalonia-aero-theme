using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using AeroAvalonia.Demo.ViewModels;

namespace AeroAvalonia.Demo
{
    public class ViewLocator
        : IDataTemplate
    {
        public bool SupportsRecycling => false;

        public Control Build(object data)
        {
            var type = ((ViewModelBase)data).ViewType;
            
            if (type == null)
                return GetFailTextBlock(data);
            
            if (!(Activator.CreateInstance(type) is Control ret))
                return GetFailTextBlock(data);
            
            return ret;
        }

        TextBlock GetFailTextBlock(object data)
            => new TextBlock()
            {
                Text = $"Not Found: {data.GetType().FullName}"
            };

        public bool Match(object data)
        {
            return data is ViewModelBase;
        }
    }
}
