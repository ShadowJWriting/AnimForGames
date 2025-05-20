using System;
using UnityEngine;
using UnityEngine.Events;

public class DamageHitbox : MonoBehaviour
{

    [Serializable]
    public class AttackQueueEvent : UnityEvent<DamageMessage>
    {

    }

    [SerializeField] private float defenseMultiplier = 1.0f;

    public AttackQueueEvent onHit;

    public void ReceiveDamage(DamageMessage damage)
    {
        if (damage.sender == transform.root.gameObject)
        {
            return;
        }
        damage.amount = damage.amount * defenseMultiplier;
        onHit?.Invoke(damage);
        Debug.Log($"Received damage ({damage.amount})");
    }
}
