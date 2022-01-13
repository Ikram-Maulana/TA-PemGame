using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //namespace ini kita butuhkan agar dapat memanggil fungsi yang ada pada class SceneManagement
 
public class MainMenu : MonoBehaviour {
 
    void Start () {
       
    }
   
    void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Game Quit");
        }
    }
 
    public void PlayButton()
    {
      SceneManager.LoadScene("PlayScene");
      Debug.Log("Play Scene Loaded");
    }

    public void AboutButton()
    {
      SceneManager.LoadScene("AboutScene");
      Debug.Log("About Scene Loaded");
    }

    public void BackToMenuButton()
    {
      Debug.Log("Menu Scene Loaded");
      SceneManager.LoadScene("MenuScene");
    }

    public void QuitButton()
    {
      Application.Quit();
      Debug.Log("Game Quit");
    }
}