using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    #region PUBLIC_VAR
    public Gun gun;
    public int shootButton;
    public KeyCode reloadKey;
    #endregion

    #region PRIVATE_VAR
    #endregion

    #region UNITY_METHOD
    void Update()
    {
        if (Input.GetMouseButton(shootButton))
        {
            gun.Shoot();
        }

        if (Input.GetKeyDown(reloadKey))
        {
            gun.Reload();
        }
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
