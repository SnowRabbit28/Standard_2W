using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    // [구현사항 1] 정적 필드 정의
    private static QuestManager instance;

    // [구현사항 2] 정적 프로퍼티 정의
    public static QuestManager Instance
    {
        get
        {
            if (instance == null)
            {  
                // 게임 내에 존재하는 QuestManager 오브젝트를 찾음
                instance = FindObjectOfType<QuestManager>();

                if (instance == null)
                {
                    // 그래도 null이면 새 게임 오브젝트를 생성하고 QuestManager 컴포넌트를 추가
                    GameObject gameObject = new GameObject("QuestManager");
                    instance = gameObject.AddComponent<QuestManager>();
                }
            }
            return instance;
        }
    }

    // [구현사항 3] 인스턴스 검사 로직
    private void Awake()
    {
        // 만약 인스턴스가 null이 아니고, 현재 인스턴스가 자신이 아닐 경우 파괴
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // 중복되는 인스턴스 파괴
        }
        else
        {
            // 인스턴스를 설정하고 파괴되지 않도록 설정
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}