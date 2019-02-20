using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Animator))]
[ExecuteInEditMode]
public class SentinelController : MonoBehaviour {

    // Il bersaglio da controllare
    public Transform target;

    // La distanza dell'arco di controllo del sentinel
    [Range(1, 300)]
    public float detectDistance = 3f;

    // L'angolo di controllo del sentinel
    [Range(10, 180)]
    public float detectAngle = 90;

    // La velocità a cui ruota il sentinel
    public float rotationSpeed = 10;

    // La macchina a stati finiti che controlla il comportamento del sentinel
    private Animator _fsm;

    // Recupero l'animator
    private void Start()
    {
        _fsm = GetComponent<Animator>();    
    }

    void Update ()
    {
        // Recupero il livello di allerta dalla macchina a stati finiti
        float alertLevel = _fsm.GetFloat("AlertLevel");

        // Recupero l'angolo formato dal sentinel che guarda "in avanti" ed il bersaglio
        Vector3 groundedTarget = new Vector3(target.position.x, transform.position.y, target.position.z);
        Vector3 targetDirection = groundedTarget - transform.position;
        float angle = Vector3.Angle(targetDirection, transform.forward);

        // Se il bersaglio è all'interno dell'arco...
        if (
            (Vector3.Distance(transform.position, target.position) < detectDistance) &&
            (angle < detectAngle / 2)
            )
        {
            // ... aumento il livello di allerta ...
            alertLevel += .1f;
            alertLevel = alertLevel > 15 ? 15 : alertLevel;
        }
        else
        {
            // ... altrimenti lo diminuisco
            alertLevel -= .1f;
            alertLevel = alertLevel < 0 ? 0 : alertLevel;
        }
        _fsm.SetFloat("AlertLevel", alertLevel);

        // Se la macchina a stati finiti si trova in stato di allerta,
        // ruoto verso il bersagli a piena velocità
        if (_fsm.GetCurrentAnimatorStateInfo(0).IsName("Alert"))
        {
            float step = rotationSpeed * Time.deltaTime;
            Vector3 newDirection =  Vector3.RotateTowards(transform.forward, targetDirection, step, 1);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        // Se la macchina a stati finiti si trova in stato attivo,
        // ruoto verso il bersagli a velocità diminuita
        else if (_fsm.GetCurrentAnimatorStateInfo(0).IsName("Active"))
        {
            float step = rotationSpeed * Time.deltaTime / 3;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 1);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    private void OnDrawGizmos()
    {
        // Traccio una retta tra il sentinel ed il bersaglio
        Gizmos.color = Color.white;
        Vector3 end = new Vector3(target.position.x, transform.position.y, target.position.z);
        Gizmos.DrawLine(transform.position, end);

        // Traccio l'arco di controllo del sentinel.
        // Il colore dell'arco dipende dallo stato della macchina a stati finiti
        Color c = Color.grey;
        if(_fsm != null)
        {
            if (_fsm.GetCurrentAnimatorStateInfo(0).IsName("Active"))
            {
                c = Color.green;
            }
            else if (_fsm.GetCurrentAnimatorStateInfo(0).IsName("Alert"))
            {
                c = Color.red;
            }
        }
        Handles.color = new Color(c.r, c.g, c.b, .1f);
        Handles.DrawSolidArc(transform.position, transform.up, transform.forward, -detectAngle / 2, detectDistance);
        Handles.color = new Color(c.r, c.g, c.b, .2f);
        Handles.DrawSolidArc(transform.position, transform.up, transform.forward, detectAngle / 2, detectDistance);
    }
}
