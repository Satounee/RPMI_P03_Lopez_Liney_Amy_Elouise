using UnityEngine;

public class PlayerCard : MonoBehaviour
{
    public AudioSource takeCardAS;
    public AudioSource dropCardAS;

    public GameObject combatSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z= 0;
        transform.position = newPosition;
    }

    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "Selected Cards";
        GetComponent<BoxCollider2D>().enabled = true;

        if (!takeCardAS.isPlaying)
        {
            takeCardAS.pitch = Random.Range(0.95f, 1.05f);
            takeCardAS.Play();
        }
    }

    private void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().sortingLayerName = "Default";
        GetComponent<BoxCollider2D>().enabled = false;

        if (!dropCardAS.isPlaying)
        {
            dropCardAS.pitch = Random.Range(0.95f, 1.05f);
            dropCardAS.Play(); 
        }  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
           if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!collision.gameObject.GetComponent<EnemyCard>().inCombat)
            {
                GameObject cs = Instantiate(combatSystem, transform.position, Quaternion.identity); // cs de combat system
                cs.GetComponent<CombatSystem>().playerCard = GetComponent<CardStats>();
                cs.GetComponent<CombatSystem>().enemyCard = collision.gameObject.GetComponent<CardStats>();
            }
        }
    }
}

