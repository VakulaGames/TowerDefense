using UnityEngine;

public class Feed : MonoBehaviour, IDamageble
{
    public void Dead()
    {
        Debug.Log("Все съели");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }
}
