using UnityEngine;
using UnityEngine.SceneManagement; 

public class GiftCollision : MonoBehaviour
{
    public GameObject rocketPrefab; 
    public string nextSceneName = "NewYear"; 
    private int giftsCollected = 0; 
    public int requiredGifts = 2; 

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Snowman"))
        {
            HandleSnowmanCollision();
        }

        
        if (collision.gameObject.CompareTag("Gift"))
        {
            HandleGiftCollision();
        }
    }

    private void HandleSnowmanCollision()
    {
        Destroy(gameObject); 
        Debug.Log("Schneemann getroffen!");
        if (rocketPrefab != null)
        {
            Instantiate(rocketPrefab, transform.position, Quaternion.identity);
            Debug.Log("Rakete erzeugt!");
        }
    }

    private void HandleGiftCollision()
    {
        Debug.Log("Geschenk getroffen!");
        giftsCollected++; 
        Debug.Log("Geschenke gesammelt: " + giftsCollected);
        Destroy(gameObject); 

       
        if (giftsCollected >= requiredGifts)
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        Debug.Log("Szenenwechsel wird ausgelöst.");
        SceneManager.LoadScene(nextSceneName); 
    }

}
