using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    private static bool destroying = false;
    private static object syncRoot = new Object();

    public static T Instance
    {
        get
        {
            if (destroying)
            {
                return null;
            }

            if (instance == null)
            {
                lock (syncRoot)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                    if (instance == null)
                    {
                        GameObject singleton = new GameObject();
                        singleton.name = "[singleton]" + typeof(T).ToString();
                        instance = singleton.AddComponent<T>();
                        DontDestroyOnLoad(singleton);
                    }
                }
            }
            return instance;
        }
    }

    virtual public void OnDestroy()
    {
        destroying = true;
    }
}