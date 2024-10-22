using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [�������� 1] ���� �ʵ� ����
    private static QuestManager instance;

    // [�������� 2] ���� ������Ƽ ����
    public static QuestManager Instance
    {
        get
        {
            if (instance == null)
            {  
                // ���� ���� �����ϴ� QuestManager ������Ʈ�� ã��
                instance = FindObjectOfType<QuestManager>();

                if (instance == null)
                {
                    // �׷��� null�̸� �� ���� ������Ʈ�� �����ϰ� QuestManager ������Ʈ�� �߰�
                    GameObject gameObject = new GameObject("QuestManager");
                    instance = gameObject.AddComponent<QuestManager>();
                }
            }
            return instance;
        }
    }

    // [�������� 3] �ν��Ͻ� �˻� ����
    private void Awake()
    {
        // ���� �ν��Ͻ��� null�� �ƴϰ�, ���� �ν��Ͻ��� �ڽ��� �ƴ� ��� �ı�
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // �ߺ��Ǵ� �ν��Ͻ� �ı�
        }
        else
        {
            // �ν��Ͻ��� �����ϰ� �ı����� �ʵ��� ����
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}