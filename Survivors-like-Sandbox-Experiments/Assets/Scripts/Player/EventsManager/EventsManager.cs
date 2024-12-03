using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;

public class EventsManager : MonoBehaviour
{
    public UnityEvent EnemyHit;
    private GameObject fxOBJ;

    private void Start()
    {
        fxOBJ = GameObject.FindGameObjectWithTag("playerWeaponFX");
        EnemyHit.AddListener(() => fxOBJ.SetActive(true));

        fxOBJ.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHit.Invoke();
        }
    }
}
