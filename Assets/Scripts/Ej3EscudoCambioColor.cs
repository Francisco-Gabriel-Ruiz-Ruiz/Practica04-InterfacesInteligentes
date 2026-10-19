using UnityEngine;

public class Ej3EscudoCambioColor : MonoBehaviour
{
    private Renderer myRenderer;

    void Start() {
        myRenderer = GetComponent<Renderer>();
        if (!myRenderer) {
            Debug.LogError(name + ": ¡El objeto debe tener un componente Renderer para poder cambiar de color!");
        }

        if (!CompareTag("EscudoTipo1") && !CompareTag("EscudoTipo2")) {
            Debug.LogWarning(name + ": Este objeto escudo debería tener asignada la etiqueta 'EscudoTipo1' o 'EscudoTipo2'.");
        }
    }

    void OnCollisionEnter(Collision collision) {
        ProcessCollision(collision.gameObject);
    }

    void OnTriggerEnter(Collider other) {
        ProcessCollision(other.gameObject);
    }

    void ProcessCollision(GameObject hitObject) {
        if (!myRenderer) {
            return;
        }

        if (hitObject.CompareTag("Tipo1")) {
            Debug.Log(name + ": Ha colisionado con el humanoide " + hitObject.name + " de 'Tipo1'. Cambiando a color aleatorio...");
            AssignRandomColor();
        } 
        else if (hitObject.CompareTag("Tipo2")) {
            Debug.Log(name + ": Ha colisionado con el humanoide " + hitObject.name + " de 'Tipo2'. Cambiando a color aleatorio...");
            AssignRandomColor();
        }
    }

    void AssignRandomColor() {
        Color colorAleatorio = new Color(Random.value, Random.value, Random.value);
        myRenderer.material.color = colorAleatorio;
    }
}