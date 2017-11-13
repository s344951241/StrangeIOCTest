using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager{

    public static PoolManager _instance;

    public static PoolManager Instance {
        get {
            if (_instance == null)
                _instance = new PoolManager();
            return _instance;
        }
    }


    private static string poolCfgPathPrefix = Application.dataPath + "Assets/Framework/Resources/";
    private const string poolCfgPathMidfix = "gameobjectpool";
    private const string poolCfgPathPostfix = ".asset";

    public static string PoolCfgPath
    {
        get {
            return poolCfgPathPrefix + poolCfgPathMidfix + poolCfgPathPostfix;
        }
    }
    private Dictionary<string, GameObjectPool> poolDic;
    private PoolManager()
    {
        GameObjectPoolList poolList = Resources.Load<GameObjectPoolList>(poolCfgPathMidfix);
        poolDic = new Dictionary<string, GameObjectPool>();

        foreach (GameObjectPool pool in poolList.poolList)
        {
            poolDic.Add(pool.name, pool);
        }
    }
    
    public void Init() { }

    public GameObject GetInst(string poolName)
    {
        GameObjectPool pool;
        if (poolDic.TryGetValue(poolName, out pool))
        {
            return pool.GetInst();
        }
        Debug.LogWarning("Pool is not exist" + poolName);
        return null;
    }
}
