using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using AeroDemo.ViewModels;

namespace AeroDemo
{
    public class ViewLocator : IDataTemplate
    {
        public bool SupportsRecycling => false;

        public IControl Build(object data)
        {
            IControl ret = null;
            
            var type = ((ViewModelBase)data).GetViewTypeName();
            
            if (type != null)
                ret = (IControl)Activator.CreateInstance(type);
            
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