using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private float speed = 2f;         // Speed of the portal movement
    [SerializeField] private float rotateSpeed = 50f;  // Rotation speed of the portal
    private Vector2 newPosition;                       // Random position to move towards

    private void Start()
    {
        // Initialize position
        ChangePosition();
    }

    private void Update()
    {
        // Move the portal towards newPosition
        transform.position = Vector2.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        // Rotate the portal
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);

        // Check if close to newPosition and change position if necessary
        if (Vector2.Distance(transform.position, newPosition) < 0.5f)
        {
            ChangePosition();
        }

        // Check if the player has a weapon
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Weapon playerWeapon = player.GetComponentInChildren<Weapon>();
            bool hasWeapon = playerWeapon != null;

            // Enable or disable portal visibility and collider based on player's weapon status
            GetComponent<SpriteRenderer>().enabled = hasWeapon;
            GetComponent<Collider2D>().enabled = hasWeapon;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the portal collides with the player
        if (other.CompareTag("Player"))
        {
            // Use LevelManager to load the main scene
            GameManager.Instance.LevelManager.LoadScene("ChooseWeapon");
        }
    }

    private void ChangePosition()
    {
        // Assign a new random position within a specified range
        newPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
    }
}

