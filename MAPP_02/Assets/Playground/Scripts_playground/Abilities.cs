using System.Collections.Generic;

public static class Abilities
{
    private static Dictionary<int, Ability> allAbilities = new Dictionary<int, Ability>();

    public static void Initialize()
    {
        // Add all abilities here with allAbilities.add(<the ability ID>, new <the ability>)
        allAbilities.Add(0, new Ability_Fireball("Fireball", 0));
    }

    public static Ability GetAbility(int id)
    {
        return allAbilities[id]; // Returns the Ability with ID id from allAbilities;
    }
}
