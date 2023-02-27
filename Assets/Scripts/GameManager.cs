using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool ifGameOver = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && ifGameOver == true)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void GameOver()
    {
        ifGameOver = true;
    }
}
