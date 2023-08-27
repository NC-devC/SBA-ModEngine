using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
    public static float speed = 5.5f;
    public Rigidbody rb;
    public static float minY = -32;
    public static float maxY = 128;

    public void Die(string reason="died.")
    {
        Debug.Log(reason);
        SceneManager.LoadScene("Scenes/Menus/MainMenu");
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("win")){
            Debug.Log("win");
            SceneManager.LoadScene("Scenes/Menus/MainMenu");
        }
    }

    private void Update() {
        if(transform.position.y < minY)
        {  
            Die("fallen down.");
        }

        if(transform.position.y > maxY)
        {  
            Die("lost in space.");
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h*speed, 0, v*speed);
        rb.AddForce(movement);
    }
}