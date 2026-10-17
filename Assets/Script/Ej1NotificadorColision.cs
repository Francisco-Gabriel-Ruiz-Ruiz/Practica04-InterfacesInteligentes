using UnityEngine;

public class Ej1NotificadorColision : MonoBehaviour
{
    public GameObject collideTarget;

    public delegate void message(); // Define qué métodos pueden suscribirse con +=
    public event message OnTriggerWithTarget;

    void Start() {
        if (!collideTarget) {
          Debug.LogError(name + ": ¡No se ha seleccionado un objeto con el que colisionar!");
        }
        if (!GetComponent<Collider>().isTrigger) {
            Debug.LogError(name + ": ¡El objeto no tiene activado IsTrigger!");
        }
    }

    void Update() {
        
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
