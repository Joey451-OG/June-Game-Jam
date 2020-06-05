using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sound.RandomController
{
    [RequireComponent(typeof(AudioSource))]

    public class SoundRandomController : MonoBehaviour {

        public AudioClip[] Soundfiles;
        private AudioSource SoundEmitter;
        public bool RetriggerPrevention = true;

        public float pitchminimum = 1f;
        public float pitchmaximum = 1f;
        void Start()
        {
            SoundEmitter = GetComponent<AudioSource>();
        }


        void Update()
        {

        }
private void PlaySoundClip()
        {
            float pitch = Random.Range(pitchminimum, pitchmaximum);
            SoundEmitter.pitch = pitch;

            //Establishes a random number between 1 and max size of audio clips. Moves clip to audio source and plays it once.
            int n = Random.Range(1,Soundfiles.Length);
            SoundEmitter.clip = Soundfiles[n];
            SoundEmitter.PlayOneShot(SoundEmitter.clip);

            if (RetriggerPrevention)
            {
                Soundfiles[n] = Soundfiles[0];
                Soundfiles[0] = SoundEmitter.clip;
            }
        }

        public static void Trigger(SoundRandomController scr)
        {
            if (scr != null) scr.PlaySoundClip();
        }
    }
}