using Volo.Abp.Settings;

namespace OkulApplication.Settings;

public class OkulApplicationSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(OkulApplicationSettings.MySetting1));
    }
}
