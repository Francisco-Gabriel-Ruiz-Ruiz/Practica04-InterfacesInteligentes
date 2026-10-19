using UnityEngine;

public class Ej1NotificadorColisionPlayer : MonoBehaviour
{
    public GameObject collideTarget;

    public delegate void message(); // Define qué métodos pueden suscribirse con +=
    public event message OnTriggerWithTarget;

    void Start() {
        if (!collideTarget) {
          Debug.LogError(name + ": ¡No se ha seleccionado un objeto con el que colisionar!");
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (!collideTarget) {
            return;
        }
        if (collider.gameObject == collideTarget) {
            Debug.Log("Colisión entre " + name + " y mi target " + collideTarget.name);
            OnTriggerWithTarget();
        }
    }
}
