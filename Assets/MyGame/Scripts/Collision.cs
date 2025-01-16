using UnityEngine;
using UnityEngine.SceneManagement;

public class GiftCollision : MonoBehaviour
{
    public GameObject rocketPrefab;
    public string nextSceneName = "NewYear";
    private int giftsCollected = 0;
    public int requiredGifts = 4; 

    private void OnCollisionEnter(Collision collision)
    {
       

        
        if (collision.gameObject.CompareTag("Gift"))
        {
            HandleGiftCollision(collision.gameObject);
        }

        
        
    }

    private void HandleGiftCollision(GameObject gift)
    {
        Debug.Log("Geschenk getroffen!");

        
        Destroy(gift);
        Debug.Log("Geschenk wurde entfernt.");


        
        giftsCollected++;
        Debug.Log("Geschenke gesammelt: " + giftsCollected + "/" + requiredGifts);


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
