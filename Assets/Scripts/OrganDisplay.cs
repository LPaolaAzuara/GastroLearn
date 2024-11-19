using UnityEngine;
using TMPro;

public class OrganDisplay : MonoBehaviour
{
    [Header("Modelos 3D")]
    public GameObject[] organModels; // Arreglo para los modelos 3D

    [Header("Textos de Informaci�n")]
    public string[] organTitles; // T�tulos de los �rganos
    public string[] organDescriptions; // Descripciones de los �rganos
    public string[] organDescriptions2; // Descripciones de los �rganos
    public string[] organDescriptions3; // Descripciones de los �rganos

    [Header("Referencias de UI")]
    public TMP_Text titleText; // Campo para el t�tulo (TextMeshPro)
 
    public TMP_Text descriptionText; // Campo para la descripci�n (TextMeshPro)
    public TMP_Text descriptionText2; // Campo para la descripci�n (TextMeshPro)
    public TMP_Text descriptionText3; // Campo para la descripci�n (TextMeshPro)
    public GameObject instructionPanel; // Panel de instrucciones

    private bool instructionsActive = true; // Estado del panel de instrucciones

    private void Start()
    {
        // Aseg�rate de que los arreglos est�n bien configurados
        if (organModels.Length != organTitles.Length || organModels.Length != organDescriptions.Length)
        {
            Debug.LogError("Los arreglos de modelos, t�tulos y descripciones deben tener la misma longitud.");
        }
        // Desactiva todos los modelos al inicio
        foreach (var model in organModels)
        {
            model.SetActive(false);
        }
        // Aseg�rate de que el panel de instrucciones est� activo al inicio
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(true);
        }

        // Desactiva los textos de t�tulo y descripci�n al inicio
        if (titleText != null)
        {
            titleText.text = "";
        }

        if (descriptionText != null)
        {
            descriptionText.text = "";
        }

        if (descriptionText2 != null)
        {
            descriptionText2.text = "";
        }
        if (descriptionText3 != null)
        {
            descriptionText3.text = "";
        }
    }

    public void ShowOrgan(int index)
    {
      
        // Valida el �ndice
        if (index < 0 || index >= organModels.Length)
        {
            Debug.LogError("�ndice fuera de rango.");
            return;
        }

        // Desactiva el panel de instrucciones si est� activo
        if (instructionsActive)
        {
            HideInstructions();
        }

        // Desactiva todos los modelos
        foreach (var model in organModels)
        {
            model.SetActive(false);
        }

        // Activa el modelo seleccionado y actualiza los textos
        organModels[index].SetActive(true);
        titleText.text = organTitles[index];
        descriptionText.text = organDescriptions[index];
        descriptionText2.text = organDescriptions2[index];
        descriptionText3.text = organDescriptions2[index];
    }

    public void HideInstructions()
    {
        if (instructionPanel != null)
        {
            instructionPanel.SetActive(false);
            instructionsActive = false;
        }
    }
}
