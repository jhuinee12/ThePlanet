using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public void EasyScene()
    {
        SceneManager.LoadScene("EasyScene");
    }
    public void MidScene()
    {
        SceneManager.LoadScene("MidScene");
    }
    public void HardScene()
    {
        SceneManager.LoadScene("HardScene");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("StartGame");
    }
}
