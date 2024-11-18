using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class EnemyProfile
{
    public string name;

    public float moveSpeed;
    public float health;
    public float damage;

    public GameObject enemyPrefab;
}
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public List<EnemyProfile> enemyList;
    //public List<GameObject> enemyPrefabs;

    public float outerSpawnRadius = 10f;
    public float innerSpawnRadius = 5f;  
    
    /// <summary>
    /// Returns Vector2 coordinate in 'Annular Area' (Donut)
    /// </summary>
    private Vector2 GetSpawnPointInDonut()
    {
        float angle = Random.Range(0f, Mathf.PI * 2);
        float radius = Random.Range(innerSpawnRadius, outerSpawnRadius);

        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);

        return new Vector2(x, y) + (Vector2)transform.position;
    }
    private void SpawnEnemy(int index, Vector2 pos)
    {
        EnemyProfile newEnemyProfile = enemyList[index];
        GameObject newEnemy = Instantiate(newEnemyProfile.enemyPrefab, pos, Quaternion.identity);
        EnemyBase newEnemyBase = newEnemy.GetComponent<EnemyBase>();
        newEnemyBase.health = newEnemyProfile.health;
        newEnemyBase.moveSpeed = newEnemyProfile.moveSpeed;
        newEnemyBase.damage = newEnemyProfile.damage;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) { SpawnEnemy(0, GetSpawnPointInDonut()); }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, innerSpawnRadius);
        Gizmos.DrawWireSphere(transform.position, outerSpawnRadius);
    }
}
