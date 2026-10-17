using UnityEngine;

public class Ej1MovimientoPlayer : MonoBehaviour
{
    public float speed = 1f;

    private Rigidbody myRigidbody;
    private float horizontalMovement;
    private float verticalMovement;
    
    void Start() {
        myRigidbody = GetComponent<Rigidbody>();
        if (!myRigidbody || !myRigidbody.isKinematic) {
            Debug.LogError(name + ": ¡El objeto debe tener un Rigidbody isKinematic!");
        }
        if (Mathf.Approximately(speed, 0f)) {
            Debug.LogWarning(name + ": La velocidad de movimiento es aproximadamente 0 (no se moverá el objeto).");
        }
    }

    void Update() {
        float moveStep = speed * Time.fixedDeltaTime;
        horizontalMovement = Input.GetAxis("Horizontal") * moveStep;
        verticalMovement = Input.GetAxis("Vertical") * moveStep;
    }

    void FixedUpdate() {
        if (!myRigidbody) {
            return;
        }
        Vector3 movementDirection = new Vector3(horizontalMovement, 0f, verticalMovement);
        myRigidbody.MovePosition(transform.position + movementDirection);
    }
}
