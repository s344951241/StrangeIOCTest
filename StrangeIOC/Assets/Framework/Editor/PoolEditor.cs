using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PoolEditor  {
    [MenuItem("Manager/Create GameObjectPoolCfg")]
    static void CreateGameObjectPoolList()
    {
        GameObjectPoolList poolList = ScriptableObject.CreateInstance<GameObjectPoolList>();
        string path =  PoolManager.PoolCfgPath;
        AssetDatabase.CreateAsset(poolList, path);
    }
}
