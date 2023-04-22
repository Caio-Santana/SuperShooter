using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [SerializeField]
    private float amount;
    public UnityEvent onDeath;

    public float Amount { get => amount; set => amount = value; }

    private void Update()
    {
        if (Amount <= 0)
        {
            onDeath.Invoke();
            Destroy(gameObject);
        }
    }

}
