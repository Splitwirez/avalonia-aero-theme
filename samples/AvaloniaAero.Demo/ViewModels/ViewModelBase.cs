using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ReactiveUI;

namespace AvaloniaAero.Demo.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        protected virtual Type GetViewType()
            => Type.GetType(GetType().FullName.Replace("ViewModel", "View"));
        
        Type _viewType = null;
        public Type ViewType
        {
            get
            {
                if (_viewType == null)
                    _viewType = GetViewType();
                return _viewType;
            }
        }
        
        public T RASIC<T>(ref T backingField, T newValue, [CallerMemberName]string propertyName = null) 
            => this.RaiseAndSetIfChanged(ref backingField, newValue, propertyName);
    }
}
