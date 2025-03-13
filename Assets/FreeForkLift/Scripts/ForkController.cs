using UnityEngine;

public class ForkController : MonoBehaviour {

    public Transform fork; 
    public Transform mast;
    public float speedTranslate; //Platform travel speed
    public Vector3 maxY; //The maximum height of the platform
    public Vector3 minY; //The minimum height of the platform
    public Vector3 maxYmast; //The maximum height of the mast
    public Vector3 minYmast; //The minimum height of the mast

    private bool mastMove = false; //Activate or deactivate the movement of the mast

    private void FixedUpdate () 
    {
        if(fork.transform.localPosition.y >= maxYmast.y && fork.transform.localPosition.y < maxY.y)
        {
            mastMove = true;
        }
        else
        {
            mastMove = false;

        }

        if (fork.transform.localPosition.y <= maxYmast.y)
        {
            mastMove = false;
        }
      
        if (Input.GetKey(KeyCode.E))
        {
            fork.transform.localPosition = Vector3.MoveTowards(fork.transform.localPosition, maxY, speedTranslate * Time.deltaTime);
            if(mastMove)
            {
                mast.transform.localPosition = Vector3.MoveTowards(mast.transform.localPosition, maxYmast, speedTranslate * Time.deltaTime);
            }
          
        }
        if (Input.GetKey(KeyCode.Q))
        {
            fork.transform.localPosition = Vector3.MoveTowards(fork.transform.localPosition, minY, speedTranslate * Time.deltaTime);

            if (mastMove)
            {
                mast.transform.localPosition = Vector3.MoveTowards(mast.transform.localPosition, minYmast, speedTranslate * Time.deltaTime);

            }
        }
    }
}