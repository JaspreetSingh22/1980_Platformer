using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    
    public void Load(string level)
    {
        
        SceneManager.LoadScene(level);      
    }
    public void Quit()
    {
        Debug.Log("Quit");
        
        Application.Quit();
    }
    public void Credits(Image CreditImage)
    {
        CreditImage.gameObject.SetActive(true);
        Debug.Log("Credits");
    }
    public void Help()
    {
        Debug.Log("Help");
    }
    public void CloseCredit(Image CreditImage)
    {
        CreditImage.gameObject.SetActive(false);
    }
}
