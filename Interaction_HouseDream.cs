using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using UnityStandardAssets.Characters.FirstPerson;

public class Interaction_HouseDream : MonoBehaviour
{
    public Camera camera;
    public Text crosshairText, crosshairTextShadow, gameMessage, gameMessageShadow;
    bool radioPlayed = false;
    public GameObject lightFoyer, lightLivingRoom1, lightLivingRoom2, lightDiningRoom1, lightDiningRoom2, lightStaircase, lightStaircase1, lightKitchen1, lightKitchen2, lightBathroomDownstairs, lightUpstairsHall1, lightUpstairsHall2, lightUpstairsHall3, lightMasterBedroom, lightBedroom2, lightBedroom3, lightBedroom4, lightUpstairsBathroom, lightBasementMain, lightLivingRoomLamp1, lightLivingRoomLamp2, tvVideo;
    public NoiseAndGrain noiseAndGrain;
    public SepiaTone sepiaTone;
    public AudioSource audio, radioAudio;
    public Door officeDoorScript;
    public RigidbodyFirstPersonController player;

    public int timePeriod; // 0 is default (1994) - Annabelle's descent into madness.
                           // 1 is first shift (1941) - Events leading up to missing people and Jackson's suicide.
                           // 2 is current day (2020) - Events leading to John's disappearance.
                           // 3 is third shift (1943) when shit goes down.

    public Text journalRPageText, journalLPageText, paperText, bookLPageText, bookRPageText;
    public GameObject journalBackground, paperBackground, bookBackground, letterBackground, crosshairImageTop, crosshairImageBottom;


    void Start()
    {
        timePeriod = 0;
        CrosshairText(""); GameMessage("");
        //audio = camera.GetComponent<AudioSource>();
        officeDoorScript.enabled = false;
    }
    void Update()
    {
        CharRaycast();
    }
    void CharRaycast()
    {
        Ray ray = camera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5.0F))
        {
            string target = hit.transform.name;

            if (hit.collider.isTrigger)
            {
                if (target == "Floor")
                {
                    // Nothing should happen if activated.
                    CrosshairText("");
                }

                #region "Lighting Control Conditional Statements"
                else if (target == "LightSwitchFoyer")
                {
                    CrosshairText("Light Switch");
                    if (Use())
                    {
                        if (lightFoyer.activeSelf == false)
                        {
                            lightFoyer.SetActive(true); LightSound();
                        }
                        else
                        {
                            lightFoyer.SetActive(false); LightSound();
                        }
                    }
                }
                else if (target == "LightSwitchLivingRoom")
                {
                    CrosshairText("Light Switch");
                    if (Use())
                    {
                        if (lightLivingRoom1.activeSelf == false)
                        {
                            lightLivingRoom1.SetActive(true);
                            lightLivingRoom2.SetActive(true);
                            LightSound();
                        }
                        else
                        {
                            lightLivingRoom1.SetActive(false);
                            lightLivingRoom2.SetActive(false);
                            LightSound();
                        }
                    }
                }
                else if (target == "DiningRoomLightSwitch" || target == "DiningRoomLightSwitch1" || target == "DiningRoomLightSwitch2")
                {
                    CrosshairText("Light Switch");
                    if (Use())
                    {
                        if (lightDiningRoom1.activeSelf == false)
                        {
                            lightDiningRoom1.SetActive(true);
                            lightDiningRoom2.SetActive(true);
                            LightSound();
                        }
                        else
                        {
                            lightDiningRoom1.SetActive(false);
                            lightDiningRoom2.SetActive(false);
                            LightSound();
                        }
                    }
                }
                else if (target == "LightSwitchStaircase")
                {
                    CrosshairText("Light Switch");
                    if (Use())
                    {
                        if (lightStaircase.activeSelf == false)
                        {
                            lightStaircase.SetActive(true);
                            lightStaircase1.SetActive(true);
                            LightSound();
                        }
                        else
                        {
                            lightStaircase.SetActive(false);
                            lightStaircase1.SetActive(false);
                            LightSound();
                        }
                    }

                }
                else if (target == "KitchenLightSwitch")
                {
                    CrosshairText("Light Switch");
                    if (Use())
                    {
                        if (lightKitchen1.activeSelf == false)
                        {
                            lightKitchen1.SetActive(true);
                            lightKitchen2.SetActive(true);
                            LightSound();
                        }
                        else
                        {
                            lightKitchen1.SetActive(false);
                            lightKitchen2.SetActive(false);
                            LightSound();
                        }
                    }
                }
                else if (target == "BathroomDownstairsLightSwitch")
                {
                    CrosshairText("Light Switch");
                    if (Use())
                    {
                        if (lightBathroomDownstairs.activeSelf == false)
                        {
                            lightBathroomDownstairs.SetActive(true); LightSound();
                        }
                        else
                        {
                            lightBathroomDownstairs.SetActive(false); LightSound();
                        }
                    }
                }
                else if (target == "LightUpstairsHallwaySwitch")
                {
                    CrosshairText("Light Switch");
                    if (Use())
                    {
                        if (lightUpstairsHall1.activeSelf == false)
                        {
                            lightUpstairsHall1.SetActive(true);
                            lightUpstairsHall2.SetActive(true);
                            lightUpstairsHall3.SetActive(true);
                            LightSound();
                        }
                        else
                        {
                            lightUpstairsHall1.SetActive(false);
                            lightUpstairsHall2.SetActive(false);
                            lightUpstairsHall3.SetActive(false);
                            LightSound();
                        }
                    }
                }
                else if (target == "MasterBedroomLightSwitch")
                {
                    CrosshairText("Light Switch");
                    if (Use())
                    {
                        if (lightMasterBedroom.activeSelf == false)
                        {
                            lightMasterBedroom.SetActive(true); LightSound();
                        }
                        else
                        {
                            lightMasterBedroom.SetActive(false); LightSound();
                        }
                    }

                }
                else if (target == "LightBedroom2Switch")
                {
                    CrosshairText("Light Switch");
                    if (Use())
                    {
                        if (lightBedroom2.activeSelf == false)
                        {
                            lightBedroom2.SetActive(true); LightSound();
                        }
                        else
                        {
                            lightBedroom2.SetActive(false); LightSound();
                        }
                    }
                }
                else if (target == "LightBedroom3Switch")
                {
                    CrosshairText("Light Switch");
                    if (Use())
                    {
                        if (lightBedroom3.activeSelf == false)
                        {
                            lightBedroom3.SetActive(true); LightSound();
                        }
                        else
                        {
                            lightBedroom3.SetActive(false); LightSound();
                        }
                    }
                }
                else if (target == "LightBedroom4Switch")
                {
                    CrosshairText("Light Switch");
                    if (Use())
                    {
                        if (lightBedroom4.activeSelf == false)
                        {
                            lightBedroom4.SetActive(true); LightSound();
                        }
                        else
                        {
                            lightBedroom4.SetActive(false); LightSound();
                        }
                    }
                }
                else if (target == "BathroomUpstairsLightSwitch")
                {
                    CrosshairText("Light Switch");
                    if (Use())
                    {
                        if (lightUpstairsBathroom.activeSelf == false)
                        {
                            lightUpstairsBathroom.SetActive(true); LightSound();
                        }
                        else
                        {
                            lightUpstairsBathroom.SetActive(false); LightSound();
                        }
                    }

                }
                else if (target == "BasementLightSwitch")
                {
                    CrosshairText("Light Switch");
                    if (Use())
                    {
                        if (lightBasementMain.activeSelf == false)
                        {
                            lightBasementMain.SetActive(true); LightSound();
                        }
                        else
                        {
                            lightBasementMain.SetActive(false); LightSound();
                        }
                    }
                }
                else if (target == "LivingRoomLamp1")
                {
                    CrosshairText("Lamp");
                    if (Use())
                    {
                        if (lightLivingRoomLamp1.activeSelf == false)
                        {
                            lightLivingRoomLamp1.SetActive(true); LightSound();
                        }
                        else
                        {
                            lightLivingRoomLamp1.SetActive(false); LightSound();
                        }
                    }
                }
                else if (target == "LivingRoomLamp2")
                {
                    CrosshairText("Lamp");
                    if (Use())
                    {
                        if (lightLivingRoomLamp2.activeSelf == false)
                        {
                            lightLivingRoomLamp2.SetActive(true);
                            LightSound();
                        }
                        else
                        {
                            lightLivingRoomLamp2.SetActive(false);
                            LightSound();
                        }
                    }
                }
                #endregion

                #region "Interactable Triggers and Objects"
                else if (target == "TV-boxLR")
                {
                    CrosshairText("TV");
                    if (Use())
                    {
                        if (tvVideo.activeSelf == false)
                        {
                            tvVideo.SetActive(true);
                            LightSound();
                        }
                        else
                        {
                            tvVideo.SetActive(false);
                            LightSound();
                        }
                    }
                }
                else if (target == "rabbitTrigger")
                {
                    CrosshairText("White Rabbit");
                    if (Use())
                    {
                        if (noiseAndGrain.enabled == true)
                        {
                            noiseAndGrain.enabled = false;
                            sepiaTone.enabled = false;
                            PlaySound("Hit_metalic1");
                            
                            // Reveal "90s" layer
                            camera.cullingMask = 1 << 10;
                        }
                        else
                        {
                            noiseAndGrain.enabled = true;
                            sepiaTone.enabled = true;
                            PlaySound("Hit_metalic1");
                            
                            // Hide "90s" layer
                            camera.cullingMask = 0 << 10;
                        }
                    }
                }
                else if (target == "EiffelTowerPhoto")
                {
                    CrosshairText("Eiffel Tower, August 1990");
                    // Dialogue: "She wasn't always such a recluse."
                }

                else if (target == "MeAndMom" | target == "MeAndMom2")
                {
                    CrosshairText("Mom and I, June 1988");
                }
                else if (target == "bkJournal01House")
                {
                    CrosshairText("Annabelle Journal");
                    if (Use())
                    {
                        if (journalBackground.activeSelf == false)
                        {
                            player.enabled = false;
                            ReadBook(1, "AnnabelleJournal01");

                        }
                        else
                        {
                            player.enabled = true;
                            CloseBook();
                        }

                    }
                }
                else if (target == "bkJournalDeveloper")
                {
                    CrosshairText("Dev Journal");
                    if (Use())
                    {
                        if(journalBackground.activeSelf == false)
                        {
                            player.enabled = false;
                            ReadBook(1, "bkJournalDeveloper");
                        }
                        else
                        {
                            player.enabled = true;
                            CloseBook();
                        }
                    }
                    
                }
                else if (target == "mailHouse01")
                {
                    CrosshairText("Mail from Psychiatrist");
                    if (Use())
                    {
                        if (letterBackground.activeSelf == false)
                        {
                            player.enabled = false;
                            PlaySound("takeItem");
                            ReadBook(3, "mailFromPsych");
                        }
                        else
                        {
                            if (paperBackground.activeSelf == true)
                            {
                                player.enabled = true;
                                PlaySound("takeItem");
                                CloseBook();
                            }
                            else
                            {
                                ReadBook(0, "letterFromPsych");

                            }


                        }
                    }

                }
                else if (target == "Record")
                {
                    CrosshairText("Record");
                    if (Use())
                    {
                        
                    }
                }
                else if (target == "RadioFront")
                {
                    CrosshairText("Radio");
                    if(Use())
                    {
                        if(radioAudio.isPlaying)
                        {
                            PlaySound("radioswitch");
                            radioAudio.Pause();
                        }
                        else
                        {
                            if(radioPlayed == true)
                            {
                                PlaySound("radioswitch");
                                radioAudio.UnPause();
                            }
                            else
                            {
                                PlaySound("radioswitch");
                                radioAudio.Play();
                            }
                            
                        }
                    }
                }
                #endregion

                #region "Crosshair Visible - Non-interactive"
                // The doors are interacted with through the "Door.cs" script in the base folder.
                else if (target == "BedroomDoor3" || target == "BedroomDoor2" || target == "BedroomDoor1")
                {
                    CrosshairText("Bedroom Door");
                }
                else if (target == "Office Door")
                {
                    CrosshairText("Home Office");
                    if (Use())
                    {
                        if (officeDoorScript.enabled == true)
                        {

                        }
                        else
                        {
                            PlaySound("lockedDoor2");
                        }
                    }
                }
                else if (target == "Back Door" || target == "Front Door")
                {
                    CrosshairText("Door to Outside");
                    if (Use())
                    {
                        PlaySound("doorlocked001");
                        GameMessage("The door will not open...");
                    }
                }
                #endregion
                else
                {
                    CrosshairText("");
                }
            }
            else
            {
                CrosshairText("");
            }
        }
    }
    void CrosshairText(string message)
    {
        if (message == "")
        {
            crosshairImageTop.SetActive(false);
            crosshairImageBottom.SetActive(false);
            crosshairText.text = message;
            crosshairTextShadow.text = message;
        }
        else
        {
            crosshairImageTop.SetActive(true);
            crosshairImageBottom.SetActive(true);
            crosshairText.text = message;
            crosshairTextShadow.text = message;
        }
        
    }
    void GameMessage(string message)
    {
        gameMessage.text = message;
        gameMessageShadow.text = message;
        StartCoroutine(ClearGameMessage());
    }

    IEnumerator ClearGameMessage()
    {
        yield return new WaitForSecondsRealtime(6.0f);
        gameMessage.text = "";
        gameMessageShadow.text = "";
    }
    bool Use()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void PlaySound(string filename)
    {
        audio.PlayOneShot((AudioClip)Resources.Load(filename));
    }
    void CloseBook()
    {
        ReadBook(99, "");
    }
    void ReadBook(int typeOfBook, string bookID)
    {
        // Book Types 
        // ----------
        // 0 - Paper
        // 1 - Journal
        // 2 - Printed Book
        // 3 - Letter
        // 99 - Close book (ReadBook(99, "");

        if(typeOfBook == 0)
        {
            if(bookID == "letterFromPsych")
            {
                paperBackground.SetActive(true);
                paperText.text = "Dr. Armand Natili\n1989 Ashland Commons\nSuite 220\nPittsburgh, Pennsylvania 15106\n\nFebruary 28th, 1994\n\nDear Ms. Jackson\n\nPursuant to our phone conversation on the 20th of February, I am not able to send you your medical records established with this office. I can however, provide you with a brief synopsis of our diagnoses as outlined by our privacy policies.\n\nPatient is a 52 year old female, diagnosed with an acute Schitzoaffective disorder.\n- Suicidal ideation is also present, as is the history of self-harm and self-medication.\n- Patient has been in and out of psychiatric care since 1970 and while she has shown remarkable progress, will not be able to conduct her affairs in any kind of appreciable manner without assistance from outside influences.\n- Referred to Social Services Department.\n- Patient has also been diagnosed with Persistant Depressive Disorder, and Borderline Personality Disorder.\n- Patient is defiant and at times combative.\n- Meciations include Sertraline (for anxiety and depression), Diazepam (for acute znxiety and stress) and Lithium (for mood stabilization and depression).\n\nMs. Jackson, while I'm sure this isn't as exhaustive as you wanted, this is all that my office can provide until you resume your therapy with our office.\n\nThank you for your understanding,\n\nDr. Armand Natili";
            }
        }
        else if (typeOfBook == 1)
        {
            journalBackground.SetActive(true);
            if (bookID == "AnnabelleJournal01")
            {
                journalLPageText.text = "March 14th, 1994\n\nOlivia has been having nightmares of her grandfather. I have no clue what to tell her about him. I would say that they were just dreams, but in our family, dreams are never just dreams.\n\nFuck, I'm sounding just like my father. \"Freud this\", and \"Freud that\". Freud was a hyper-sexual idiot that had a few ideas. Nothing more.";
                journalRPageText.text = "";
            }
            else if(bookID == "bkJournalDeveloper")
            {
                journalLPageText.text = "April 4th, 2020\n\nThis game started because I wanted to tell a story. My wife provided me with a story that we both worked on and then started putting down.\n\nAnd here we are.\n\nThere is something new that I created this little VR book for though.\n\nThis game was largely completed during the COVID-19 pandemic. I basically said that since I was home anyway, might as well.\n\nI'm finding myself a little bit more than bothered.\n\nThe reality is this, and we can argue about politics until we both die. But, the fact of the matter is that if Donald Trump was even marginally intelligent, there would have been a better response to this whole thing.";
                journalRPageText.text = "I find it funny that in order to prevent myself from getting cabin fever, I have to create worlds to explore. Rather than, oh I don't know, go see friends.\n\n";
            }
        }
        else if (typeOfBook == 2)
        {
            bookBackground.SetActive(true);

        }
        else if (typeOfBook == 3)
        {
            letterBackground.SetActive(true);
        }
        else if (typeOfBook == 99)
        {
            // To be called by the CloseBook() function above.
            // Can be manually called by the line;
            // ReadBook(99, "");
            // ------------------------------------------------
            if (journalBackground.activeSelf == true | paperBackground.activeSelf == true | bookBackground.activeSelf == true | letterBackground.activeSelf == true)
            {
                // Calling this option gets rid of the entire book, paper or journal
                // and its text
                paperBackground.SetActive(false);
                paperText.text = "";

                bookBackground.SetActive(false);
                bookLPageText.text = "";
                bookRPageText.text = "";

                journalBackground.SetActive(false);
                journalLPageText.text = "";
                journalRPageText.text = "";

                letterBackground.SetActive(false);
            }
        }

    }
    void LightSound()
    {
        PlaySound("lightSwitchRocker");
    }
}
