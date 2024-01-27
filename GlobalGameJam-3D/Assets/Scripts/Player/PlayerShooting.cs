using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GlobalGameJam
{
    public class PlayerShooting : MonoBehaviour
    {
        [Tooltip("Amount of ammos")]
        private int[] ammos;
        [SerializeField] private Transform muzzleTransform;
        [SerializeField] private float reloadTime;

        private PlayerInventory inventory;

        private bool canShoot = true;
        private float currentReloadTime;

        private void Awake()
        {
            inventory = GetComponent<PlayerInventory>();
        }

        private void Start()
        {
            currentReloadTime = reloadTime;
        }

        private void Update()
        {
            if (currentReloadTime > 0f)
            {
                currentReloadTime -= Time.deltaTime;
            }
            canShoot = currentReloadTime <= 0f;

            if (canShoot && Input.GetAxis("Fire1") > 0)
            {
                Shoot();
                currentReloadTime = reloadTime;
                canShoot = false;
            }
        }

        private void Shoot()
        {
            //Shooting logic
            //GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("")
        }
    }
}