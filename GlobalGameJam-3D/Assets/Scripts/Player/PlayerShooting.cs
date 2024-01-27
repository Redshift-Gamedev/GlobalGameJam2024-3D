using UnityEngine;

namespace GlobalGameJam
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private string[] ammoTags = { "BeerBullet", "WineBullet", "SuperAlcoholBullet" };
        [SerializeField] private Transform muzzleTransform;
        [SerializeField] private float reloadTime;
        [Header("Raycast")]
        [SerializeField] private float range = 100;
        [SerializeField] private LayerMask layerMask;

        private PlayerInventory inventory;
        private Camera cam;

        private bool canShoot = true;
        private float currentReloadTime;



        private void Awake()
        {
            inventory = GetComponent<PlayerInventory>();
            cam = Camera.main;
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
            //Orientate Muzzle towards aim point
            Ray ray = new(cam.transform.position, cam.transform.forward);
            {
                Vector3 aimPoint;
                if (Physics.Raycast(ray, out RaycastHit info, range, layerMask))
                {
                    aimPoint = info.point;
                }
                else
                {
                    aimPoint = ray.GetPoint(range);
                }

                muzzleTransform.LookAt(aimPoint);
            }

            //Shooting logic
            int ammoTypeIndex = inventory.TakeAmmo();
            if (ammoTypeIndex >= 0)
            {
                GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(ammoTags[ammoTypeIndex]);
                bullet.transform.position = muzzleTransform.position;
                bullet.transform.rotation = muzzleTransform.rotation;
                bullet.SetActive(true);
            }
            else
            {
                Debug.Log("Ammo Empty");
            }
        }
    }
}