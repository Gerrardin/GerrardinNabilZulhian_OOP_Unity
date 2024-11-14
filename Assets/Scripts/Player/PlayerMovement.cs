using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Vector2 maxSpeed;
    [SerializeField] private Vector2 timeToFullSpeed;
    [SerializeField] private Vector2 timeToStop;
    [SerializeField] private Vector2 stopClamp;
    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;

    private Vector2 minBounds;
    private Vector2 maxBounds;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);

        // Menentukan batas pergerakan dari kamera
        Camera cam = Camera.main;
        minBounds = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        maxBounds = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
    }

    public void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(inputX, inputY).normalized;

        rb.velocity = moveDirection * maxSpeed;

        float clampedX = Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y);
        transform.position = new Vector2(clampedX, clampedY);
    }

    private Vector2 GetFriction()
    {
        return rb.velocity.magnitude > 0 ? stopFriction : Vector2.zero;
    }

    public bool IsMoving()
    {
        return rb.velocity.magnitude > 0.1f;
    }
}
