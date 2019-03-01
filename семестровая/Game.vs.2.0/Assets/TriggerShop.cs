using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class TriggerShop : MonoBehaviour
    {

        public GameObject panel;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider col)
        {
                if (col.tag == "Player")
                {
                    panel.SetActive(true);
                    col.GetComponent<FirstPersonController>().enabled = false;
                    //Cursor.Instance.Show();
                    //Screen.showCursor = true; //вернуть
                    Cursor.visible = true;
                }
        }
        void OnTriggerExit(Collider col)
        {
            if (col.tag == "Player")
            {
                panel.SetActive(false);
                col.GetComponent<FirstPersonController>().enabled = true;
                Cursor.visible = false;
            }
        }
    }
}

