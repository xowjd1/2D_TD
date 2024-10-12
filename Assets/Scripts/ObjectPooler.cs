using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10;

    private List<GameObject> pool;
    private GameObject poolContainer;

    private void Awake()
    {
        pool = new List<GameObject>();
        poolContainer = new GameObject($"Pool - {prefab.name}");

        CreatePooler();
    }

    void CreatePooler()
    {
        for (int i = 0; i < poolSize; i++)
        {
            pool.Add(CreateInstance());
        }
    }


    private GameObject CreateInstance()
    {
        GameObject newInstance = Instantiate(prefab);
        newInstance.transform.SetParent(poolContainer.transform); // poolContainer 라는 부모가 생김 "Pool - {prefab.name}" 라는 이름으로
        newInstance.SetActive(false);
        return newInstance;
    }

    public GameObject GetInstanceFromPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        return CreateInstance();
    }
}
