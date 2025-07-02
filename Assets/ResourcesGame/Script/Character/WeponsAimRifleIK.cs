using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponsAimRifleIK : MonoBehaviour
{
    private bool isAiming = false;
    public Transform Aim;
    public Transform Idle;
    public float speed;
    public ThirdPersonAnimationSoldier _TPSoldier;
    public IKMarine ik;
    Rigidbody rb;
    Collider _collider;
    bool Active=true;
    // Update is called once per frame
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }
    private void Start()
    {
        if (_TPSoldier == null && ik == null) return;

        if (_TPSoldier.isAiming)
        {
            LerpWeapons(Aim);
            ik.IKActive = true;
        }
        else
        {
            ik.IKActive = false;
            LerpWeapons(Idle);
        }
    }
    void Update()
    {
        if (_TPSoldier == null && ik == null && !Active) return;
        
        if (_TPSoldier.Aiming)
        {
            LerpWeapons(Aim);
            ik.IKActive = true;
        }
        else
        {
            ik.IKActive = false;
            LerpWeapons(Idle);
        }
    }
    public void DeadNPC()
    {
        rb.isKinematic = false;
        _collider.enabled = true;
        rb.AddForce(Vector3.up*10);
        Active = false;

    }
    private void LerpWeapons(Transform lerpTransform)
    {
        transform.parent = lerpTransform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
