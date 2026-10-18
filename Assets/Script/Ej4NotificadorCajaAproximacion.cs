using UnityEngine;

public class Ej4NotificadorCajaAproximacion : MonoBehaviour
{
    public GameObject approximationTarget;
    public float distanceLimit = 4f;

    public delegate void message();
    public event message OnTargetApproximation;

    private bool eventFired;

    void Start() {
        if (!approximationTarget) {
            Debug.LogError(name + ": ¡No hay objeto de aproximación asignado!");
        }
        if (distanceLimit <= 0f) {
            Debug.LogError(name + ": ¡La distancia de aproximación es menor o igual que 0!");
        }
        eventFired = false;
    }

    void Update() {
        if (eventFired || !approximationTarget) {
            return;
        }
        float actualDistance = Vector3.Distance(transform.position, approximationTarget.transform.position);
        if (actualDistance <= distanceLimit) {
            eventFired = true;
            Debug.Log(name + ": el objeto de aproximación " + approximationTarget.name + " está a una distancia menor de " + distanceLimit + ", notificando...");
            OnTargetApproximation();
        }
    }
}
