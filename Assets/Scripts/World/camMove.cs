using UnityEngine;

public class camMove : MonoBehaviour
{
    public float cameraSpeed;




    private void Update()
    {
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0); //constatly moves the camera to the right of the screen 
    }






}
