using UnityEngine;

public class Player : MonoBehaviour
{
    // This for getting the instace of Player Singleton
    public static Player Instance { get; private set; }

    // Getting the PlayerMovement methods
    PlayerMovement playerMovement;
    // Animator
    Animator animator;


    // Key for Singleton
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    // Getting Component
    void Start()
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

    // Using FixedUpdate to Move because of physics
    void FixedUpdate()
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

    private WeaponPickup currentWeaponPickup;

    public void SwitchWeapon(Weapon newWeapon, WeaponPickup newWeaponPickup)
    {
        if (currentWeaponPickup != null)
        {
            currentWeaponPickup.PickupHandler(true);  // Make the previous weapon pickup visible again
        }
        currentWeaponPickup = newWeaponPickup;
    }
}
