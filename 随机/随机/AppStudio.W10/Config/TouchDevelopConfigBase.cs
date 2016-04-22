using AppStudio.DataProviders.TouchDevelop;

namespace AppStudio.Config
{
    public abstract class TouchDevelopConfigBase : ConfigBase<TouchDevelopDataConfig, TouchDevelopSchema>
    {
        public abstract string Title { get; }
    }
}
