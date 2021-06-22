using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public Transform Player;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject nextButtom;
    public GameObject ParlaButton;
    private GameObject ContentDialog;
    public GameObject OggettodaSbloccare;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        ContentDialog = GameObject.Find("ContentDialogue");
        ContentDialog.SetActive(false);
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text == sentences[index])
            nextButtom.SetActive(true);



    }

    public IEnumerator Type()
    {

        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;

            yield return new WaitForSeconds(typingSpeed);
        }

    }

    public void NextSentence()
    {

        nextButtom.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            nextButtom.SetActive(false);
            ParlaButton.SetActive(true);
            ContentDialog.SetActive(false);
            index = 0;
            Parla(false);
            sbloccaogg(true);
        }
    }

    public void AvviaDialogo()
    {
        ParlaButton.SetActive(false);
        ContentDialog.SetActive(true);
        Parla(true);
        StartCoroutine(Type());
        nextButtom.SetActive(false);
    }

    private void Parla(bool value)
    {
        anim.SetBool("Talking", value);
        transform.LookAt(Player);
    }
    public void sbloccaogg(bool sbloccablocca)
    {
        if (sbloccablocca)
            OggettodaSbloccare.GetComponent<SbloccaOggetto>().SbloccaBloccaOggetto(true);
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Untagged")
    //    {

    //        if (OVRInput.GetDown(OVRInput.Button.Two))
    //        {
    //            ContentDialog.SetActive(true);
    //            //other.GetComponentInChildren<LocomotionTeleport>().enabled = false;
    //            StartCoroutine(Type());
    //            return;
    //        }


    //    }
    //}

}
