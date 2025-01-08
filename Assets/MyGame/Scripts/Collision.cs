using UnityEngine;

public class GiftCollision : MonoBehaviour
{
    public GameObject rocketPrefab;
    public string cameraTag = "MainCamera"; 
    public float transitionSpeed = 5f;
    public Vector3 targetPosition = new Vector3(-40f, 10f, -10f);  // Provisorische Position
    public float resetDelay = 4f;

    private Camera mainCamera;
    private Vector3 originalPosition;
    
    

    private void Start()
    {
        GameObject cameraObject = GameObject.FindWithTag(cameraTag);
        if (cameraObject != null)
        {
            mainCamera = cameraObject.GetComponent<Camera>();
            originalPosition = mainCamera.transform.position;
        }
        else
        {
            Debug.LogError("Keine Kamera mit dem angegebenen Tag gefunden: " + cameraTag);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Snowman"))
        {
            Destroy(gameObject);

            if (rocketPrefab != null)
            {
                Instantiate(rocketPrefab, transform.position, Quaternion.identity);
            }

           
       
        }
    }

    private void Update()
    {
        
    }
}
