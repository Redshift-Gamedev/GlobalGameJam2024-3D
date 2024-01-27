using UnityEngine;


namespace GlobalGameJam
{
    public enum BulletType { Beer, Wine, SuperAlcohol }

    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletType bulletType;

        [SerializeField] private float speed;

        private Rigidbody rb;

        public BulletType BulletType => bulletType;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            rb.velocity = transform.forward * speed;
        }

        private void OnDisable()
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}