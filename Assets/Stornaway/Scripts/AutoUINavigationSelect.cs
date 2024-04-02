using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;

namespace Stornaway
{ 
    public class AutoUINavigationSelect : MonoBehaviour
    {
        [SerializeField]
        private GameObject firstSelected = null;

        private EventSystem eventSystem = null;
        private InputSystemUIInputModule inputModule = null;


        private void Awake()
        {
            eventSystem = GetComponent<EventSystem>();
            inputModule = GetComponent<InputSystemUIInputModule>();
        }


        void Update()
        {
            Vector2 navigation = inputModule.move.action.ReadValue<Vector2>();
            
            if (!eventSystem.currentSelectedGameObject)
            {
                if (Mathf.Abs(navigation.x) > 0.1f ||
                        Mathf.Abs(navigation.y) > 0.1f)
                {
                    eventSystem.SetSelectedGameObject(firstSelected);
                }
            }
        }
    }
}