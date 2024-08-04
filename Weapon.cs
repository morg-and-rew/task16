using System;

public class Weapon
{
    public Weapon(int damage, int bullets)
    {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage), "Damage must be positive.");

        if (bullets < 0)
            throw new ArgumentOutOfRangeException(nameof(bullets), "Bullets cannot be negative.");

        Damage = damage;
        Bullets = bullets;
    }

    public int Damage { get; private set; }
    public int Bullets { get; private set; }

    public void Fire(Player player)
    {
        if (player == null)
            throw new ArgumentNullException(nameof(player));

        if (Bullets <= 0)
            throw new InvalidOperationException("Cannot fire: No bullets left.");

        player.TakeDamage(Damage);
        Bullets--;
    }

}

public class Player
{
    private int _health;

    public Player(int health)
    {
        if (health <= 0)
            throw new ArgumentOutOfRangeException(nameof(health), "Health must be positive.");

        _health = health;
    }

    public int Health => _health; 

    public void TakeDamage(int damage)
    {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException(nameof(damage), "Damage must be positive.");

        _health -= damage;

        if (_health < 0) 
            _health = 0;
    }
}

public class Bot
{
    private readonly Weapon _weapon;

    public Bot(Weapon weapon)
    {
        _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
    }

    public void OnSeePlayer(Player player)
    {
        if (player == null)
            throw new ArgumentNullException(nameof(player));

        _weapon.Fire(player);
    }
}
