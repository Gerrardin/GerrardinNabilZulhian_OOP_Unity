using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    [SerializeField] private Vector2 maxSpeed;
    [SerializeField] private Vector2 timeToFullSpeed;
    [SerializeField] private Vector2 timeToStop;
    [SerializeField] private Vector2 stopClamp;
    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;

    private float minX, maxX, minY, maxY;

    // Offset batas samping dan atas/bawah secara terpisah
    [SerializeField] private float leftOffset = 0.8f;
    [SerializeField] private float rightOffset = 0.8f;
    [SerializeField] private float topOffset = 1.0f; // Ubah batas atas lebih kecil
    [SerializeField] private float bottomOffset = 1.4f;
    private float playerHeight; // untuk ukuran pesawat

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);

        // Menentukan ukuran objek pesawat (jika ada Collider2D)
        if (GetComponent<Collider2D>() != null){
            playerHeight = GetComponent<Collider2D>().bounds.extents.y;
        }

        // Menentukan batas berdasarkan ukuran kamera dan offset yang berbeda
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        minX = -screenBounds.x + leftOffset;
        maxX = screenBounds.x - rightOffset;
        minY = -screenBounds.y + bottomOffset;
        maxY = screenBounds.y - topOffset; // Batas atas dengan ukuran pesawat
    }

    private void FixedUpdate(){
        Move();
        ConstrainPosition();
    }

    public void Move(){
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(inputX, inputY).normalized;
        rb.velocity = moveDirection * maxSpeed;
    }

    private void ConstrainPosition(){
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    private Vector2 GetFriction(){
        return rb.velocity.magnitude > 0 ? stopFriction : Vector2.zero;
    }

    public bool IsMoving(){
        return rb.velocity.magnitude > 0.1f;
    }
}
