using UnityEngine;

public class WindmillBlades : MonoBehaviour
{
    [SerializeField] private Lever _lever;

    private float _rotateSpeed;

    private void Update()
    {
        transform.Rotate(Vector3.back * _rotateSpeed * Time.deltaTime);
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
        _rotateSpeed = speed;
    }
}
