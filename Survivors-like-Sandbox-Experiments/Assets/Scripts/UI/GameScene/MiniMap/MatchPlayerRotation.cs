using UnityEngine;

/// <summary>
/// Matches rotation to Player.
/// Used for UI icon in map.
/// </summary>
public class MatchPlayerRotation : MonoBehaviour
{
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, playerTransform.rotation.z);
    }
}
