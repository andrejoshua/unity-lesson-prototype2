using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public GameObject projectile;
    
    private const float speed = 15.0f;
    private const float maxOffset = 11.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        Debug.Log($"Horizontal input received: {horizontalInput}");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (transform.position.x < -maxOffset)
        {
            // Add left boundary
            transform.position = new Vector3(-maxOffset, transform.position.y, transform.position.z);
        }

        if (transform.position.x > maxOffset)
        {
            // Add right boundary
            transform.position = new Vector3(maxOffset, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Launch projectile
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }
    }
}