using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFood : Item
{
    [SerializeField] float Food;
    [SerializeField] int heal;
    // Start is called before the first frame update
    void Start()
    {
        base.LoadArrayRate();
    }

    // Update is called once per frame
    void Update()
    {
        if(FrameRate>Rate && !Infinity)
        {
            DestroyItem();
        }
        FrameRate += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.layer == (int)Mathf.Log(layerCollider.value,2))
        {
            healthHuman _healthHuman = other.gameObject.GetComponent<healthHuman>();

            if (other.gameObject.CompareTag("Civil") || other.gameObject.CompareTag("Soldier") && this.gameObject.CompareTag("Cookie"))
            {
                other.gameObject.GetComponent<Health>().Heal(heal, other.gameObject.GetComponent<Health>());
            }
            if (other.gameObject.CompareTag("Civil") || other.gameObject.CompareTag("Soldier") && this.gameObject.CompareTag("Cake"))
            {
                _healthHuman.SetFood(Food);
                other.gameObject.GetComponent<Health>().Heal(heal, other.gameObject.GetComponent<Health>());
            }
            if (other.gameObject.CompareTag("Civil") || other.gameObject.CompareTag("Soldier") && this.gameObject.CompareTag("Bread"))
            {
                _healthHuman.SetFood(Food);
            }
            DestroyItem();
        }
    }
}
