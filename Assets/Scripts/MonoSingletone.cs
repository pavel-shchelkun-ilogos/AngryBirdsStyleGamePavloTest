using UnityEngine;

// Singletone pattern for MonoBehavior
public abstract class MonoSingleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;
    private static readonly object lockObject = new object();
    private static bool isApplicationQuitting;

    public static T Instance
    {
        get
        {
            if (isApplicationQuitting)
            {
                Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed. Returning null.");
                return null;
            }

            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    
                    if (instance == null)
                    {
                        if (Application.isPlaying)
                        {
                            GameObject singletonObject = new GameObject(typeof(T).Name);
                            instance = singletonObject.AddComponent<T>();
                        }
                        else
                        {
                            Debug.LogError($"No instance of {typeof(T)} found in the scene!");
                        }
                    }
                }
                return instance;
            }
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            
            if (IsPersistent)
            {
                transform.SetParent(null);
                DontDestroyOnLoad(gameObject);
            }
        }
        else if (instance != this)
        {
            Debug.LogWarning($"Multiple instances of {typeof(T)} detected. Destroying {gameObject.name}");
            DestroyImmediate(gameObject);
        }
    }

    protected virtual void OnApplicationQuit()
    {
        isApplicationQuitting = true;
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

    protected virtual bool IsPersistent => false;
}