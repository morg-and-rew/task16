using System;

public class Weapon
{
    public int Damage { get; private set; }
    public int Bullets { get; private set; }

    public Weapon(int damage, int bullets)
    {
        if (damage <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(damage), "Damage must be positive.");
        }
        if (bullets < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bullets), "Bullets cannot be negative.");
        }

        Damage = damage;
        Bullets = bullets;
    }

    public void Fire()
    {
        Bullets -= 1;
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
    private Weapon _weapon;

    public Bot(Weapon weapon)
    {
        if (weapon == null)
        {
            throw new ArgumentNullException(nameof(weapon));
        }

        _weapon = weapon;
    }

    public void OnSeePlayer(Player player)
    {
        if (player == null)
            throw new ArgumentNullException(nameof(player));

        player.TakeDamage(_weapon.Damage);
        _weapon.Fire();
    }
}
