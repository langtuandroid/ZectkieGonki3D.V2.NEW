using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class VehicleCamera : MonoBehaviour
{
    private Transform _target;

    public float smooth = 0.3f;
    public float distance = 5.0f;
    public float height = 1.0f;
    public float Angle = 20;


    public List<Transform> cameraSwitchView;
    public LayerMask lineOfSightMask = 0;

    public CarUIClass CarUI;


    private float yVelocity = 0.0f;
    private float xVelocity = 0.0f;
    [HideInInspector] public int Switch;

    private int gearst = 0;
    private float thisAngle = -150;
    private float restTime = 0.0f;

    private VehicleControl _carScript;
    private Camera _camera;

    [Serializable]
    public class CarUIClass
    {
        public Image tachometerNeedle;
        public Image barShiftGUI;

        public Text speedText;
        public Text GearText;
    }

    private void ShowCarUI()
    {
        gearst = _carScript.currentGear;
        CarUI.speedText.text = ((int) _carScript.speed).ToString();

        if (_carScript.carSetting.automaticGear)
        {
            if (gearst > 0 && _carScript.speed > 1)
            {
                CarUI.GearText.color = Color.green;
                CarUI.GearText.text = gearst.ToString();
            }
            else if (_carScript.speed > 1)
            {
                CarUI.GearText.color = Color.red;
                CarUI.GearText.text = "R";
            }
            else
            {
                CarUI.GearText.color = Color.white;
                CarUI.GearText.text = "N";
            }
        }
        else
        {
            if (_carScript.NeutralGear)
            {
                CarUI.GearText.color = Color.white;
                CarUI.GearText.text = "N";
            }
            else
            {
                if (_carScript.currentGear != 0)
                {
                    CarUI.GearText.color = Color.green;
                    CarUI.GearText.text = gearst.ToString();
                }
                else
                {
                    CarUI.GearText.color = Color.red;
                    CarUI.GearText.text = "R";
                }
            }
        }

        thisAngle = (_carScript.motorRPM / 20) - 175;
        thisAngle = Mathf.Clamp(thisAngle, -180, 90);

        CarUI.tachometerNeedle.rectTransform.rotation = Quaternion.Euler(0, 0, -thisAngle);
        CarUI.barShiftGUI.rectTransform.localScale = new Vector3(_carScript.powerShift / 100.0f, 1, 1);
    }


    public void Initialize(VehicleControl carScript)
    {
        _carScript = carScript;
        cameraSwitchView = _carScript.carSetting.cameraSwitchView;
        _camera = Camera.main;
        _target = carScript.transform;
    }


    void Update()
    {
        if (!_target)
            return;

        ShowCarUI();
        _camera.fieldOfView = Mathf.Clamp(_carScript.speed / 10.0f + 60.0f, 60, 90.0f);

        if (Switch == 0)
        {
            // Damp angle from current y-angle towards _target y-angle

            float xAngle = Mathf.SmoothDampAngle(transform.eulerAngles.x,
                _target.eulerAngles.x + Angle, ref xVelocity, smooth);

            float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                _target.eulerAngles.y, ref yVelocity, smooth);

            // Look at the _target
            transform.eulerAngles = new Vector3(xAngle, yAngle, 0.0f);

            var direction = transform.rotation * -Vector3.forward;
            var targetDistance = AdjustLineOfSight(_target.position + new Vector3(0, height, 0), direction);


            transform.position = _target.position + new Vector3(0, height, 0) + direction * targetDistance;
        }
        else
        {
            transform.position = cameraSwitchView[Switch - 1].position;
            transform.rotation = Quaternion.Lerp(transform.rotation, cameraSwitchView[Switch - 1].rotation,
                Time.deltaTime * 5.0f);
        }
    }

    float AdjustLineOfSight(Vector3 target, Vector3 direction)
    {
        if (Physics.Raycast(target, direction, out var hit, distance, lineOfSightMask.value))
            return hit.distance;
        return distance;
    }
}