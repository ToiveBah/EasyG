using EasyG.ViewModels;

namespace EasyG.Messages
{
    public class CurrentActiveViewChangesMessage : BaseMessage
    {
        public CurrentActiveViewChangesMessage(object sender, INavigationSource source) : base(sender)
        {
            NavigationSource = source;
        }

        public INavigationSource NavigationSource { get; }
    }
}
