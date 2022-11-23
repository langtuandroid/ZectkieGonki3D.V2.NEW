//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class CloseUI : MonoBehaviour
//{
//    [SerializeField] private GameObject _closeUI;


//    private void OnTriggerEnter(Collider collsion)
//    {
//        if (GarageButon.MenuBuyCar)
//        {
//            return;
//        }

//        if (collsion.TryGetComponent<UIMenu>(out UIMenu uiMenu))
//        {
          
           
//            _closeUI.SetActive(true);
            
//        }
//    }
//    private void OnTriggerExit(Collider collsion)
//    {
//        if (GarageButon.MenuBuyCar)
//        {
//            return;
//        }

//        if (collsion.TryGetComponent<UIMenu>(out UIMenu uiMenu))
//        {
        
           
//            _closeUI.SetActive(false);
        
//        }
//    }
//}
