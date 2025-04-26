using System;
using System.Diagnostics;
using AvaloniaAero.Demo.Navigation;

namespace AvaloniaAero.Demo.ViewModels
{
    public class PageViewModelBase
        : ViewModelBase
        , IPage
    {
        INavigator _navigator = null;
        public INavigator Navigator
        {
            get => _navigator;
            set => RASIC(ref _navigator, value);
        }



        string _title = null;
        public string Title
        {
            get => _title;
            set => RASIC(ref _title, value);
        }


        public PageViewModelBase()
            : base()
        {
            Title = GetTitleFromType(GetType());
        }
        protected PageViewModelBase(string title)
            : this()
        {
            Title = title;
        }




        const string _VM_SUFFIX = "ViewModel";
        static readonly int _VM_SUFFIX_LENGTH = _VM_SUFFIX.Length;
        const string _PAGE_SUFFIX = "Page";
        static readonly int _PAGE_SUFFIX_LENGTH = _PAGE_SUFFIX.Length;
        static string GetTitleFromTypeName(string typeName)
        {
            Debug.WriteLine($"{nameof(GetTitleFromTypeName)}('{typeName}')");
            string ret = typeName;
            Debug.WriteLine(ret);

            if (ret.EndsWith(_VM_SUFFIX))
                ret = ret.Substring(0, ret.Length - _VM_SUFFIX_LENGTH);
            Debug.WriteLine(ret);

            if (ret.EndsWith(_PAGE_SUFFIX))
                ret = ret.Substring(0, ret.Length - _PAGE_SUFFIX_LENGTH);
            Debug.WriteLine(ret);

            return ret;
        }
        static string GetTitleFromType(Type type)
            => GetTitleFromTypeName(type.Name);
    }
}
