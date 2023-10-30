using Unity.VisualScripting;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static HealthSystem instance;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    [SerializeField] Rigidbody2D _playerRB;
    private GameObject _player;
    [SerializeField] private BasicPlayerMovement _playerMovement;


    private void Awake()
    {
        instance = this;
        _player = GetComponent<GameObject>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    private void Update()
    {
        //Nie zmniejszaj poniżej 0
        if (currentHealth < 0) currentHealth = 0;
        if (currentHealth <= 0)
        {
            Destroy(_playerMovement);
        }
    }

    
    public void TakeDamage(int damage, Rigidbody2D enemy)
    {
        currentHealth -= damage;
        if (enemy.transform.position.x > transform.position.x)
        {
            _playerRB.velocity = new Vector2(-1f, 5f);
        }
        else
        {
            _playerRB.velocity = new Vector2(1f, 5f);
        }
        
        healthBar.SetHealth(currentHealth);
    }
}