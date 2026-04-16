using UnityEngine;

public class CardStats : MonoBehaviour
{
    [SerializeField, Tooltip("Ataque de la carta diousa"), Range(1,50)]
    private int attack;


    public int GetAttack()
    {
        return attack;
    }
}
