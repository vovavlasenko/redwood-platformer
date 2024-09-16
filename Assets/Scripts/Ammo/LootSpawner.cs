using UnityEngine;

public class LootSpawner : MonoBehaviour // Размещаем на каждом префабе врага
{
    [SerializeField] private GameObject _lootPrefab;
    [SerializeField] private int _chanceToSpawn;
    [SerializeField] private int _minLootAmount;
    [SerializeField] private int _maxLootAmount;

    public void SpawnLoot()
    {
        if (_chanceToSpawn > Random.Range(0, 100))
        {
            Instantiate(_lootPrefab, transform.position, Quaternion.identity);
            _lootPrefab.GetComponent<Loot>().InitializeAmount(Random.Range(_minLootAmount, _maxLootAmount + 1));
        }
    }

}
