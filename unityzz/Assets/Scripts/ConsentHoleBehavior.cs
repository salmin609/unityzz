using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsentHoleBehavior : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject[] particles;
    public float timer = 1f;
    public float fixedTimer = 1f;
    private SpriteRenderer sprite;
    public Sprite currSprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        currSprite = sprite.sprite;
    }

    void Update()
    {

    }

    void GetRandomSprite()
    {
        int randomIndex = Random.Range(0, sprites.Length);
        sprite.sprite = sprites[randomIndex];
        currSprite = sprite.sprite;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Consent")
        {
            GameObject obj = Instantiate(particles[GetRandomIndex(0, particles.Length)], transform.position, Quaternion.identity);
            Destroy(obj, 1f);
            GetRandomSprite();
        }
    }

    int GetRandomIndex(int min, int max)
    {
        return Random.Range(min, max);
    }
}
