using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{
    // Destroy ���� Ȯ�ο�
    private static bool ShuttingDown = false;
    private static object Lock = new object();
    private static T instance;

    public static T Instance
    {
        get
        {
            // ���� ���� �� Object ���� �̱����� OnDestroy �� ���� ���� �� ���� �ִ�. 
            // �ش� �̱����� gameObject.Ondestory() ������ ������� �ʰų� ����Ѵٸ� null üũ�� ������
            if (ShuttingDown)
            {
                Debug.Log("[Singleton] Instance '" + typeof(T) + "' already destroyed. Returning null.");
                return null;
            }

            lock (Lock)    //Thread Safe
            {
                if (instance == null)
                {
                    // �ν��Ͻ� ���� ���� Ȯ��
                    instance = (T)FindObjectOfType(typeof(T));

                    // ���� �������� �ʾҴٸ� �ν��Ͻ� ����
                    if (instance == null)
                    {
                        // ���ο� ���ӿ�����Ʈ�� ���� �̱��� Attach
                        var singletonObject = new GameObject();
                        instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";

                        // Make instance persistent.
                        DontDestroyOnLoad(singletonObject);
                    }
                }
                return instance;
            }
        }
    }

    public virtual void Init()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
