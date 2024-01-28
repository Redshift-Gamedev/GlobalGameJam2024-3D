using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace GlobalGameJam
{
    public class AudioPlayer : MonoBehaviour
    {
        AudioSource audioSource;
        [SerializeField] AudioClip runAudio;
        [SerializeField] AudioClip walkAudio;
        [SerializeField] AudioClip jumpAudio;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            FPSController.OnPlayerMoving += PlayAudio;
            FPSController.OnPlayerStopped += StopAudio;
            FPSController.OnPlayerJumping += PlayJumpAudio;

            PauseListener.OnGamePauseStateChanged += PauseAudio;
        }

        private void OnDestroy()
        {
            FPSController.OnPlayerMoving -= PlayAudio;
            FPSController.OnPlayerStopped -= StopAudio;
            FPSController.OnPlayerJumping -= PlayJumpAudio;

            PauseListener.OnGamePauseStateChanged -= PauseAudio;
        }

        private void PlayAudio(bool isRunning)
        {
            audioSource.clip = isRunning ? runAudio : walkAudio;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }


        private void PauseAudio(bool isPaused)
        {
            if (isPaused)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.UnPause();
            }
        }

        private void PlayJumpAudio()
        {
            audioSource.PlayOneShot(jumpAudio);
        }

        private void StopAudio()
        {
            audioSource.Stop();
            audioSource.clip = null;
        }
    }
}