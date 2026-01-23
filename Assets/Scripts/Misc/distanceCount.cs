using UnityEngine;
using UnityEngine.UI;

public class distanceCount : MonoBehaviour
{
    public Text distanceText;
    private float distance = 0f;

    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            distance += 12 * Time.deltaTime;
            distanceText.text = distance.ToString() + "M";

        }
    }


}
