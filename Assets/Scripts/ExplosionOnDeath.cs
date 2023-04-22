using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionOnDeath : MonoBehaviour
{

    [SerializeField]
    private GameObject particlePrefab;

    // Start is called before the first frame update
    void Awake()
    {
        var life = GetComponent<Life>();
        life.onDeath.AddListener(onDeath);
    }

    void onDeath()
    {
        Instantiate(particlePrefab, transform.position, transform.rotation);
    }
}
