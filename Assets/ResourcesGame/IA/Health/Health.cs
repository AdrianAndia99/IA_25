using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public enum TypeAgent { A, B, C, D, E }
public enum UnitGame
{
    Thief,
    Soldier,
    Civil,
    None
}
public class Health : MonoBehaviour
{

    [Header("imageUI")]
    public Image HealthBarLocal;

    [Header("CountHealth")]
    public int health;
    public int healthMax;

    public bool IsDead { get => (health <= 0); }

    [Header("AimOffSet")]
    public Transform AimOffset;
    public Health HurtingMe;

    [Header("Type Agent")]
    public TypeAgent typeAgent;
    [Header("Type List Agent Allies")]
    public List<TypeAgent> typeAgentAllies = new List<TypeAgent>();
    Coroutine HurtingMeroutine;

    public bool Importal = false;
    public UnitGame _UnitGame;
    public bool IsCantView=true;
    [Header("Death Event")]
    public UnityEvent OnDead;
    IEnumerator HurtingMeActive(Health enemy)
    {
        HurtingMe = enemy;
        yield return new WaitForSeconds(3);
        HurtingMe = null;
        StopCoroutine(HurtingMeroutine);
    }
    public virtual void Dead()
    {
        OnDead?.Invoke();
        Destroy(this.gameObject,5); // o puedes hacer override en herencias para animaciones
    }
    public virtual void Damage(int damage,Health enemy)
    {
        
        if (Importal) return;

        if (!IsDead)
        {
            health = Mathf.Clamp(health - damage, 0, healthMax);
             
            
            UpdateHealthBar();
            if (enemy != null)
                HurtingMeroutine = StartCoroutine(HurtingMeActive(enemy));
        }
        else { Destroy(this.gameObject); }
    }
    public virtual void Heal(int heal, Health Target)
    {
        if(Importal) return;
        
        if (!IsDead)
        {
            if(health > 0)
            {
                health += heal;
                if (health == 100)
                {
                    health = 100;
                }
            }
            UpdateHealthBar();
        }
    }
    
    public void UpdateHealthBar()
    {
        if (HealthBarLocal != null)
        {
            float h = ((float)((float)health / (float)healthMax));
            HealthBarLocal.fillAmount = h;
        }
    }

    public virtual void LoadComponent()
    {
        health = healthMax;
    }
}
