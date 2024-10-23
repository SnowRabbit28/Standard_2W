using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour // ������ ������, � ������, ������Ʈ �̸� 3������ ����!!!!
{
    // ������ ������
    public GameObject prefab;

    // ������Ʈ Ǯ�� ���� ����Ʈ
    private List<GameObject> pool = new List<GameObject>();

    //�̸� ������ ������Ʈ ��
    public int poolSize = 300;

    void Start()
    {
        // �̸� poolSize��ŭ ���ӿ�����Ʈ�� �����Ѵ�.
        for (int i = 0; i < poolSize; i++)
        {
            //������Ʈ Ǯ ���� = Instantiate , �Ҹ� Destory
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject Get()
    {
        // �����ִ� ���ӿ�����Ʈ�� ã�� active�� ���·� �����ϰ� return �Ѵ�.
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy) //���̶�Űâ�� Ȱ��ȭ�Ǿ��ִ� ����Ǯ�� ���ٸ�
            {
                obj.SetActive(true); //Ȱ��ȭ���ְ�
                return obj; //��ȯ
            }
            
        }
        // �ƹ��͵� ���ٸ�, ���ο� ������Ʈ�� �����ϰ� ��ȯ return null�� �ȵ�!
        GameObject newobj = Instantiate(prefab);
        newobj.SetActive(false);
        pool.Add(newobj);
        return newobj;
    }

    public void Release(GameObject obj)
    {
        // ���ӿ�����Ʈ�� deactive�Ѵ�.
        obj?.SetActive(false);
    }


}
