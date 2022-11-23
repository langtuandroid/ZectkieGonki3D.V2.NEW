namespace AdditionalScripts
{
    public class ConfigProvider : IConfigProvider
    {
        private readonly ConfigContainer _configContainer;
        public ConfigProvider(ConfigContainer configContainer) => _configContainer = configContainer;
        public VehicleControl BaseVehicleControlPrefab() => _configContainer.BaseVehicleControlPrefab;
    }
}