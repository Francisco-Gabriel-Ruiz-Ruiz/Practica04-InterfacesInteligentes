using UnityEngine;

public class Ej4RespuestaAproximacionCajaHumanoideTipo1 : MonoBehaviour
{
    public GameObject shieldTarget;

    public Ej4NotificadorCajaAproximacion notificadorCajaAproximacion;

    private bool eventFired;

    void Start() {
        if (!notificadorCajaAproximacion) {
            Debug.LogError(name + ": ¡No hay notificador asignado!");
        } else {
            notificadorCajaAproximacion.OnTargetApproximation += TeleportShieldTarget;
        }
        if (!shieldTarget.transform) {
            Debug.LogError(name + ": ¡El escudo asignado no tiene Transform!");
        }
        eventFired = false;
    }

    void TeleportShieldTarget() {
        if (eventFired) {
            return;
        }
        float previousHeight = transform.position.y;
        Vector3 newPosition = shieldTarget.transform.position;
        newPosition.y = previousHeight; 
        transform.position = newPosition;
        Debug.Log(name + ": Notificación recibida de " + notificadorCajaAproximacion.name + ", me estoy teletransportando a mi escudo objetivo " + shieldTarget.name);
        eventFired = true;
    }
}
