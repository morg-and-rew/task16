public class Weapon
{
    public int Damage { get; private set; }
    public int Bullets { get; private set; }

    public Weapon(int damage, int bullets)
    {
        Damage = damage;
        Bullets = bullets;
    }

    public void Fire(int Bullet)
    {
        if (Bullets > 0)        
            Bullets--;
    }
}

public class Player
{
    private int Health;

    public Player(int health)
    {
        Health = health;
    }

    private void TakeDamage(int damage)
    {
        Health -= damage;

        if (Health < 0) 
            Health = 0; 
    }

    public int GetHealth()
    {
        return Health;
    }
}

public class Bot
{
    private void OnSeePlayer(Player player, Weapon weapon)
    {
        player.TakeDamage(weapon.Damage);
        weapon.Fire(weapon.Bullets);
    }
}