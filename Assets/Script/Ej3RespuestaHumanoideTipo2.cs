using UnityEngine;

public class Ej3RespuestaHumanoideTipo2 : MonoBehaviour
{
    public float globalSpeed = 1f;
    public float objectPersecutionSpeed = 1f;
    public float shieldPersecutionSpeed = 1f;
    public GameObject targetObject;

    public Ej1NotificadorColisionPlayer notificadorColisionPlayer;
    public Ej3NotificadorCaja notificadorCaja;

    private bool receivedMessageColisionPlayer;
    private bool receivedMessageCaja;
    private GameObject shieldTargetTipo1;
    private Rigidbody myRigidbody;
    private UnityEngine.Vector3 movementDirection;

    void Start() {
        if (!notificadorColisionPlayer || !notificadorCaja) {
            Debug.LogError(name + ": ¡No se han definido todos los notificadores!");
        } else {
            notificadorColisionPlayer.OnTriggerWithTarget += ActivatePersecutionToObject;
            notificadorCaja.OnCollisionWithTipo1 += ActivateShieldPersecution; // Cuando la caja colisiona con 'Tipo1', los 'Tipo2' (este) huyen a escudos 'Tipo1'
        }
        if (!targetObject) {
            Debug.LogError(name + ": ¡No se ha asignado un GameObject objetivo!");
        }
        if (!CompareTag("Tipo2")) {
            Debug.LogError(name + ": ¡Este objeto debe tener asignada la etiqueta 'Tipo2'!");
        }
        receivedMessageColisionPlayer = false;
        receivedMessageCaja = false;

        myRigidbody = GetComponent<Rigidbody>();
        if (!myRigidbody || !myRigidbody.isKinematic) {
            Debug.LogError(name + ": ¡El objeto debe tener un Rigidbody isKinematic!");
        }
        if (Mathf.Approximately(globalSpeed, 0f) || Mathf.Approximately(objectPersecutionSpeed, 0f) || Mathf.Approximately(shieldPersecutionSpeed, 0f)) {
            Debug.LogWarning(name + ": Al menos una velocidad de movimiento es aproximadamente 0.");
        }
    }

    void Update() {
        UnityEngine.Vector3 direction = UnityEngine.Vector3.zero;
        float moveStep = Time.fixedDeltaTime * globalSpeed;
        if (receivedMessageCaja) {
            moveStep *= shieldPersecutionSpeed;
            direction = (shieldTargetTipo1.transform.position - transform.position).normalized;
        } else if (receivedMessageColisionPlayer) {
            moveStep *= objectPersecutionSpeed;
            direction = (targetObject.transform.position - transform.position).normalized;
        }
        movementDirection = direction * moveStep;
        movementDirection = new UnityEngine.Vector3(movementDirection.x, 0f, movementDirection.z);
    }

    void FixedUpdate() {
        myRigidbody.MovePosition(transform.position + movementDirection);
    }

    void ActivatePersecutionToObject() {
        if (!receivedMessageCaja) { // Solo perseguirá si no está buscando el escudo
            receivedMessageColisionPlayer = true;
        }
    }

    void ActivateShieldPersecution() {
        if (!receivedMessageCaja) { // Solo ejecutar una vez
            ElegirEscudoAleatorioTipo1();
            receivedMessageCaja = true;
            receivedMessageColisionPlayer = false; // Desactivar persecución hacia el objeto objetivo.
        }
    }

    void ElegirEscudoAleatorioTipo1() {
        GameObject[] escudos = GameObject.FindGameObjectsWithTag("EscudoTipo1"); // Buscamos todos los GameObjects que tengan la etiqueta
        if (escudos.Length > 0) {
            int randomIndex = Random.Range(0, escudos.Length);  // Elegimos un índice aleatorio dentro del array de escudos encontrados
            shieldTargetTipo1 = escudos[randomIndex];           // Guardamos el escudo elegido como nuestro objetivo
            Debug.Log("Escudo seleccionado al azar: " + escudos[randomIndex].name);
        } else {
            Debug.LogWarning("No se han encontrado objetos con la etiqueta: 'EscudoTipo1'");
        }
    }
}
