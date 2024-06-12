using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameStateManager.Instance.LevelWON();
       
    }
}
