using UnityEngine;

public class Ej3NotificadorTiposHumanoides : MonoBehaviour
{
    public delegate void message();
    public event message OnCollisionWithTipo1;
    public event message OnCollisionWithTipo2;

    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.CompareTag("Tipo1")) {
            Debug.Log(name + ": he colisionado con " + collider.gameObject.name + " que es de 'Tipo1'. Notificando...");
            OnCollisionWithTipo1();
        } else if (collider.gameObject.CompareTag("Tipo2")) {
            Debug.Log(name + ": he colisionado con " + collider.gameObject.name + " que es de 'Tipo2'. Notificando...");
            OnCollisionWithTipo2();
        }
    }
}
