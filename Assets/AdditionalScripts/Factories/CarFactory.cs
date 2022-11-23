using Unity.VisualScripting;
using UnityEngine;

namespace AdditionalScripts
{
    public class CarFactory : ICarFactory
    {
        private readonly IConfigProvider _configProvider;

        public CarFactory(IConfigProvider configProvider) => _configProvider = configProvider;

        public PlayerCar CreatePlayerCar(Transform at, Transform container)
        {
            VehicleControl vehicleControl = GameObject.Instantiate(_configProvider.BaseVehicleControlPrefab(),
                at.position, at.rotation, container);
            return vehicleControl.AddComponent<PlayerCar>();
        }

        public EnemyCar[] CreateEnemyCars(int amount) => default;
    }
}