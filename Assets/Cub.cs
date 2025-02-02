using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 2f;
    [SerializeField] private GameObject smallerObjectPrefab;
    [SerializeField] private int numberOfSmallerObjects = 3;
    [SerializeField] private float explosionForce = 5f;
    [SerializeField] private float lifetime = 5f;

    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;


        if (collider != null && collider.GetComponent<Ground>() != null)
        {
            for (int i = 0; i < numberOfSmallerObjects; i++)
            {
                Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, 0);
                GameObject smallerObject = Instantiate(smallerObjectPrefab, spawnPosition, Quaternion.identity);
                Rigidbody2D smallerRb = smallerObject.GetComponent<Rigidbody2D>();
                if (smallerRb != null)
                {
                    Vector2 direction = new Vector2(Random.Range(-1f, 1f), -1f).normalized;
                    smallerRb.AddForce(direction * explosionForce, ForceMode2D.Impulse);
                }

 
                SpriteRenderer spriteRenderer = smallerObject.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {              Color randomColor = new Color(Random.value, Random.value, Random.value);
                    spriteRenderer.color = randomColor;
                }

                Destroy(smallerObject, lifetime);
            }

            Destroy(gameObject);
        }
    }
}
