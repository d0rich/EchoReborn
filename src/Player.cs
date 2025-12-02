class Player
{
    public string Name { get; }
    public int HP { get; private set; }

    public Player(string name, int hp)
    {
        Name = name;
        HP = hp;
    }

    public void Initialize()
    {
        Console.WriteLine($"{Name} is ready! ({HP} HP)");
    }

    public Action ChooseAction()
    {
        Console.WriteLine("Player attacks!");
        return new Action("Attack", 20);
    }

    public void TakeDamage(int dmg)
    {
        HP -= dmg;
        Console.WriteLine($"{Name} takes {dmg} damage! ({HP} HP left)");
    }

    public bool IsAlive() => HP > 0;
}