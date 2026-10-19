using UnityEngine;

public class Ej9MovimientoPlayerFisico : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody myRigidbody;
    private float horizontalMovement;
    private float verticalMovement;
    
    void Start() {
        myRigidbody = GetComponent<Rigidbody>();
        if (!myRigidbody) {
            Debug.LogError(name + ": ¡El objeto debe tener un Rigidbody!");
        } else if (myRigidbody.isKinematic) {
            Debug.LogWarning(name + ": El Rigidbody está como IsKinematic, pero este ejercicio pide que sea físico.");
        }
        
        if (Mathf.Approximately(speed, 0f)) {
            Debug.LogWarning(name + ": La velocidad de movimiento es aproximadamente 0 (no se moverá el objeto).");
        }
    }

    void Update() {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
    }

    void FixedUpdate() {
        if (!myRigidbody) {
            return;
        }
        Vector3 movementDirection = new Vector3(horizontalMovement, 0f, verticalMovement) * speed;
        // Modificamos la velocidad del Rigidbody manteniendo la velocidad de caída (Y) si salta o cae por gravedad
        myRigidbody.linearVelocity = new Vector3(movementDirection.x, myRigidbody.linearVelocity.y, movementDirection.z);
    }
}
