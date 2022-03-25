using System.Collections;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
    public void ReturnToPool(float delay)
    {
        StartCoroutine(DelayReturn(delay));
    }

    private IEnumerator DelayReturn(float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnToPool();
    }
}
