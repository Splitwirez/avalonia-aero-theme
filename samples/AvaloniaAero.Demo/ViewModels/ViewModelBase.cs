using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ReactiveUI;

namespace AvaloniaAero.Demo.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        public virtual Type GetViewTypeName()
            => Type.GetType(GetType().FullName.Replace("ViewModel", "View"));
        
        public T RASIC<T>(ref T backingField, T newValue, [CallerMemberName]string propertyName = null) 
            => this.RaiseAndSetIfChanged(ref backingField, newValue, propertyName);
    }
}
