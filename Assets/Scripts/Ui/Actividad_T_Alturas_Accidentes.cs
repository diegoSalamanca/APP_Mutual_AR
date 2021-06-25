
using UnityEngine;

public class Actividad_T_Alturas_Accidentes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        iTween.ScaleFrom(gameObject, Vector3.zero, 0.5f);
    }

    public void GoodAnswer()
    {
        FindObjectOfType<Alturas_Activity>().SelectEscalera();
        Close();
    }

    public void BadAnswer()
    {
        FindObjectOfType<Alturas_Activity>().SelectSilla();
        Close();
    }

    public void Close()
    {
        Destroy(gameObject);
    }
}
