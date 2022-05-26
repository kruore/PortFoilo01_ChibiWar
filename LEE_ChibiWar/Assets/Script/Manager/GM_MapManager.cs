using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_MapManager : MonoBehaviour
{
    Vector3 map_pos = Vector3.zero;
    public void DestroyMap()
    {
        GameObject map = GameObject.Find("Map");
        if(map !=null)
        {
            GameObject.Destroy(map);
        }
    }

    public void LoadMap(int mapId)
    {
        DestroyMap();
        string mapName = "Map_" + mapId.ToString("000");
        var go = Instantiate( Resources.Load($"Prefab/Map/{mapName}"),map_pos,Quaternion.identity);
        go.name = "Map";
    }

    public void Start()
    {
        LoadMap(1);
    }
}
