using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private float fireRate;

    [SerializeField]
    private AudioSource shootSound;

    [SerializeField]
    private ParticleSystem muzzleEffect;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private GameObject shootPoint;

    [SerializeField]
    private int bulletsAmount;

    private Animator animator;

    private float lastShootTime;

    public int BulletsAmount { get => bulletsAmount; set => bulletsAmount = value; }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bulletsAmount > 0 && Time.timeScale > 0)
        {
            animator.SetBool("Shooting", true);

            var timeSinceLastShoot = Time.time - lastShootTime;
            if (timeSinceLastShoot < fireRate)
            {
                return;
            }

            lastShootTime = Time.time;

            bulletsAmount--;
            muzzleEffect.Play();
            shootSound.Play();

            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
        }    
        else
        {
            animator.SetBool("Shooting", false);
        }
    }
}
