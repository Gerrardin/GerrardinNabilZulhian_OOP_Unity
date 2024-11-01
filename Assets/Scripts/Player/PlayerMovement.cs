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

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
    }

    private void FixedUpdate(){
        Move();
    }

    public void Move(){
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        moveDirection = new Vector2(inputX, inputY).normalized;
        rb.velocity = moveDirection * maxSpeed;
    }

    private Vector2 GetFriction(){
        return rb.velocity.magnitude > 0 ? stopFriction : Vector2.zero;
    }

    public bool IsMoving(){
        return rb.velocity.magnitude > 0.1f;
    }
}