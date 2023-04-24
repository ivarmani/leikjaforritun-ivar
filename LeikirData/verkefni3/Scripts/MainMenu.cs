using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string Level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //spila aftur
    public void PlayAgain()
    {
        SceneManager.LoadScene(Level);
    }
    // hætta leik
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
