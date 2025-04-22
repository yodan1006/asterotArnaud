using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public InputAction m_moveAction;
    public float m_vitesse = 5f;
    public Transform pointDeRepere; // Le point de repère qui regarde la souris
    
    private float offsetRotation = -88f; // Permet d'ajuster l'orientation via l'Inspectorzz
    private Vector2 moveInput;

    void Update()
    {
        Move();
        LookMouse();
    }

    public void Move()
    {
        if (moveInput.y > 0)
        {
            transform.Translate(Vector3.up * (m_vitesse * Time.deltaTime));
        }
    }

    public void LookMouse()
    {
        if (pointDeRepere == null) return;

        Vector3 mousePosition = Mouse.current.position.ReadValue();
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));

        Vector2 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(0, 0, angle + offsetRotation);
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}