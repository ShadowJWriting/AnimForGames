using UnityEngine;

public class Hitbox : MonoBehaviour, IDamageSender<DamageMessage>
{
    [SerializeField] private DamageMessage damageMessage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageReciever<DamageMessage> receiver))
        {
            SendDamage(receiver);
        }
    }

    public void SendDamage(IDamageReciever<DamageMessage> receiver)
    {
        receiver.RecieveDamage(damageMessage);
    }
}
