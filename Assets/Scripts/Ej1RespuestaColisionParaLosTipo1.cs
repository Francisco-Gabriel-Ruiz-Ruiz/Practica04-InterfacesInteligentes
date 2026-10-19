using UnityEngine;

public class Ej1RespuestaColisionParaLosTipo1 : MonoBehaviour
{
    public float speed = 1f;
    public GameObject objectTipo2Target;

    public Ej1NotificadorColisionPlayer notificador;

    private bool receivedMessage;
    private Rigidbody myRigidbody;
    private Vector3 movementDirection;
   
    void Start() {
        if (!notificador) {
            Debug.LogError(name + ": ¡No se ha definido el notificador de tipo Ej1NotificadorColisionPlayer!");
        } else {
            notificador.OnTriggerWithTarget += ActivateMovementTowardsTipo2Sphere;
        }
        if (!objectTipo2Target || !objectTipo2Target.CompareTag("Tipo2")) {
            Debug.LogError(name + ": ¡No se ha asignado un GameObject objetivo con la etiqueta 'Tipo2'!");
        }
        if (!CompareTag("Tipo1")) {
            Debug.LogError(name + ": ¡Este objeto debe tener asignada la etiqueta 'Tipo1'!");
        }
        receivedMessage = false;

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
            movementDirection = objectTipo2Target.transform.position -  transform.position;
            movementDirection = movementDirection.normalized * speed * Time.fixedDeltaTime;
        }
    }

    void FixedUpdate() {
        if (!myRigidbody) {
            return;
        }
        myRigidbody.MovePosition(transform.position + movementDirection);
    }

    void ActivateMovementTowardsTipo2Sphere() {
        Debug.Log("Soy " + name + ", he recibido el mensaje.");
        receivedMessage = true;
    }
}
