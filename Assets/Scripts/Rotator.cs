
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _degrees;

    // Update is called once per frame
    void Update()
    {
        float rotAmount = _degrees * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, curRot + rotAmount));
    }
}

