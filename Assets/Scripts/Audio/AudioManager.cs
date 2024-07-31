using System;
using UnityEngine;

namespace Breakout
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            DontDestroyOnLoad(gameObject);

            foreach (var sound in sounds)
            {
                sound.Source = gameObject.AddComponent<AudioSource>();
                sound.Source.clip = sound.Clip;
                sound.Source.volume = sound.Volume;
                sound.Source.pitch = sound.Pitch;
            }
        }

        [SerializeField] private Sound[] sounds;

        public void Play(string name)
        {
            var playSound = Array.Find(sounds, sound => sound.Name == name);
            if (playSound == null)
            {
                Debug.LogError($"[AudioManager]:  Could not found sound with name {name}");
                return;
            }
            playSound.Source.Play();
        }
    }
}
