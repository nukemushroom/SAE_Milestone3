using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BTNManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewLevelBtn(string newLevel)
    {
        SceneManager.LoadScene(newLevel);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}