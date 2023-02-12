using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public void TutorialBtn()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadStage(string StageName)
    {
        SceneManager.LoadScene(StageName);
    }
}
