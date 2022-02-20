using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void Store()
    {
        SceneManager.LoadScene("Store");
    }

    public void Game()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Stats()
    {
        SceneManager.LoadScene("Stats");
    }
}
