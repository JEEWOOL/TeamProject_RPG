using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public void OnClickNewGameButton()
    {
        Debug.Log("���� ����");
        LoadingSceneController.LoadScene("MainGame");
    }
    public void OnClickContinueButton()
    {
        Debug.Log("���� ��� ����");
        //SceneManager.LoadScene();
    }
    public void OnClickExitButton()
    {
        Debug.Log("���� ����");
        Application.Quit();
    }
}
