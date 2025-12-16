using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class EscapeMenu : MonoBehaviour
{
    public GameObject escapemenu;
    public GameObject escapemenubackground;
    public GameObject settingsmenu;
    public GameObject resume;

    public void MainMenu()
    {
        Time.timeScale = 1;
        escapemenu.SetActive(false);
        escapemenubackground.SetActive(false);
        IsEscaped = false;
        SceneManager.LoadScene("Title_Screne");
    }
    public void Resume()
    {
        escapemenu.SetActive(false);
        escapemenubackground.SetActive(false);
        IsEscaped = false;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    // has escape menu open
    private bool IsEscaped = false;
    // is selected in escape menu not using mouse
    private bool IsSelected = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && IsEscaped == true)
        {
            EventSystem.current.SetSelectedGameObject(resume);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && IsEscaped == false)
        {
            escapemenu.SetActive(true);
            escapemenubackground.SetActive(true);
            IsEscaped = true;
            Time.timeScale = 0;
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && IsEscaped == true)
        {
            escapemenu.SetActive(false);
            escapemenubackground.SetActive(false);
            settingsmenu.SetActive(false);
            IsEscaped = false;
            Time.timeScale = 1;
        }
    }
}
