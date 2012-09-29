using System.Collections.Generic;

namespace Podcaster.Core
{
    public enum ActionCalled
    {
        ShowStart,
        ShowStop
    }

    public interface ICommand
    {
        void RunCommand(object args, ActionCalled ac);
        void SetParameter(string key, string value);
        object GetParameter(string key);
        void Dispose();
    }
}
