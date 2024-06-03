using UnityEngine;

public class Adrenaline : MonoBehaviour
{
    public float speedRot;
    public Vector3 axis;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PScoreSystem>().TakeAdrenaline();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.RotateAround(transform.position, axis, speedRot * Time.deltaTime);
    }
}