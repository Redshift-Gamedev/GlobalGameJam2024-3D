using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GlobalGameJam
{
    public class AudioPlayer : MonoBehaviour
    {
        AudioSource audioSource;

        [SerializeField] AudioSource runSource;
        [SerializeField] AudioSource walkSource;
        [SerializeField] AudioClip runAudio;
        [SerializeField] AudioClip walkAudio;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            FPSController.OnPlayerMoving += PlayAudio;
            FPSController.OnPlayerStopped += StopAudio;

        }

        private void OnDestroy()
        {
            FPSController.OnPlayerMoving -= PlayAudio;
            FPSController.OnPlayerStopped -= StopAudio;
        }

        private void PlayAudio(bool isRunning)
        {
            if(isRunning)
            {
                walkSource.Stop();
                runSource.Play();
            }
            else
            {
                runSource.Stop();
                walkSource.Play();
            }
        }

        private void StopAudio()
        {

            runSource.Stop();
            walkSource.Stop();
        }
    }
}