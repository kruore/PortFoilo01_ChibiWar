using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GM_SceneManager:MonoBehaviour
{
    public Button startutton;

    /// <summary>
    /// Button Listener Connect
    /// </summary>
    public void LoadScene(string LoadScene)
    {
        SceneManager.LoadScene(LoadScene, LoadSceneMode.Single);
    }

    IEnumerator SceneLoad(string _LoadSceneName)
    {
        yield return new WaitForSeconds(1.0f);
        LoadScene(_LoadSceneName);
    }


    public void Awake()
    {
        startutton = GameObject.Find("Canvas/Button").GetComponent<Button>();
        startutton.onClick.AddListener(() => StartCoroutine(SceneLoad("01_LoadingScene")));
    }
}
