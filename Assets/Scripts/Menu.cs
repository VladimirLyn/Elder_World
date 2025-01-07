using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       Cursor.lockState = CursorLockMode.Confined;
       Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void New_Game()
    {
        SceneManager.LoadScene("First_Level");
    }
}
