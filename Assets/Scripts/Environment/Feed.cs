using UnityEngine;

public class Feed : MonoBehaviour, IDamageble
{
    public void Dead()
    {
        Debug.Log("��� �����");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }
}
