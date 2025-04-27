using UnityEngine;

public class SnailRemover : MonoBehaviour
{
    [SerializeField] private GameObject snailPrefab;

    public void InactiveSnai()
    {
        snailPrefab.SetActive(false);
    }
}
