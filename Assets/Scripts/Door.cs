using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _animator.SetBool("DoorOpened", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            _animator.SetBool("DoorOpened", false);
        }
    }
}
