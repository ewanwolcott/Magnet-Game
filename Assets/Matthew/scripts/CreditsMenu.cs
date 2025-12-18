using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Title_Screne");
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title_Screne");
        }
    }
}
