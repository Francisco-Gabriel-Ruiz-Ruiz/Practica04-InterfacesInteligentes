using System.Numerics;
using UnityEngine;

public class Ej3RespuestaHumanoideTipo1 : MonoBehaviour
{
    public float globalSpeed = 1f;
    public float persecutionTipo2Speed = 1f;
    public float shieldPersecutionSpeed = 1f;
    public GameObject objectTipo2Target;
    public GameObject shieldTargetTipo2;

    public Ej1NotificadorColisionPlayer notificadorColisionPlayer;
    public Ej3NotificadorCajaTiposHumanoides notificadorCaja;

    private bool receivedMessageColisionPlayer;
    private bool receivedMessageCaja;
    private Rigidbody myRigidbody;
    private UnityEngine.Vector3 movementDirection;

    void Start() {
        if (!notificadorColisionPlayer || !notificadorCaja) {
            Debug.LogError(name + ": ¡No se han definido todos los notificadores!");
        } else {
            notificadorColisionPlayer.OnTriggerWithTarget += ActivatePersecutionToTipo2;
            notificadorCaja.OnCollisionWithTipo2 += ActivateShieldPersecution; // Cuando la caja colisiona con 'Tipo2', los 'Tipo1' (este) huyen a escudos 'Tipo2'
        }
        if (!objectTipo2Target || !objectTipo2Target.CompareTag("Tipo2")) {
            Debug.LogError(name + ": ¡No se ha asignado un GameObject objetivo con la etiqueta 'Tipo2'!");
        }
        if (!shieldTargetTipo2 || !shieldTargetTipo2.CompareTag("EscudoTipo2")) {
            Debug.LogError(name + ": ¡No se ha asignado un GameObject objetivo con la etiqueta 'EscudoTipo2'!");
        }
        if (!CompareTag("Tipo1")) {
            Debug.LogError(name + ": ¡Este objeto debe tener asignada la etiqueta 'Tipo1'!");
        }
        receivedMessageColisionPlayer = false;
        receivedMessageCaja = false;

        myRigidbody = GetComponent<Rigidbody>();
        if (!myRigidbody || !myRigidbody.isKinematic) {
            Debug.LogError(name + ": ¡El objeto debe tener un Rigidbody isKinematic!");
        }
        if (Mathf.Approximately(globalSpeed, 0f) || Mathf.Approximately(persecutionTipo2Speed, 0f) || Mathf.Approximately(shieldPersecutionSpeed, 0f)) {
            Debug.LogWarning(name + ": Al menos una velocidad de movimiento es aproximadamente 0.");
        }
    }

    void Update() {
        UnityEngine.Vector3 direction = UnityEngine.Vector3.zero;
        float moveStep = Time.fixedDeltaTime * globalSpeed;
        if (receivedMessageCaja) {
            moveStep *= shieldPersecutionSpeed;
            direction = (shieldTargetTipo2.transform.position - transform.position).normalized;
        } else if (receivedMessageColisionPlayer) {
            moveStep *= persecutionTipo2Speed;
            direction = (objectTipo2Target.transform.position - transform.position).normalized;
        }
        movementDirection = direction * moveStep;
        movementDirection = new UnityEngine.Vector3(movementDirection.x, 0f, movementDirection.z);
    }

    void FixedUpdate() {
        myRigidbody.MovePosition(transform.position + movementDirection);
    }

    void ActivatePersecutionToTipo2() {
        if (!receivedMessageCaja) { // Solo perseguirá si no está buscando el escudo
            receivedMessageColisionPlayer = true;
        }
    }

    void ActivateShieldPersecution() {
        receivedMessageCaja = true;
        receivedMessageColisionPlayer = false; // Desactivar persecución hacia el objeto 'Tipo2'.
    }
}
