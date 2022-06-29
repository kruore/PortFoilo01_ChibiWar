using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GM_MapManager : MonoBehaviour
{
    //Stage Controll
    public enum StageState
    {
        Start, Level00, Level01, Level02, Level03, Level04, Final
    }
    public StageState stageState = StageState.Start;

    //Round Time
    public float roundTime = 0.0f;
    
    //Map Component
    Vector3 map_pos = Vector3.zero;
    GameObject map = null;
    GameObject destroyField = null;


    //UI Controlled
    public TMP_Text stageCount;
    public TMP_Text nowStage;


    //Player Controll Component
    public int playerLength;

    // where player Spon it
    public List<Vector3> sponPosition = new List<Vector3>();

    /// <summary>
    /// Map Init and Controlled
    /// </summary>
    /// <param name="mapId">생성 맵 아이디 확장 가능 로직</param>
    public void LoadMap(int mapId)
    {
        string mapName = "Map_" + mapId.ToString("000");
        destroyField = (GameObject)Instantiate(Resources.Load($"Prefab/Map/{mapName}"), new Vector3(map_pos.x, map_pos.y - 0.01f, map_pos.z), Quaternion.identity);
        destroyField.name = "DestroyField";
        map = (GameObject)Instantiate(Resources.Load($"Prefab/Map/{mapName}"), map_pos, Quaternion.identity);
        map.name = "Map";
        var a = destroyField.GetComponent<Renderer>();
        a.material.color = Color.red;

        // Load Player Pos
        LoadPlayer();
    }

    public void Start()
    {
        //1번 맵 콜링 
        LoadMap(1);
    }

    public void Update()
    {
        // 라운드 플레이 진행
        if (roundTime > 0)
        {
            roundTime -= Time.deltaTime;
            stageCount.text = roundTime.ToString("N0");
        }
        else
        {
            roundTime = 10.0f;
            RoundChanger();
        }
    }


    public void LoadPlayer()
    {
        for (int i = 0; i < playerLength; i++)
        {
            sponPosition.Add(new Vector3(Vector3.zero.x+i, Vector3.zero.y + i,0f));
        }
    }

    /// <summary>
    /// Round KipContinue When you playit
    /// </summary>
    public void RoundChanger()
    {
        switch (stageState)
        {
            case StageState.Start:
                stageState = StageState.Level00;
                nowStage.text = "자 지금부터 서로 죽이고 죽여라";
                map.transform.localScale = new Vector3(4.5f, 1.0f, 4.5f);
                break;
            case StageState.Level00:
                stageState = StageState.Level01;
                nowStage.text = "스테이지 1";
                map.transform.localScale = new Vector3(4.0f, 1.0f, 4.0f);
                break;
            case StageState.Level01:
                stageState = StageState.Level02;
                nowStage.text = "스테이지 2";
                map.transform.localScale = new Vector3(3.0f, 1.0f, 3.0f);
                break;
            case StageState.Level02:
                stageState = StageState.Level03;
                nowStage.text = "스테이지 3";
                map.transform.localScale = new Vector3(2.0f, 1.0f, 2.0f);
                break;
            case StageState.Level03:
                stageState = StageState.Level04;
                nowStage.text = "아직도 안죽었어?";
                map.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
            case StageState.Level04:
                stageState = StageState.Final;
                nowStage.text = "다 죽어라!!!";
                map.transform.localScale = new Vector3(0.5f, 0.0f, 0.5f);
                break;
            case StageState.Final:
                map.SetActive(false);
                nowStage.text = "그리고 아무도 없었다.";
                //   Time.timeScale = 1.0f;
                break;
            default:
                Time.timeScale = 0.0f;
                break;
        }
    }
}
