using UnityEngine;

public class Ej4RespuestaAproximacionCajaHumanoideTipo2 : MonoBehaviour
{
    public GameObject lookTarget;
    public Ej4NotificadorCajaAproximacion notificadorCajaAproximacion;

    private bool eventFired;
    private Rigidbody myRigidbody;

    void Start() {
        if (!notificadorCajaAproximacion) {
            Debug.LogError(name + ": ¡No hay notificador asignado!");
        } else {
            notificadorCajaAproximacion.OnTargetApproximation += LookForeverAtTarget;
        }
        if (!lookTarget || !lookTarget.transform) {
            Debug.LogError(name + ": ¡No hay objeto con Transform al que mirar por siempre asignado!");
        }

        myRigidbody = GetComponent<Rigidbody>();
        if (!myRigidbody || !myRigidbody.isKinematic) {
            Debug.LogError(name + ": ¡El objeto debe tener un Rigidbody isKinematic!");
        }
        eventFired = false;
    }

    void FixedUpdate() {
        if (!eventFired || !lookTarget || !lookTarget.transform) {
            return;
        }
        // Calculamos la dirección hacia el objetivo ignorando la altura (eje Y) para que no se incline
        Vector3 lookDirection = lookTarget.transform.position - transform.position;
        lookDirection.y = 0f;
        if (lookDirection != Vector3.zero) {
            Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
            myRigidbody.MoveRotation(Quaternion.Slerp(myRigidbody.rotation, targetRotation, 10f * Time.fixedDeltaTime));
        }
    }

    void LookForeverAtTarget() {
        if (eventFired) {
            return;
        }
        Debug.Log(name + ": Notificación recibida de " + notificadorCajaAproximacion.name + ", ahora miraré por siempre al objeto " + lookTarget.name);
        eventFired = true;
    }
}