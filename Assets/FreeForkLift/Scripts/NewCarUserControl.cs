using UnityEngine;

[RequireComponent(typeof(NewCarController))]
public class NewCarUserControl : MonoBehaviour
{
    [SerializeField] private NewCarController _carController; // the car controller we want to use

    private void FixedUpdate()
    {
        // pass the input to the car!
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float handbrake = Input.GetAxis("Jump");
        _carController.Move(h, v, v, handbrake);
    }
}