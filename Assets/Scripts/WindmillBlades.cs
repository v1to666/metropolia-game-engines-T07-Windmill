using UnityEngine;

public class WindmillBlades : MonoBehaviour
{
    [SerializeField] private Lever _lever;

    private float _rotateSpeed;
    private float _targetSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.back * _rotateSpeed * Time.deltaTime);

        _rotateSpeed = Mathf.Lerp(_rotateSpeed, _targetSpeed, 5f * Time.deltaTime);

        Debug.Log(_rotateSpeed);
    }

    private void OnEnable()
    {
        _lever.OnInteract += UpdateSpeed;
    }

    private void OnDisable()
    {
        _lever.OnInteract += UpdateSpeed;
    }

    private void UpdateSpeed(float speed)
    {
        _targetSpeed = speed;
    }
}
