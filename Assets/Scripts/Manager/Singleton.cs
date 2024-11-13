using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<T>();

                if (!_instance)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).Name;
                }
                else
                {
                    Destroy(((MonoBehaviour)_instance).gameObject);
                }
            }

            return _instance;
        }
    }

    public void Awake()
    {
        if (!_instance)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (_instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public virtual void Release()
    {
        if (!_instance) return;

        if (_instance) Destroy(_instance.gameObject);

        _instance = null;
    }
}
