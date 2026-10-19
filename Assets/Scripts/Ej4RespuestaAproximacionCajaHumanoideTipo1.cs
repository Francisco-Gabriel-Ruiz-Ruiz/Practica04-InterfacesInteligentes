using UnityEngine;

public class Ej4RespuestaAproximacionCajaHumanoideTipo1 : MonoBehaviour
{
    public GameObject shieldTarget;

    public Ej4NotificadorAproximacion notificadorAproximacion;

    private bool eventFired;

    void Start() {
        if (!notificadorAproximacion) {
            Debug.LogError(name + ": ¡No hay notificador asignado!");
        } else {
            notificadorAproximacion.OnTargetApproximation += TeleportShieldTarget;
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
        Debug.Log(name + ": Notificación recibida de " + notificadorAproximacion.name + ", me estoy teletransportando a mi escudo objetivo " + shieldTarget.name);
        eventFired = true;
    }
}
