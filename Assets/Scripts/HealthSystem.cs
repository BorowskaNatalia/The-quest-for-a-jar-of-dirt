using Unity.VisualScripting;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static HealthSystem Instance;
    public int maxHealth = 100;
    public int currentHealth;
    internal bool IsDead;
    internal bool IsHit;

    public HealthBar healthBar;
    
    [SerializeField] private BasicPlayerMovement _playerMovement;


    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        //Check if dead
        if (currentHealth <= 0)
            IsDead = true;

        //Nie zmniejszaj poniżej 0
        if (currentHealth < 0) currentHealth = 0;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        if (currentHealth <= 0) Destroy(_playerMovement);
    }


    public void TakeDamage(int damage)
    {
        //Update health
        currentHealth -= damage;
        //Update healthbar
        healthBar.SetHealth(currentHealth);
        //Update isHit field
        IsHit = true;

        
    }

    public void Heal(int healSize)
    {
        currentHealth += healSize;
        healthBar.SetHealth(currentHealth);
    }
}