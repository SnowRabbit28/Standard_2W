using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour // 생성할 프리팹, 몇개 들어갈건지, 오브젝트 이름 3가지가 들어간다!!!!
{
    // 생성할 프리팹
    public GameObject prefab;

    // 오브젝트 풀을 담을 리스트
    private List<GameObject> pool = new List<GameObject>();

    //미리 생성할 오브젝트 수
    public int poolSize = 300;

    void Start()
    {
        // 미리 poolSize만큼 게임오브젝트를 생성한다.
        for (int i = 0; i < poolSize; i++)
        {
            //오브젝트 풀 생성 = Instantiate , 소멸 Destory
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject Get()
    {
        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy) //하이라키창에 활성화되어있는 옵젝풀이 없다면
            {
                obj.SetActive(true); //활성화해주고
                return obj; //반환
            }
            
        }
        // 아무것도 없다면, 새로운 오브젝트를 생성하고 반환 return null은 안돼!
        GameObject newobj = Instantiate(prefab);
        newobj.SetActive(false);
        pool.Add(newobj);
        return newobj;
    }

    public void Release(GameObject obj)
    {
        // 게임오브젝트를 deactive한다.
        obj?.SetActive(false);
    }


}
