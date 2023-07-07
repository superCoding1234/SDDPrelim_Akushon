using UnityEngine;
using UnityEngine.UI;

public class Health2 : MonoBehaviour
{
    private PlayerController2 pc;
    private Slider slider;

    // Start is called before the first frame update
    private void Start()
    {
        pc = GetComponent<PlayerController2>();
        slider = pc.slider;
        pc.currentHealth = pc.maxHealth;
        slider.maxValue = pc.maxHealth;
    }

    // Update is called once per frame
    public void SubUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F)) pc.currentHealth -= 10;
        slider.value = pc.currentHealth;
    }
}
