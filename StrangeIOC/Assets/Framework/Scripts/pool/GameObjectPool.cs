using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 资源池
/// </summary>
[Serializable]
public class GameObjectPool {
    [SerializeField]
    private int MAX;

    public string name;
    [SerializeField]
    private GameObject prefab;
    [NonSerialized]
    private List<GameObject> goList = new List<GameObject>();

    /// <summary>
    /// 从资源池中获取一个实例
    /// </summary>
    public GameObject GetInst()
    {
        foreach (GameObject go in goList)
        {
            if (go.activeInHierarchy == false)
            {
                go.SetActive(true);
                return go;
            }

        }

        if (goList.Count >= MAX)
        {
            GameObject.Destroy(goList[0]);
            goList.RemoveAt(0);
        }

        GameObject temp = GameObject.Instantiate(prefab);
        goList.Add(temp);

        return temp;

    }

}
