using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
   public int sceneNum;
   public void SwitchScene()
    {
        SceneManager.LoadScene(sceneNum);
    }
}
