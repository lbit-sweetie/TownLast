using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EAttack : MonoBehaviour
{
    private Coroutine aCoroutine = null;
    private WaitForSeconds wait;
    public float waitTime;
    public float damage;
    private void Start()
    {
        wait = new WaitForSeconds(waitTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (aCoroutine == null)
            {
                aCoroutine = StartCoroutine(Attack(other.gameObject.GetComponent<PHeathSystem>()));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (aCoroutine != null)
            {
                StopCoroutine(aCoroutine);
                aCoroutine = null;
            }
        }
    }

    IEnumerator Attack(PHeathSystem pHeathSystem)
    {
        while (true)
        {
            pHeathSystem.TakeDamage(damage);
            yield return wait;
        }
    }
}