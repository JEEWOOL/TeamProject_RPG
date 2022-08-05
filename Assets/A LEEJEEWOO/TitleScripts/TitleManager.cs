using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using HOGUS.Scripts.Manager;

public class TitleManager : MonoBehaviour
{    
    public void StartGame()
    {
        Debug.Log("���ӽ���");
        LoadingSceneController.LoadScene("MainGameScene");
    }

    public void LoadGame()
    {
        Debug.Log("������");
        SceneManager.LoadScene(3);
    }

    public void ExitGame()
    {
        Debug.Log("��������");
        GameManager.Instance.IsGameOver = true;
        Application.Quit();
    }
}
