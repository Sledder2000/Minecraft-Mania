using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public List<Combatant> Combatants { get; private set; } = new();
    public List<Player> Players { get; private set; } = new();
    public List<Enemy> Enemies { get; private set; } = new();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginCombat(List<Player> players, List<Enemy> enemies)
    {
        Players = players;
        Enemies = enemies;
        foreach (Player p in players)
        {
            Combatants.Add(p.gameObject.GetComponent<Combatant>());
        }
        foreach (Enemy e in enemies)
        {
            Combatants.Add(e.gameObject.GetComponent<Combatant>());
        }
        Combatants.Sort();
    }
}
