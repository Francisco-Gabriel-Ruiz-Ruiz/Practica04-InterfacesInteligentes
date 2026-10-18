using UnityEngine;

public class Ej4RespuestaAproximacionCajaHumanoideTipo2 : MonoBehaviour
{
    public GameObject lookTarget;

    public Ej4NotificadorCajaAproximacion notificadorCajaAproximacion;

    private bool eventFired;

    void Start() {
        if (!notificadorCajaAproximacion) {
            Debug.LogError(name + ": ¡No hay notificador asignado!");
        } else {
            notificadorCajaAproximacion.OnTargetApproximation += LookForeverAtTarget;
        }
        if (!lookTarget || !lookTarget.transform) {
            Debug.LogError(name + ": ¡No hay objeto con Transform al que mirar por siempre asignado!");
        }
        eventFired = false;
    }

    void Update() {
        if (!eventFired || !lookTarget || !lookTarget.transform) {
            return;
        }
        transform.LookAt(lookTarget.transform);
    }

  void LookForeverAtTarget() {
        if (eventFired) {
            return;
        }
        Debug.Log(name + ": Notificación recibida de " + notificadorCajaAproximacion.name + ", ahora miraré por siempre al objeto " + lookTarget.name);
        eventFired = true;
    }
}
