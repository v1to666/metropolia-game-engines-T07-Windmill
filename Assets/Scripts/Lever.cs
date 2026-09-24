using UnityEngine;

public class Lever : MonoBehaviour, IInteractable
{
    Quaternion[] _leverStates = new Quaternion[4]
    {
        Quaternion.Euler(0f, 0f, 0f),
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, -180f),
        Quaternion.Euler(0f, 0f, -270f),
    };

    private int _leverStateIndex = 0;

    private Quaternion _currentRotation;

    private void Start()
    {
        _currentRotation = _leverStates[_leverStateIndex];
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _currentRotation, 5f * Time.deltaTime);
    }

    public void Interact()
    {
        Debug.Log("asd");

        _leverStateIndex++;

        UpdateRotation();
    }

    private void UpdateRotation()
    {
        _currentRotation = _leverStates[_leverStateIndex % _leverStates.Length];
    }
}
