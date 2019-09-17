using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int startingAmount = 100;
    private int currentAmount;
    public int scoreValue = 10;
    public GameObject explosion;

    private PlayerScript player;

    private bool isDead;

    private void Awake()
    {
        isDead = false;
        currentAmount = startingAmount;

        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

    public void TakeDamage(int hitAmount)
    {
        if (isDead)
            return;

        currentAmount -= hitAmount;

        if (currentAmount <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (tag == "Asteroid")
        {
            player.AddScore(scoreValue);
        }
        isDead = true;
        if (tag == "Player")
        {
            FindObjectOfType<GameManager>().EndGame();
        }
        Destroy(gameObject);
    }
}
