using UnityEngine;

public class Ej1RespuestaColisionEsferaTipo1 : MonoBehaviour
{
    public float speed = 1f;
    public GameObject sphereTipo2Target;

    public Ej1NotificadorColision notificador;

    private bool receivedMessage;
    private Rigidbody myRigidbody;
    private Vector3 movementDirection;
   
    void Start() {
        if (!notificador) {
            Debug.LogError(name + ": ¡No se ha definido el notificador de tipo Ej1NotificadorColision!");
        } else {
            notificador.OnTriggerWithTarget += ActivateMovementTowardsTipo2Sphere;
        }
        if (!sphereTipo2Target || !sphereTipo2Target.CompareTag("Tipo2")) {
            Debug.LogError(name + ": ¡No se ha asignado una esfera objetivo con la etiqueta 'Tipo 2'!");
        }

        myRigidbody = GetComponent<Rigidbody>();
        if (!myRigidbody || !myRigidbody.isKinematic) {
            Debug.LogError(name + ": ¡El objeto debe tener un Rigidbody isKinematic!");
        }
        if (Mathf.Approximately(speed, 0f)) {
            Debug.LogWarning(name + ": La velocidad de movimiento es aproximadamente 0 (no se moverá el objeto).");
        }
    }

    void Update() {
        if (receivedMessage) {
            movementDirection = sphereTipo2Target.transform.position -  transform.position;
            movementDirection = movementDirection.normalized * speed * Time.fixedDeltaTime;
        }
    }

    void FixedUpdate() {
        myRigidbody.MovePosition(transform.position + movementDirection);
    }

    void ActivateMovementTowardsTipo2Sphere() {
        Debug.Log("Soy " + name + ", he recibido el mensaje.");
        receivedMessage = true;
    }
}
