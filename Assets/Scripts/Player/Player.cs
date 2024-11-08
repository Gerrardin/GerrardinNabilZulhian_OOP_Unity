using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private PlayerMovement playerMovement;
    private Animator animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();

        // Mengakses Animator di child object "Engine -> EngineEffect"
        Transform engineEffect = transform.Find("Engine/EngineEffect");
        if (engineEffect != null)
        {
            animator = engineEffect.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Engine -> EngineEffect not found!");
        }
    }

    private void FixedUpdate()
    {
        playerMovement.Move();
    }

    private void LateUpdate()
    {
        if (animator != null)
        {
            animator.SetBool("IsMoving", playerMovement.IsMoving());
        }
    }
}
