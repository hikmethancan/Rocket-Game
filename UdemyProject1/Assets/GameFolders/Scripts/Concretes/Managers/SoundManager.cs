
using UdemyProject.Abstracts.Utilities;
using UnityEngine;


namespace UdemyProject.Managers
{
    public class SoundManager : Singleton<SoundManager>
    {
        private AudioSource[] _audioSource;
        private void Awake()
        {
            SingletonThisGameObject(this);
            _audioSource = GetComponentsInChildren<AudioSource>();
        }

        public void PlaySound(int index)
        {
            if (!_audioSource[index].isPlaying)
            {
                _audioSource[index].Play();
            }
            
        }

        public void StopSound(int index)
        {
            if (_audioSource[index].isPlaying)
            {
                _audioSource[index].Stop();
            }
        }
    }
}