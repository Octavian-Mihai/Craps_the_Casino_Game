using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class scriptTP1 : MonoBehaviour
{

    public GameObject sceneInput;
    public TMP_Text texteJoueur;
    public TMP_Text texteMontant;
    public TMP_InputField inputPlayerName;
    public TMP_InputField inputMontant;
    public Button boutonSavePlayer;
    public GameObject sceneMiser;
    public TMP_Text valeurMontantRestant;
    private int valeurMontantRestantNumerique;
    private int intValeurMontantRestant;
    private int nouvelleValeurMontantRestant;
    public TMP_Text valeurMise;
    private int intValeurMise;
    private int valeurMiseNumerique;
    private int nouvelleValeurMise;
    public TMP_Text texteNom;
    public TMP_Text texteMise;
    public TMP_Text symboleArgent;
    public TMP_Text finDeRound;
    public Button boutonLancer;
    public Button boutonAdd200;
    public Button boutonAdd25;
    public Button boutonAdd5;
    public Button boutonAdd1;
    public Button boutonAnnulerMise;
    public Button boutonNePasAugmenter;

    public GameObject sceneLancer;
    public TMP_Text valeurPremierLancer;
    public TMP_Text valeurDeuxiemeLancer;
    public TMP_Text texteValeurPremierLancer;
    public TMP_Text texteValeurDeuxiemeLancer;
    public TMP_Text messageFinPartie;
    public TMP_Text deuxiemeSomme;
    public Button miserEncoreUneFois;

    public TMP_Text texteCraps;
    public TMP_Text texteModeOff;
    private int intTexteModeOff;

    private bool jeuActif = true;



    void Start()
    {
        sceneInput.SetActive(true);
        sceneMiser.SetActive(false);
        sceneLancer.SetActive(false);
        texteCraps.gameObject.SetActive(true);
        texteModeOff.gameObject.SetActive(true);
        boutonSavePlayer.gameObject.SetActive(true);
        intValeurMise = 0;

        if ((inputPlayerName.text != "") && (int.Parse(inputMontant.text) > 0))
        {
            boutonSavePlayer.gameObject.SetActive(true);
        }
        else
        {
        }
    }

    public void Miser()                         // pour sceneMiser              pour boutonSavePlayer
    {
        texteNom.text = inputPlayerName.text;
        valeurMontantRestant.text = inputMontant.text;

        sceneInput.SetActive(false);
        sceneMiser.SetActive(true);
        sceneLancer.SetActive(false);
        texteCraps.gameObject.SetActive(true);
        texteModeOff.gameObject.SetActive(true);
        boutonLancer.gameObject.SetActive(false);
        boutonNePasAugmenter.gameObject.SetActive(false);

    }

    public void AjouterDeuxCents()
    {
        if (int.Parse(valeurMontantRestant.text) >= 200)
        {
            int nouvelleValeurMontantRestant = int.Parse(valeurMontantRestant.text) - 200;
            valeurMontantRestant.text = nouvelleValeurMontantRestant.ToString();

            intValeurMise += 200;
            nouvelleValeurMise = intValeurMise + 200;
            valeurMise.text = intValeurMise.ToString();
        }
    }

    public void AjouterVingtCinq()
    {
        if (int.Parse(valeurMontantRestant.text) >= 25)
        {
            int nouvelleValeurMontantRestant = int.Parse(valeurMontantRestant.text) - 25;
            valeurMontantRestant.text = nouvelleValeurMontantRestant.ToString();

            intValeurMise += 25;
            nouvelleValeurMise = intValeurMise + 25;
            valeurMise.text = intValeurMise.ToString();
        }
    }

    public void AjouterCinq()
    {
        if (int.Parse(valeurMontantRestant.text) >= 5)
        {
            int nouvelleValeurMontantRestant = int.Parse(valeurMontantRestant.text) - 5;
            valeurMontantRestant.text = nouvelleValeurMontantRestant.ToString();

            intValeurMise += 5;
            nouvelleValeurMise = intValeurMise + 5;
            valeurMise.text = intValeurMise.ToString();
        }
    }

    public void AjouterUn()
    {
        if (int.Parse(valeurMontantRestant.text) >= 1)
        {
            int nouvelleValeurMontantRestant = int.Parse(valeurMontantRestant.text);
            valeurMontantRestant.text = nouvelleValeurMontantRestant.ToString();

            intValeurMise += 1;
            nouvelleValeurMise = intValeurMise + 1;
            valeurMise.text = intValeurMise.ToString();
        }
    }


    public void AnnulerMise()
    {
        int nouvelleValeurMontantRestant = int.Parse(valeurMontantRestant.text) + intValeurMise;
        valeurMontantRestant.text = nouvelleValeurMontantRestant.ToString();

        intValeurMise -= intValeurMise;
        nouvelleValeurMise = intValeurMise + intValeurMise;
        valeurMise.text = intValeurMise.ToString();
    }

    public void LancerDes()
    {
        int intValeurPremierLancer = Random.Range(1, 7);
        int intValeurDeuxiemeLancer = Random.Range(1, 7);
        int resultatLancer1 = intValeurPremierLancer + intValeurDeuxiemeLancer;
        texteModeOff.text = resultatLancer1.ToString();
        valeurPremierLancer.text = intValeurPremierLancer.ToString();
        valeurDeuxiemeLancer.text = intValeurDeuxiemeLancer.ToString();
        intValeurMise = int.Parse(valeurMise.text);
        valeurMiseNumerique = intValeurMise;
        nouvelleValeurMontantRestant = int.Parse(valeurMontantRestant.text);

        sceneInput.SetActive(false);
        sceneMiser.SetActive(false);
        sceneLancer.SetActive(true);
        texteCraps.gameObject.SetActive(true);
        texteModeOff.gameObject.SetActive(true);
        boutonSavePlayer.gameObject.SetActive(false);

        if ((texteModeOff.text == "7") || (texteModeOff.text == "11"))
        {
            intValeurMise -= intValeurMise;
            valeurMise.text = intValeurMise.ToString();

            valeurMiseNumerique = int.Parse(valeurMise.text);
            valeurMontantRestantNumerique = int.Parse(valeurMontantRestant.text);
            valeurMontantRestantNumerique += 2 * valeurMiseNumerique;
            valeurMontantRestant.text = valeurMontantRestantNumerique.ToString();

            deuxiemeSomme.gameObject.SetActive(false);
            messageFinPartie.text = "Vous avez gagné " + valeurMiseNumerique + "$ !";
            jeuActif = false;
            miserEncoreUneFois.gameObject.SetActive(true);
            boutonNePasAugmenter.gameObject.SetActive(false);
            sceneMiser.SetActive(true);
        }
        else if ((texteModeOff.text == "2") || (texteModeOff.text == "3") || (texteModeOff.text == "12"))
        {
            intValeurMise -= intValeurMise;
            valeurMise.text = intValeurMise.ToString();
            deuxiemeSomme.gameObject.SetActive(false);
            messageFinPartie.text = "Vous avez perdu " + valeurMiseNumerique + "$ !";

            miserEncoreUneFois.gameObject.SetActive(true);
            boutonNePasAugmenter.gameObject.SetActive(false);
            jeuActif = false;
            sceneMiser.SetActive(true);

        }
        else
        {
            jeuActif = true;
            messageFinPartie.text = "Vous devez relancer!";
            if (jeuActif = true)
            {
                intValeurPremierLancer = Random.Range(1, 7);
                intValeurDeuxiemeLancer = Random.Range(1, 7);
                int resultatLancer2 = intValeurPremierLancer + intValeurDeuxiemeLancer;
                deuxiemeSomme.text = "First value: " + resultatLancer2.ToString();

                if (deuxiemeSomme.ToString() == resultatLancer1.ToString())
                {
                    intValeurMise -= intValeurMise;
                    valeurMise.text = intValeurMise.ToString();
                    valeurMiseNumerique = int.Parse(valeurMise.text);
                    valeurMontantRestantNumerique = int.Parse(valeurMontantRestant.text);
                    valeurMontantRestantNumerique += 2 * valeurMiseNumerique;
                    valeurMontantRestant.text = valeurMontantRestantNumerique.ToString();
                    deuxiemeSomme.gameObject.SetActive(true);
                    messageFinPartie.text = "Vous avez gagné " + valeurMiseNumerique + "$ !";
                    jeuActif = false;
                    miserEncoreUneFois.gameObject.SetActive(true);
                    sceneMiser.SetActive(true);

                }
                else if (deuxiemeSomme.text == "7")
                {
                    intValeurMise -= intValeurMise;
                    valeurMise.text = intValeurMise.ToString();
                    deuxiemeSomme.gameObject.SetActive(true);
                    messageFinPartie.text = "Vous avez perdu " + valeurMiseNumerique + "$ !";
                    jeuActif = false;
                    miserEncoreUneFois.gameObject.SetActive(true);
                    sceneMiser.SetActive(true);

                }
            }
        }
    }

    public void RecommencerMise()
    {
        sceneInput.SetActive(false);
        sceneMiser.SetActive(true);
        sceneLancer.SetActive(false);
        texteCraps.gameObject.SetActive(true);
        texteModeOff.gameObject.SetActive(true);
        boutonSavePlayer.gameObject.SetActive(false);

        texteModeOff.text = "OFF";
    }

    void Update()
    {
        if ((int.Parse(valeurMise.text) > 0))
        {
            boutonLancer.gameObject.SetActive(true);
        }
        else
        {
            boutonLancer.gameObject.SetActive(false);
        }
    }
}
