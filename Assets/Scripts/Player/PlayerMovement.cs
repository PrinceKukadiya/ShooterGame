using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    #region PUBLIC_VAR
#if UNITY_ANDROID
    public FixedJoystick mJoystick;
#endif
    [HideInInspector]
    public CharacterController mCharacterController;

    public float mWalkSpeed = 1.5f;
    public float mRunSpeed = 3.0f;
    public float mRotationSpeed = 50.0f;
    public float mGravity = -30.0f;

    [Tooltip("Only useful with Follow and Independent Rotation - third - person camera control")]
    public bool mFollowCameraForward = false;
    public float mTurnRate = 200.0f;

    [Header("Player")]
    public int health;
    public HealthBar healthBar;
    #endregion

    #region PRIVATE_VAR
    private Vector3 mVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    #endregion

    #region UNITY_METHOD
    // Start is called before the first frame update
    void Start()
    {
        mCharacterController = GetComponent<CharacterController>();
        healthBar.SetMaxHealth(health);
    }

    void Update()
    {
        Move();
    }
    #endregion

    #region PUBLIC_METHODS
    /// 'Hits' the target for a certain amount of damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if (health <= 0) Invoke(nameof(DestroyPlayer), 0.5f);
    }
    #endregion

    
    #region PRIVATE_METHODS

    private void DestroyPlayer()
    {
        Debug.Log("Game over");
       // Destroy(gameObject);
    }
    
    private void Move()
    {
#if UNITY_STANDALONE
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
#endif

#if UNITY_ANDROID
        float h = mJoystick.Horizontal;
        float v = mJoystick.Vertical;
#endif
#if UNITY_STANDALONE
        float speed = mWalkSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = mRunSpeed;
        }
#endif

#if UNITY_ANDROID
        float speed = mRunSpeed;
#endif

        if (mFollowCameraForward)
        {
            // Only allow aligning of player's direction when there is a movement.
            if (v > 0.1 || v < -0.1 || h > 0.1 || h < -0.1)
            {
                // rotate player towards the camera forward.
                Vector3 eu = Camera.main.transform.rotation.eulerAngles;
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.Euler(0.0f, eu.y, 0.0f),
                    mTurnRate * Time.deltaTime);
            }
        }
        else
        {
            transform.Rotate(0.0f, h * mRotationSpeed * Time.deltaTime, 0.0f);
        }

        mCharacterController.Move(transform.forward * v * speed * Time.deltaTime);

        // Move forward / backward
        Vector3 forward = transform.TransformDirection(Vector3.forward).normalized;
        forward.y = 0.0f;
        Vector3 right = transform.TransformDirection(Vector3.right).normalized;
        right.y = 0.0f;

        // apply gravity.
        mVelocity.y += mGravity * Time.deltaTime;
        mCharacterController.Move(mVelocity * Time.deltaTime);

        if (mCharacterController.isGrounded && mVelocity.y < 0)
            mVelocity.y = 0f;
    }
    #endregion

    #region COROUTINE
    #endregion

    #region DATA
    #endregion
}
