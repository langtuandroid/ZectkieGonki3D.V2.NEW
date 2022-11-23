using UnityEngine;

namespace AdditionalScripts
{
    public class ConfigContainer : MonoBehaviour
    {
        [field: SerializeField] public VehicleControl BaseVehicleControlPrefab { get; private set; }
    }
}