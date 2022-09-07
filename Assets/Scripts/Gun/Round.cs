using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    #region PUBLIC_VAR
    public int damage;
    #endregion

    #region PRIVATE_VAR
    #endregion

    #region UNITY_METHOD
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy target = other.gameObject.GetComponent<Enemy>();
            if (target)
                target.TakeDamage(damage);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement target = other.gameObject.GetComponent<PlayerMovement>();
            if (target)
                target.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
    #endregion

    #region PUBLIC_METHODS
    #endregion

    #region PRIVATE_METHODS
    #endregion

    #region COROUTINE
    #endregion

    #region DATA
    #endregion
}
