using UnityEngine;

namespace AdditionalScripts
{
    public class PlayerCar : MonoBehaviour
    {
        [SerializeField] private VehicleControl _vehicleControl;

        public void Initialize() => _vehicleControl = GetComponent<VehicleControl>();
    }
}