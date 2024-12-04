using UnityEngine;

/// <summary>
/// Turned into class that holds animation events.
/// Sits on animated game object. For enabling FX objects and disabling at end.
/// </summary>
public class FXSpawner : MonoBehaviour
{
    [SerializeField] GameObject fxObject;

    private void Start()
    {
        //DisableOBJ();
    }
    public void DisableOBJ()
    {
        fxObject.SetActive(false);
    }
    public void EnableFXOBJ()
    {
        fxObject.SetActive(true);
    }

    
}
