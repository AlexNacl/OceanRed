using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPlayer : MonoBehaviour
{
    [SerializeField] private FOV fieldOfView;
    private Transform aimTransform;

    private void Awake () 
    {
        aimTransform = transform.Find("Aim");
    } 

    private void Update ()
    {
        Aiming();
    }

    private void Aiming ()
    {
        Vector3 mousePosition = GetMouseWorldPosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        Vector3 aimlocalScale = Vector3.one;
        if (angle > 90 || angle < -90){
            //aimlocalScale.y = -1f;
            //PlayerMovementHuman.FlipCharacterDirection();
        } else {
            //aimlocalScale.y = +1f;
            //PlayerMovementHuman.FlipCharacterDirection();
        }
        aimTransform.localScale = aimlocalScale;

        fieldOfView.SetAimDirection(aimDirection);
        fieldOfView.SetOrigin(transform.position);
    }

    private static Vector3 GetMouseWorldPosition(){
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    private static Vector3 GetMouseWorldPositionWithZ() {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }

    private static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera) {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    private static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera) {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
