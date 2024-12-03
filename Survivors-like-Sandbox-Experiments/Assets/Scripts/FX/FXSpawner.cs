using UnityEngine;

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
