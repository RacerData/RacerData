namespace RacerData.Themes.Ports
{
    interface IAppearanceFactory
    {
        IAppearance BuildNewAppearance(ISystemColors colors);
    }
}