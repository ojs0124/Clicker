using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                }
                else
                {
                    Destroy(_instance);
                }
            }

            return _instance;
        }
    }

    public void Awake()
    {
        DontDestroyOnLoad(_instance);
    }

    public virtual void Release()
    {
        if (_instance == null) return;

        if (_instance.gameObject) Destroy(_instance.gameObject);

        _instance = null;
    }
}
