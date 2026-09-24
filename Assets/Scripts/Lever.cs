using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour, IInteractable
{
    public event UnityAction<float> OnInteract;

    Quaternion[] _leverStates = new Quaternion[4]
    {
        Quaternion.Euler(0f, 0f, 0f),
        Quaternion.Euler(0f, 0f, -90f),
        Quaternion.Euler(0f, 0f, -180f),
        Quaternion.Euler(0f, 0f, -270f),
    };

    float[] _bladeSpeeds = new float[4]
    {
        0f,
        100f,
        1000f,
        10000f
    };

    private int _leverStateIndex = 0;

    private Quaternion _currentRotation;

    private void Start()
    {
        _currentRotation = _leverStates[_leverStateIndex];

        OnInteract?.Invoke(_bladeSpeeds[_leverStateIndex % _leverStates.Length]);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _currentRotation, 5f * Time.deltaTime);
    }

    public void Interact()
    {
        _leverStateIndex = (_leverStateIndex + 1) % _leverStates.Length;

        _currentRotation = _leverStates[_leverStateIndex];

        float speed = _bladeSpeeds[_leverStateIndex];

        Debug.Log($"State: {_leverStateIndex}, Speed: {speed}");

        OnInteract?.Invoke(speed);
    }

    private void UpdateRotation()
    {
        _currentRotation = _leverStates[_leverStateIndex % _leverStates.Length];
    }
}
