using UnityEditor.VersionControl;
using UnityEngine;

public class Ej3NotificadorCajaTiposHumanoides : MonoBehaviour
{
    public delegate void message();
    public event message OnCollisionWithTipo1;
    public event message OnCollisionWithTipo2;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Tipo1")) {
            Debug.Log(name + ": he colisionado con " + collision.gameObject.name + " que es de 'Tipo1'. Notificando...");
            OnCollisionWithTipo1();
        } else if (collision.gameObject.CompareTag("Tipo2")) {
            Debug.Log(name + ": he colisionado con " + collision.gameObject.name + " que es de 'Tipo2'. Notificando...");
            OnCollisionWithTipo2();
        }
    }
}
