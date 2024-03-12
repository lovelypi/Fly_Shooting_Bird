using System;
using GameTool;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviour
{
    [SerializeField] private Button leftBtn;
    [SerializeField] private Button rightBtn;
    [SerializeField] private Button playBtn;

    private void Awake()
    {
        playBtn.onClick.AddListener(() =>
        {
            LoadSceneManager.Instance.LoadScene("Game");
        });
    }
}
