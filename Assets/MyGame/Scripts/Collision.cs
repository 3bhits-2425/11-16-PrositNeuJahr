using UnityEngine;

public class GiftCollision : MonoBehaviour
{
    public GameObject rocketPrefab;
    public string cameraTag = "MainCamera"; // Der Tag, über den die Kamera gefunden wird
    public float transitionSpeed = 5f;
    public Vector3 targetPosition = new Vector3(-40f, 10f, -10f); // Zielposition der Kamera
    public float resetDelay = 4f;

    private Camera mainCamera;
    private Vector3 originalPosition;
    private bool moveToTarget = false;
    private bool moveToOriginal = false;
    private float timer = 0f;

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

            moveToTarget = true;
            timer = 0f;
        }
    }

    private void Update()
    {
        if (mainCamera == null) return;

        if (moveToTarget)
        {
            mainCamera.transform.position = Vector3.Lerp(
                mainCamera.transform.position, targetPosition, Time.deltaTime * transitionSpeed);

            if (Vector3.Distance(mainCamera.transform.position, targetPosition) < 0.1f)
            {
                moveToTarget = false;
                moveToOriginal = true;
                timer = 0f;
            }
        }

        if (moveToOriginal)
        {
            timer += Time.deltaTime;

            if (timer >= resetDelay)
            {
                mainCamera.transform.position = Vector3.Lerp(
                    mainCamera.transform.position, originalPosition, Time.deltaTime * transitionSpeed);

                if (Vector3.Distance(mainCamera.transform.position, originalPosition) < 0.1f)
                {
                    moveToOriginal = false;
                }
            }
        }
    }
}
