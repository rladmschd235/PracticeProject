using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> poolList = new List<GameObject>();
    private Dictionary<string, Stack<GameObject>> rocketPools = new Dictionary<string, Stack<GameObject>>();

    public static RocketSpawnManager Instance;

    private void Awake()
    {
        foreach(GameObject rocketObject in poolList)
        {
            rocketPools.Add(rocketObject.name, new Stack<GameObject>());
            for(int i = 0; i<5; i++)
            {
                GameObject rocket = Instantiate(rocketObject);
                rocket.SetActive(false);
                rocket.name = rocket.name.Replace("(Clone)", null);
                rocket.transform.SetParent(this.transform);
                rocketPools[rocketObject.name].Push(rocket);
            }

            if(Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(Instance);
            }
        }
    }

    public GameObject Pop(GameObject rocketPrefab)
    {
        GameObject prefabObject = null;

        if(rocketPools[rocketPrefab.name].Count <= 0)
        {
            prefabObject = Instantiate(rocketPrefab);
            prefabObject.name = prefabObject.name.Replace("(Clone)", null);
            prefabObject.transform.SetParent(transform);
        }
        else
        {
            prefabObject = rocketPools[rocketPrefab.name].Pop();
        }

        prefabObject.SetActive(true);

        return prefabObject;
    }

    public void Push(GameObject rocketPrefab)
    {
        rocketPools[rocketPrefab.name].Push(rocketPrefab);
        rocketPrefab.SetActive(false);
    }
}
