using UnityEngine;

namespace UdemyProject.Abstracts.Utilities
{
    public class Singleton<T> : MonoBehaviour
    {
        public static T Instance { get;private set; }
        

        protected void SingletonThisGameObject(T entities)
        {
            if (Instance == null)
            {
                Instance = entities;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}