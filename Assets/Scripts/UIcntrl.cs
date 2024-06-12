using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIcntrl : MonoBehaviour
{
    public Text ScrollText;
    public List<GameObject> Lives;

    int currentLiveIndex = 2;

    // Update is called once per frame
    void Update()
    {
        ScrollText.text = GameStateManager.Instance.GetCurrentScrolls().ToString("D2");
        
        int currlives = GameStateManager.Instance.GetLives();

        //check if we need to update our lives graphics
        if (currlives - 1 != currentLiveIndex)
        {
            Lives[currentLiveIndex].SetActive(false);
            if (currentLiveIndex > 0)
            {
                currentLiveIndex -= 1;
            }
        }
    }
}
