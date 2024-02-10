using UnityEngine;
using System.Collections;

public class EnableAndRotateObjectOnClick : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject objectToRotate;
    public float rotationSpeed = 5f;
    public Vector3 newTargetRotation = new Vector3(0f, 90f, 0f); // Initial target rotation

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position to detect the object
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the object with a Box Collider
            if (Physics.Raycast(ray, out hit) && hit.collider == GetComponent<BoxCollider>())
            {
                // Enable the target GameObject
                if (targetObject != null)
                {
                    targetObject.SetActive(true);
                }

                // Rotate the specified object smoothly to the new target rotation
                if (objectToRotate != null)
                {
                    StartCoroutine(RotateObjectSmoothly(objectToRotate.transform, newTargetRotation, rotationSpeed));
                }
            }
        }
    }

    IEnumerator RotateObjectSmoothly(Transform objTransform, Vector3 targetRotation, float speed)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime * speed;
            objTransform.rotation = Quaternion.Lerp(objTransform.rotation, Quaternion.Euler(targetRotation), t);
            yield return null;
        }
    }
}
