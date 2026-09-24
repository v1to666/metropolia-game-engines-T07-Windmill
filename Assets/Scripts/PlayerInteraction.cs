using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private IInteractable _currentInteractable;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 5f))
        {
            if (raycastHit.collider.TryGetComponent(out IInteractable interactable))
            {
                _currentInteractable = interactable;
            }
            else
            {
                _currentInteractable = null;
            }
        }
        else
        {
            _currentInteractable = null;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentInteractable == null)
            {
                return;
            }

            _currentInteractable.Interact();
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * 5f);
    }
}
