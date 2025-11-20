using System.Collections.ObjectModel;

namespace AeroAvalonia.Demo.ViewModels
{
    public abstract class TabsViewModelBase
        : ViewModelBase
    {
        protected abstract ObservableCollection<ViewModelBase> CreateTabs();
        readonly ObservableCollection<ViewModelBase> _tabs;
        public ObservableCollection<ViewModelBase> Tabs
        {
            get => _tabs;
        }


        int _selectedIndex = 0;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set => RASIC(ref _selectedIndex, value);
        }

        public bool IsTabIndexvalid(int index)
        {
            int tabCount = Tabs.Count;
            if (tabCount <= 0)
                return false;
            
            if (index >= tabCount)
                return false;
            else if (index < 0)
                return false;
            
            return true;
        }

        public int WrapTabIndex(int rawIndex)
        {
            int newIndex = rawIndex;
            
            int tabCount = Tabs.Count;
            while (newIndex >= tabCount)
            {
                newIndex -= tabCount;
            }
            
            while (newIndex < 0)
            {
                newIndex += tabCount;
            }
            
            return newIndex;
        }

        public TabsViewModelBase()
            : base()
        {
            _tabs = CreateTabs();
        }




        public void NextTabCommand(object _ = null)
            => SelectedIndex = WrapTabIndex(SelectedIndex + 1);
        public void PreviousTabCommand(object _ = null)
            => SelectedIndex = WrapTabIndex(SelectedIndex - 1);
        public bool JumpToTab(int index)
        {
            if (!IsTabIndexvalid(index))
                return false;
            
            SelectedIndex = index;
            return true;
        }

        
        public void JumpToTabCommand(object parameter)
        {
            if (parameter == null)
                return;
            int index;
            
            if (parameter is int pBool)
            {
                index = pBool;
            }
            else
            {
                string prmStr = (parameter is string sPrm)
                        ? sPrm
                        : parameter.ToString()
                ;
                
                if (!int.TryParse(prmStr, out index))
                    return;
            }

            JumpToTab(index);
        }
    }
}