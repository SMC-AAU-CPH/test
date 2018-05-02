namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;
    using System.Collections;
    using System.Collections.Generic;

    public class keyTouch : MonoBehaviour
    {
        public AudioSource pianoSound;

        private VRTK_Button_UnityEvents buttonEvents;

        private void Start()
        {
            pianoSound = GetComponent<AudioSource>();
            buttonEvents = GetComponent<VRTK_Button_UnityEvents>();
            if (buttonEvents == null)
            {
                buttonEvents = gameObject.AddComponent<VRTK_Button_UnityEvents>();
            }
            buttonEvents.OnPushed.AddListener(handlePush);
        }

        private void handlePush(object sender, Control3DEventArgs e)
        {
            VRTK_Logger.Info("Pushed");

            pianoSound.Play();
        }
    }
}
