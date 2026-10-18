using UnityEngine;

public class Ej1RespuestaColisionParaLosTipo2 : MonoBehaviour
{
    public float speed = 1f;
    public GameObject target;

    public Ej1NotificadorColision notificador;

    private bool receivedMessage;
    private Rigidbody myRigidbody;
    private Vector3 movementDirection;
   
    void Start() {
        if (!notificador) {
            Debug.LogError(name + ": ¡No se ha definido el notificador de tipo Ej1NotificadorColision!");
        } else {
            notificador.OnTriggerWithTarget += ActivateMovementTowardsTarget;
        }
        if (!target) {
            Debug.LogError(name + ": ¡No se ha asignado un GameObject objetivo al que moverse!");
        }
        receivedMessage = false;

        myRigidbody = GetComponent<Rigidbody>();
        if (!myRigidbody || !myRigidbody.isKinematic) {
            Debug.LogError(name + ": ¡El objeto debe tener un Rigidbody isKinematic!");
        }
        if (Mathf.Approximately(speed, 0f)) {
            Debug.LogWarning(name + ": La velocidad de movimiento es aproximadamente 0 (no se moverá el objeto).");
        }
        movementDirection = new Vector3(0f, 0f, 0f);
    }

    void Update() {
        if (receivedMessage) {
            movementDirection = target.transform.position -  transform.position;
            movementDirection = movementDirection.normalized * speed * Time.fixedDeltaTime;
        }
    }

    void FixedUpdate() {
        myRigidbody.MovePosition(transform.position + movementDirection);
    }

  void ActivateMovementTowardsTarget() {
        Debug.Log("Soy " + name + ", he recibido el mensaje.");
        receivedMessage = true;
    }
}
