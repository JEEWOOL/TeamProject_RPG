using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{    
    public void StartGame()
    {
        Debug.Log("���ӽ���");
        LoadingSceneController.LoadScene("GameClearScene1");
    }

    public void LoadGame()
    {
        Debug.Log("������");
        SceneManager.LoadScene(3);
    }

    public void ExitGame()
    {
        Debug.Log("��������");        
        Application.Quit();
    }
}
