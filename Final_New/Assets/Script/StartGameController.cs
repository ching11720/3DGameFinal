using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class AutoStartGame : MonoBehaviour
{
    public TextMeshProUGUI startText;

    public float waitTime = 5f; // Time to wait before transitioning to the next scene

    public AudioSource buttonClickSound;

    void Start()
    {
        Invoke("StartGame", waitTime);
    }

    void StartGame()
    {
       
    // Method to load the game scene
 
        // Play the click sound
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }

        // Load the main gameplay scene
        SceneManager.LoadScene("SampleScene");
  
     
    
    }
}
