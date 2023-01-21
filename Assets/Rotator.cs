
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _degrees;

    // Update is called once per frame
    void Update()
    {
        float rotAmount = _degrees * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));
    }
}

