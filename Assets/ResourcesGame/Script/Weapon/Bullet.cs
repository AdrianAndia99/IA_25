using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float velocity;
    [SerializeField] private int damage;
    private Rigidbody _bulletBody;
    // Start is called before the first frame update
    private void Awake()
    {
        _bulletBody = GetComponent<Rigidbody>();
    }
    void Start()
    {
        AddVelocity();
        Destroy(this.gameObject, 2);
    }
    void AddVelocity()
    {
        _bulletBody.linearVelocity = transform.forward * velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<healthZombie>().Damage(damage, collision.gameObject.GetComponent<Health>());
            Destroy(this.gameObject);
        }
    }
}
