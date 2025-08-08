using Pattern.Factory;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    private MonsterFactory currentFactory;
    private Monster currentMonster;

    private GoblinFactory goblinFactory;
    private OrcFactory orcFactory;

    private void Awake()
    {
        goblinFactory = new GameObject("Goblin Factory").AddComponent<GoblinFactory>();
        orcFactory = new GameObject("Orc Factory").AddComponent<OrcFactory>();
    }


    private void Start()
    {
        currentFactory = goblinFactory;
        currentMonster = currentFactory.SpawnMonster("Normal");
        currentMonster = currentFactory.SpawnMonster("Warrior");
        currentMonster = currentFactory.SpawnMonster("Archer");

        currentFactory = orcFactory;
        currentMonster = currentFactory.SpawnMonster("Normal");
        currentMonster = currentFactory.SpawnMonster("Warrior");
        currentMonster = currentFactory.SpawnMonster("Archer");
    }
}
