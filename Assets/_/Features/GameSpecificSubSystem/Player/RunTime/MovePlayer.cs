using UnityEngine;
using UnityEngine.InputSystem;
using Manager.Runtime;


public class MovePlayer : MonoBehaviour
{
    #region Public
    
    
    public InputAction m_moveAction;
    public float m_vitesse = 5f;
    public Transform pointDeRepere; 
    
    #endregion
    
    
    #region Private

    [SerializeField] private GameManager _manager;
    [SerializeField] private float knockbackForce = 2f;
    [SerializeField] private float knockbackDuration = 0.1f;
    
    private float offsetRotation = -88f; 
    private bool isKnockedBack = false;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    
    #endregion
    
    
    #region API Unity
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        LookMouse();
    }
    #endregion
    
    
    #region main
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("Trigger enter");
        _manager.m_life -= 1;
    }
    
    
   
    
        

      
        
         
           
        
    

    #endregion
}