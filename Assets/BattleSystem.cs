using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleSystem : MonoBehaviour
{
    float Player_HP = 100;
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "FirstAnemy")
        {
            Player_HP -= 0.3f;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(Player_HP<=0)
        {
            SceneManager.LoadScene("Menu");
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
