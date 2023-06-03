using UnityEngine;

public class Sweets : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private void Update()
    {
        transform.position += new Vector3(0, -1, 0) * _speed * Time.deltaTime;
    }

}
