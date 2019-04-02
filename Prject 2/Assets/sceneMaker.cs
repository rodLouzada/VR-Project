using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
public class sceneMaker : MonoBehaviour
{
	public List<Transform> listP = new List<Transform>();
	
    public Transform p_solid;
    public Transform p_slab;
    public Transform p_transparent;
    
    public Transform t_hanoi;
    public GameObject t_btn;
    GameObject auxt_btn;
    public Transform t_cube;

    public Transform pos2m;
    public Transform pos5m;
    public Transform pos10m;
    public Transform pos20m;
    public Transform pos30m;

    public int sec2;
    public int sec5;
    public int sec10;
    public int sec20;
    public int sec30;

    public ToggleGroup tg2_task;
    public ToggleGroup tg5_task;
    public ToggleGroup tg10_task;
    public ToggleGroup tg20_task;
    public ToggleGroup tg30_task;

    public ToggleGroup tg2_plat;
    public ToggleGroup tg5_plat;
    public ToggleGroup tg10_plat;
    public ToggleGroup tg20_plat;
    public ToggleGroup tg30_plat;

    public ToggleGroup tgDificulty;
    public ToggleGroup tgImmersiveness;
    public ToggleGroup tgNausea;

    Toggle t2_task;
    Toggle t5_task;
    Toggle t10_task;
    Toggle t20_task;
    Toggle t30_task;

    Toggle t2_plat;
    Toggle t5_plat;
    Toggle t10_plat;
    Toggle t20_plat;
    Toggle t30_plat;

    Toggle td;
    Toggle ti;
    Toggle tn;

    public GameObject panel2;
    public GameObject panel5;
    public GameObject panel10;
    public GameObject panel20;
    public GameObject panel30;

    public InputField if2;
    public InputField if5;
    public InputField if10;
    public InputField if20;
    public InputField if30;
    public InputField ifname;
    public InputField ifses;

    public Text txt_dif, txt_imer, txt_nausea,txt_name, txt_session;
    Vector3 auxv3;
    Quaternion auxq;

    GameObject auxPlat;

    float start, end;

    public ItemDatabase itemDB;
    public Stages entry2;
    public Stages entry5;
    public Stages entry10;
    public Stages entry20;
    public Stages entry30;

    public void LoadLog()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/xml/" + ifname.text + "_" + ifses.text + ".xml", FileMode.Open);
        itemDB = serializer.Deserialize(stream) as ItemDatabase;
        txt_dif.text = itemDB.dificulty;
        txt_imer.text = itemDB.immersiveness;
        txt_nausea.text = itemDB.nausea;
        txt_name.text = itemDB.name;
        txt_session.text = itemDB.session;
        stream.Close();
    }
    

    public void SaveItems()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.dataPath + "/xml/" + ifname.text + "_" + ifses.text + ".xml", FileMode.Create);
        itemDB.name = ifname.text;
        itemDB.session = ifses.text;
        

        serializer.Serialize(stream, itemDB);
        stream.Close();
    }

    public void Savetime()
    {
        itemDB.time = Time.time - start;
    }

    void Start() //Update()
    {
        // tgtest = tg2_task.ActiveToggles().FirstOrDefault();
        // Debug.Log("Active togle: " + tgtest.name.ToString());
     
        /*
        auxv3 = new Vector3(pos10m.transform.position.x - 2.2f, pos10m.transform.position.y + 1f, pos10m.transform.position.z);
        auxq = Quaternion.Euler(pos10m.transform.rotation.x, pos10m.transform.localEulerAngles.y + 90.0f, pos10m.transform.rotation.z);
        Instantiate(p_solid, new Vector3(pos10m.transform.position.x - 2.3f, pos10m.transform.position.y, pos10m.transform.position.z), pos10m.transform.rotation);
        auxt_btn = Instantiate(t_btn, auxv3, auxq);
        auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(2); */
        
    }

    public void submitAssessment()
    {
        td = tgDificulty.ActiveToggles().FirstOrDefault();
        ti = tgImmersiveness.ActiveToggles().FirstOrDefault();
        tn = tgNausea.ActiveToggles().FirstOrDefault();
        itemDB.dificulty = "Dificulty assessed: " + td.tag.ToString();
        itemDB.immersiveness = "Immersiveness assessed: " + ti.tag.ToString();
        itemDB.nausea = "Nausea assessed: " + tn.tag.ToString();
    }

Transform plat;
        public void setScene()

  {
        start = Time.time;
        if (panel2.activeSelf)
        {
            //if this panel is active

            t2_task = tg2_task.ActiveToggles().FirstOrDefault();
            t2_plat = tg2_plat.ActiveToggles().FirstOrDefault();
            entry2.level = "Platform 2 meters:";
            entry2.platform = "Platform style: "+t2_plat.tag.ToString();
            entry2.task = "Task style: " + t2_task.tag;
            entry2.timer = "No timer added";

            if (t2_plat.tag == "solid")
            {
                if (t2_task.tag == "btn")
                {
                    sec2 = int.Parse(if2.text);
                    auxv3 = new Vector3(pos2m.transform.position.x - 1.8f, pos2m.transform.position.y + 1.0f, pos2m.transform.position.z);
                    auxq = Quaternion.Euler(pos2m.transform.rotation.x, pos2m.transform.localEulerAngles.y + 90.0f, pos2m.transform.rotation.z);
                    plat = Instantiate(p_solid, pos2m.transform.position, pos2m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec2);
                    entry2.timer = sec2.ToString();
					listP.Add(plat);
                }
                if (t2_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos2m.transform.position.x - 1.74f, pos2m.transform.position.y, pos2m.transform.position.z);
                    auxq = Quaternion.Euler(pos2m.transform.rotation.x, pos2m.transform.localEulerAngles.y, pos2m.transform.rotation.z);
                    plat =Instantiate(p_solid, pos2m.transform.position, pos2m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t2_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos2m.transform.position.x - 1.74f, pos2m.transform.position.y + 1.8f, pos2m.transform.position.z);
                    auxq = Quaternion.Euler(pos2m.transform.rotation.x, pos2m.transform.localEulerAngles.y + 90.0f, pos2m.transform.rotation.z);
                    plat =Instantiate(p_solid, pos2m.transform.position, pos2m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            if (t2_plat.tag == "slim")
            {
                if (t2_task.tag == "btn")
                {
                    sec2 = int.Parse(if2.text);
                    auxv3 = new Vector3(pos2m.transform.position.x - 2.2f, pos2m.transform.position.y + 1f, pos2m.transform.position.z);
                    auxq = Quaternion.Euler(pos2m.transform.rotation.x, pos2m.transform.localEulerAngles.y + 90.0f, pos2m.transform.rotation.z);
                    plat =Instantiate(p_slab, new Vector3(pos2m.transform.position.x - 2.3f, pos2m.transform.position.y, pos2m.transform.position.z), pos2m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec2);
                    entry2.timer = sec2.ToString();
					listP.Add(plat);
                }
                if (t2_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos2m.transform.position.x - 2.2f, pos2m.transform.position.y + 1.8f, pos2m.transform.position.z);
                    auxq = Quaternion.Euler(pos2m.transform.rotation.x, pos2m.transform.localEulerAngles.y + 90.0f, pos2m.transform.rotation.z);
                    plat =Instantiate(p_slab, new Vector3(pos2m.transform.position.x - 2.3f, pos2m.transform.position.y, pos2m.transform.position.z), pos2m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t2_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos2m.transform.position.x - 2.2f, pos2m.transform.position.y + 1.8f, pos2m.transform.position.z);
                    auxq = Quaternion.Euler(pos2m.transform.rotation.x, pos2m.transform.localEulerAngles.y + 90.0f, pos2m.transform.rotation.z);
                    plat =Instantiate(p_slab, new Vector3(pos2m.transform.position.x - 2.3f, pos2m.transform.position.y, pos2m.transform.position.z), pos2m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            if (t2_plat.tag == "glass")
            {
                if (t2_task.tag == "btn")
                {
                    sec2 = int.Parse(if2.text);
                    auxv3 = new Vector3(pos2m.transform.position.x - 2.2f, pos2m.transform.position.y + 1f, pos2m.transform.position.z);
                    auxq = Quaternion.Euler(pos2m.transform.rotation.x, pos2m.transform.localEulerAngles.y + 90.0f, pos2m.transform.rotation.z);
                    plat =Instantiate(p_transparent, new Vector3(pos2m.transform.position.x - 2.3f, pos2m.transform.position.y, pos2m.transform.position.z), pos2m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec2);
                    entry2.timer = sec2.ToString();
					listP.Add(plat);
                }
                if (t2_task.tag == "cube")
                {

                    auxv3 = new Vector3(pos2m.transform.position.x - 2.2f, pos2m.transform.position.y + 1.8f, pos2m.transform.position.z);
                    auxq = Quaternion.Euler(pos2m.transform.rotation.x, pos2m.transform.localEulerAngles.y + 90.0f, pos2m.transform.rotation.z);
                    plat =Instantiate(p_transparent, new Vector3(pos2m.transform.position.x - 2.3f, pos2m.transform.position.y, pos2m.transform.position.z), pos2m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t2_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos2m.transform.position.x - 2.2f, pos2m.transform.position.y + 1.8f, pos2m.transform.position.z);
                    auxq = Quaternion.Euler(pos2m.transform.rotation.x, pos2m.transform.localEulerAngles.y + 90.0f, pos2m.transform.rotation.z);
                    plat =Instantiate(p_transparent, new Vector3(pos2m.transform.position.x - 2.3f, pos2m.transform.position.y, pos2m.transform.position.z), pos2m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            itemDB.list.Add(entry2);
        }
        if (panel5.activeSelf)
        {
            //if this panel is active
            t5_task = tg5_task.ActiveToggles().FirstOrDefault();
            t5_plat = tg5_plat.ActiveToggles().FirstOrDefault();
            entry5.level = "Platform 5 meters:";
            entry5.platform = "Platform style: " + t5_plat.tag;
            entry5.task = "Task style: " + t5_task.tag;
            entry5.timer = "No timer added";

            if (t5_plat.tag == "solid")
            {
                if (t5_task.tag == "btn")
                {
                    sec5 = int.Parse(if5.text);
                    auxv3 = new Vector3(pos5m.transform.position.x - 1.8f, pos5m.transform.position.y + 1.0f, pos5m.transform.position.z);
                    auxq = Quaternion.Euler(pos5m.transform.rotation.x, pos5m.transform.localEulerAngles.y + 90.0f, pos5m.transform.rotation.z);
                    plat =Instantiate(p_solid, pos5m.transform.position, pos5m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec5);
                    entry5.timer = sec5.ToString();
					listP.Add(plat);
                }
                if (t5_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos5m.transform.position.x - 1.74f, pos5m.transform.position.y, pos5m.transform.position.z);
                    auxq = Quaternion.Euler(pos5m.transform.rotation.x, pos5m.transform.localEulerAngles.y, pos5m.transform.rotation.z);
                    plat =Instantiate(p_solid, pos5m.transform.position, pos5m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t5_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos5m.transform.position.x - 1.74f, pos5m.transform.position.y + 1.8f, pos5m.transform.position.z);
                    auxq = Quaternion.Euler(pos5m.transform.rotation.x, pos5m.transform.localEulerAngles.y + 90.0f, pos5m.transform.rotation.z);
                    plat =Instantiate(p_solid, pos5m.transform.position, pos5m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            if (t5_plat.tag == "slim")
            {
                if (t5_task.tag == "btn")
                {
                    sec5 = int.Parse(if5.text);
                    auxv3 = new Vector3(pos5m.transform.position.x - 2.2f, pos5m.transform.position.y + 1f, pos5m.transform.position.z);
                    auxq = Quaternion.Euler(pos5m.transform.rotation.x, pos5m.transform.localEulerAngles.y + 90.0f, pos5m.transform.rotation.z);
                    plat =Instantiate(p_slab, new Vector3(pos5m.transform.position.x - 2.3f, pos5m.transform.position.y, pos5m.transform.position.z), pos5m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec5);
                    entry5.timer = sec5.ToString();
					listP.Add(plat);
                }
                if (t5_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos5m.transform.position.x - 2.2f, pos5m.transform.position.y + 1.8f, pos5m.transform.position.z);
                    auxq = Quaternion.Euler(pos5m.transform.rotation.x, pos5m.transform.localEulerAngles.y + 90.0f, pos5m.transform.rotation.z);
                    plat =Instantiate(p_slab, new Vector3(pos5m.transform.position.x - 2.3f, pos5m.transform.position.y, pos5m.transform.position.z), pos5m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t5_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos5m.transform.position.x - 2.2f, pos5m.transform.position.y + 1.8f, pos5m.transform.position.z);
                    auxq = Quaternion.Euler(pos5m.transform.rotation.x, pos5m.transform.localEulerAngles.y + 90.0f, pos5m.transform.rotation.z);
                    plat =Instantiate(p_slab, new Vector3(pos5m.transform.position.x - 2.3f, pos5m.transform.position.y, pos5m.transform.position.z), pos5m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            if (t5_plat.tag == "glass")
            {
                if (t5_task.tag == "btn")
                {
                    sec5 = int.Parse(if5.text);
                    auxv3 = new Vector3(pos5m.transform.position.x - 2.2f, pos5m.transform.position.y + 1f, pos5m.transform.position.z);
                    auxq = Quaternion.Euler(pos5m.transform.rotation.x, pos5m.transform.localEulerAngles.y + 90.0f, pos5m.transform.rotation.z);
                    plat =Instantiate(p_transparent, new Vector3(pos5m.transform.position.x - 2.3f, pos5m.transform.position.y, pos5m.transform.position.z), pos5m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec5);
                    entry5.timer = sec5.ToString();
					listP.Add(plat);
                }
                if (t5_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos5m.transform.position.x - 2.2f, pos5m.transform.position.y + 1.8f, pos5m.transform.position.z);
                    auxq = Quaternion.Euler(pos5m.transform.rotation.x, pos5m.transform.localEulerAngles.y + 90.0f, pos5m.transform.rotation.z);
                    plat =Instantiate(p_transparent, new Vector3(pos5m.transform.position.x - 2.3f, pos5m.transform.position.y, pos5m.transform.position.z), pos5m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t5_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos5m.transform.position.x - 2.2f, pos5m.transform.position.y + 1.8f, pos5m.transform.position.z);
                    auxq = Quaternion.Euler(pos5m.transform.rotation.x, pos5m.transform.localEulerAngles.y + 90.0f, pos5m.transform.rotation.z);
                    plat =Instantiate(p_transparent, new Vector3(pos5m.transform.position.x - 2.3f, pos5m.transform.position.y, pos5m.transform.position.z), pos5m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            itemDB.list.Add(entry5);
        }
        if (panel10.activeSelf)
        {
            //if this panel is active
            t10_task = tg10_task.ActiveToggles().FirstOrDefault();
            t10_plat = tg10_plat.ActiveToggles().FirstOrDefault();
            entry10.level = "Platform 10 meters:";
            entry10.platform = "Platform style: " + t10_plat.tag;
            entry10.task = "Task style: " + t10_task.tag;
            entry10.timer = "No timer added";

            if (t10_plat.tag=="solid")
            {
                if(t10_task.tag == "btn")
                {
                    sec10 = int.Parse(if10.text);
                    auxv3 = new Vector3(pos10m.transform.position.x - 1.8f, pos10m.transform.position.y + 1.0f, pos10m.transform.position.z);
                    auxq = Quaternion.Euler(pos10m.transform.rotation.x, pos10m.transform.localEulerAngles.y + 90.0f, pos10m.transform.rotation.z);
                    plat =Instantiate(p_solid, pos10m.transform.position, pos10m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec10);
                    entry10.timer = sec10.ToString();
					listP.Add(plat);
                }
                if (t10_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos10m.transform.position.x - 1.74f, pos10m.transform.position.y, pos10m.transform.position.z);
                    auxq = Quaternion.Euler(pos10m.transform.rotation.x, pos10m.transform.localEulerAngles.y, pos10m.transform.rotation.z);
                   plat = Instantiate(p_solid, pos10m.transform.position, pos10m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t10_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos10m.transform.position.x - 1.74f, pos10m.transform.position.y + 1.8f, pos10m.transform.position.z);
                    auxq = Quaternion.Euler(pos10m.transform.rotation.x, pos10m.transform.localEulerAngles.y + 90.0f, pos10m.transform.rotation.z);
                   plat = Instantiate(p_solid, pos10m.transform.position, pos10m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            if (t10_plat.tag == "slim")
            {
                if (t10_task.tag == "btn")
                {
                    sec10 = int.Parse(if10.text);
                    auxv3 = new Vector3(pos10m.transform.position.x - 2.2f, pos10m.transform.position.y + 1f, pos10m.transform.position.z);
                    auxq = Quaternion.Euler(pos10m.transform.rotation.x, pos10m.transform.localEulerAngles.y + 90.0f, pos10m.transform.rotation.z);
                    plat =Instantiate(p_slab, new Vector3(pos10m.transform.position.x - 2.3f, pos10m.transform.position.y, pos10m.transform.position.z), pos10m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec10);
                    entry10.timer = sec10.ToString();
					listP.Add(plat);
                }
                if (t10_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos10m.transform.position.x - 2.2f, pos10m.transform.position.y + 1.8f, pos10m.transform.position.z);
                    auxq = Quaternion.Euler(pos10m.transform.rotation.x, pos10m.transform.localEulerAngles.y + 90.0f, pos10m.transform.rotation.z);
                   plat = Instantiate(p_slab, new Vector3(pos10m.transform.position.x - 2.3f, pos10m.transform.position.y, pos10m.transform.position.z), pos10m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t10_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos10m.transform.position.x - 2.2f, pos10m.transform.position.y + 1.8f, pos10m.transform.position.z);
                    auxq = Quaternion.Euler(pos10m.transform.rotation.x, pos10m.transform.localEulerAngles.y + 90.0f, pos10m.transform.rotation.z);
                   plat = Instantiate(p_slab, new Vector3(pos10m.transform.position.x - 2.3f, pos10m.transform.position.y, pos10m.transform.position.z), pos10m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            if (t10_plat.tag == "glass")
            {
                if (t10_task.tag == "btn")
                {
                    sec10 = int.Parse(if10.text);
                    auxv3 = new Vector3(pos10m.transform.position.x - 2.2f, pos10m.transform.position.y + 1f, pos10m.transform.position.z);
                    auxq = Quaternion.Euler(pos10m.transform.rotation.x, pos10m.transform.localEulerAngles.y + 90.0f, pos10m.transform.rotation.z);
                   plat = Instantiate(p_transparent, new Vector3(pos10m.transform.position.x - 2.3f, pos10m.transform.position.y, pos10m.transform.position.z), pos10m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec10);
                    entry10.timer = sec10.ToString();
					listP.Add(plat);
                }
                if (t10_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos10m.transform.position.x - 2.2f, pos10m.transform.position.y + 1.8f, pos10m.transform.position.z);
                    auxq = Quaternion.Euler(pos10m.transform.rotation.x, pos10m.transform.localEulerAngles.y + 90.0f, pos10m.transform.rotation.z);
                   plat = Instantiate(p_transparent, new Vector3(pos10m.transform.position.x - 2.3f, pos10m.transform.position.y, pos10m.transform.position.z), pos10m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if(t10_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos10m.transform.position.x - 2.2f, pos10m.transform.position.y + 1.8f, pos10m.transform.position.z);
                    auxq = Quaternion.Euler(pos10m.transform.rotation.x, pos10m.transform.localEulerAngles.y + 90.0f, pos10m.transform.rotation.z);
                  plat =  Instantiate(p_transparent, new Vector3(pos10m.transform.position.x - 2.3f, pos10m.transform.position.y, pos10m.transform.position.z), pos10m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            itemDB.list.Add(entry10);
        }
        if (panel20.activeSelf)
        {
            //if this panel is active
            t20_task = tg20_task.ActiveToggles().FirstOrDefault();
            t20_plat = tg20_plat.ActiveToggles().FirstOrDefault();
            entry20.level = "Platform 20 meters:";
            entry20.platform = "Platform style: " + t20_plat.tag;
            entry20.task = "Task style: " + t20_task.tag;
            entry20.timer = "No timer added";

            if (t20_plat.tag == "solid")
            {
                if (t20_task.tag == "btn")
                {
                    sec20 = int.Parse(if20.text);
                    auxv3 = new Vector3(pos20m.transform.position.x - 1.8f, pos20m.transform.position.y + 1.0f, pos20m.transform.position.z);
                    auxq = Quaternion.Euler(pos20m.transform.rotation.x, pos20m.transform.localEulerAngles.y + 90.0f, pos20m.transform.rotation.z);
                  plat =  Instantiate(p_solid, pos20m.transform.position, pos20m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec20);
                    entry20.timer = sec20.ToString();
					listP.Add(plat);
                }
                if (t20_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos20m.transform.position.x - 1.74f, pos20m.transform.position.y, pos20m.transform.position.z);
                    auxq = Quaternion.Euler(pos20m.transform.rotation.x, pos20m.transform.localEulerAngles.y, pos20m.transform.rotation.z);
                  plat =  Instantiate(p_solid, pos20m.transform.position, pos20m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t20_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos20m.transform.position.x - 1.74f, pos20m.transform.position.y + 1.8f, pos20m.transform.position.z);
                    auxq = Quaternion.Euler(pos20m.transform.rotation.x, pos20m.transform.localEulerAngles.y + 90.0f, pos20m.transform.rotation.z);
                 plat =   Instantiate(p_solid, pos20m.transform.position, pos20m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            if (t20_plat.tag == "slim")
            {
                if (t20_task.tag == "btn")
                {
                    sec20 = int.Parse(if20.text);
                    auxv3 = new Vector3(pos20m.transform.position.x - 2.2f, pos20m.transform.position.y + 1f, pos20m.transform.position.z);
                    auxq = Quaternion.Euler(pos20m.transform.rotation.x, pos20m.transform.localEulerAngles.y + 90.0f, pos20m.transform.rotation.z);
                 plat =   Instantiate(p_slab, new Vector3(pos20m.transform.position.x - 2.3f, pos20m.transform.position.y, pos20m.transform.position.z), pos20m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec20);
                    entry20.timer = sec20.ToString();
					listP.Add(plat);
                }
                if (t20_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos20m.transform.position.x - 2.2f, pos20m.transform.position.y + 1.8f, pos20m.transform.position.z);
                    auxq = Quaternion.Euler(pos20m.transform.rotation.x, pos20m.transform.localEulerAngles.y + 90.0f, pos20m.transform.rotation.z);
                  plat =  Instantiate(p_slab, new Vector3(pos20m.transform.position.x - 2.3f, pos20m.transform.position.y, pos20m.transform.position.z), pos20m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t20_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos20m.transform.position.x - 2.2f, pos20m.transform.position.y + 1.8f, pos20m.transform.position.z);
                    auxq = Quaternion.Euler(pos20m.transform.rotation.x, pos20m.transform.localEulerAngles.y + 90.0f, pos20m.transform.rotation.z);
                  plat =  Instantiate(p_slab, new Vector3(pos20m.transform.position.x - 2.3f, pos20m.transform.position.y, pos20m.transform.position.z), pos20m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            if (t20_plat.tag == "glass")
            {
                if (t20_task.tag == "btn")
                {
                    sec20 = int.Parse(if20.text);
                    auxv3 = new Vector3(pos20m.transform.position.x - 2.2f, pos20m.transform.position.y + 1f, pos20m.transform.position.z);
                    auxq = Quaternion.Euler(pos20m.transform.rotation.x, pos20m.transform.localEulerAngles.y + 90.0f, pos20m.transform.rotation.z);
                  plat =  Instantiate(p_transparent, new Vector3(pos20m.transform.position.x - 2.3f, pos20m.transform.position.y, pos20m.transform.position.z), pos20m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec20);
                    entry20.timer = sec20.ToString();
					listP.Add(plat);
                }
                if (t20_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos20m.transform.position.x - 2.2f, pos20m.transform.position.y + 1.8f, pos20m.transform.position.z);
                    auxq = Quaternion.Euler(pos20m.transform.rotation.x, pos20m.transform.localEulerAngles.y + 90.0f, pos20m.transform.rotation.z);
                  plat =  Instantiate(p_transparent, new Vector3(pos20m.transform.position.x - 2.3f, pos20m.transform.position.y, pos20m.transform.position.z), pos20m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t20_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos20m.transform.position.x - 2.2f, pos20m.transform.position.y + 1.8f, pos20m.transform.position.z);
                    auxq = Quaternion.Euler(pos20m.transform.rotation.x, pos20m.transform.localEulerAngles.y + 90.0f, pos20m.transform.rotation.z);
                  plat =  Instantiate(p_transparent, new Vector3(pos20m.transform.position.x - 2.3f, pos20m.transform.position.y, pos20m.transform.position.z), pos20m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            itemDB.list.Add(entry20);
        }
        if (panel30.activeSelf)
        {
            //if this panel is active
            t30_task = tg30_task.ActiveToggles().FirstOrDefault();
            t30_plat = tg30_plat.ActiveToggles().FirstOrDefault();
            entry30.level = "Platform 30 meters:";
            entry30.platform = "Platform style: " + t30_plat.tag;
            entry30.task = "Task style: " + t30_task.tag;
            entry30.timer = "No timer added";
            
            if (t30_plat.tag == "solid")
            {
                if (t30_task.tag == "btn")
                {
                    sec30 = int.Parse(if30.text);
                    auxv3 = new Vector3(pos30m.transform.position.x - 1.8f, pos30m.transform.position.y + 1.0f, pos30m.transform.position.z);
                    auxq = Quaternion.Euler(pos30m.transform.rotation.x, pos30m.transform.localEulerAngles.y + 90.0f, pos30m.transform.rotation.z);
                  plat =  Instantiate(p_solid, pos30m.transform.position, pos30m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec30);
                    entry30.timer = sec30.ToString();
					listP.Add(plat);
                }
                if (t30_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos30m.transform.position.x - 1.74f, pos30m.transform.position.y, pos30m.transform.position.z);
                    auxq = Quaternion.Euler(pos30m.transform.rotation.x, pos30m.transform.localEulerAngles.y, pos30m.transform.rotation.z);
                  plat =  Instantiate(p_solid, pos30m.transform.position, pos30m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t30_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos30m.transform.position.x - 1.74f, pos30m.transform.position.y + 1.8f, pos30m.transform.position.z);
                    auxq = Quaternion.Euler(pos30m.transform.rotation.x, pos30m.transform.localEulerAngles.y + 90.0f, pos30m.transform.rotation.z);
                  plat =  Instantiate(p_solid, pos30m.transform.position, pos30m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            if (t30_plat.tag == "slim")
            {
                if (t30_task.tag == "btn")
                {
                    sec30 = int.Parse(if30.text);
                    auxv3 = new Vector3(pos30m.transform.position.x - 2.2f, pos30m.transform.position.y + 1f, pos30m.transform.position.z);
                    auxq = Quaternion.Euler(pos30m.transform.rotation.x, pos30m.transform.localEulerAngles.y + 90.0f, pos30m.transform.rotation.z);
                  plat =  Instantiate(p_slab, new Vector3(pos30m.transform.position.x - 2.3f, pos30m.transform.position.y, pos30m.transform.position.z), pos30m.transform.rotation);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec30);
                    entry30.timer = sec30.ToString();
					listP.Add(plat);
                }
                if (t30_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos30m.transform.position.x - 2.2f, pos30m.transform.position.y + 1.8f, pos30m.transform.position.z);
                    auxq = Quaternion.Euler(pos30m.transform.rotation.x, pos30m.transform.localEulerAngles.y + 90.0f, pos30m.transform.rotation.z);
                  plat =  Instantiate(p_slab, new Vector3(pos30m.transform.position.x - 2.3f, pos30m.transform.position.y, pos30m.transform.position.z), pos30m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t30_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos30m.transform.position.x - 2.2f, pos30m.transform.position.y + 1.8f, pos30m.transform.position.z);
                    auxq = Quaternion.Euler(pos30m.transform.rotation.x, pos30m.transform.localEulerAngles.y + 90.0f, pos30m.transform.rotation.z);
                  plat =  Instantiate(p_slab, new Vector3(pos30m.transform.position.x - 2.3f, pos30m.transform.position.y, pos30m.transform.position.z), pos30m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            if (t30_plat.tag == "glass")
            {
                if (t30_task.tag == "btn")
                {
                    sec30 = int.Parse(if30.text);
                    auxv3 = new Vector3(pos30m.transform.position.x - 2.2f, pos30m.transform.position.y + 1f, pos30m.transform.position.z);
                    auxq = Quaternion.Euler(pos30m.transform.rotation.x, pos30m.transform.localEulerAngles.y + 90.0f, pos30m.transform.rotation.z);
                 plat =   Instantiate(p_transparent, new Vector3(pos30m.transform.position.x - 2.3f, pos30m.transform.position.y, pos30m.transform.position.z), pos30m.transform.rotation);
                    Instantiate(t_btn, auxv3, auxq);
                    auxt_btn = Instantiate(t_btn, auxv3, auxq);
                    auxt_btn.gameObject.GetComponentInChildren<pressed>().setTime(sec30);
                    entry30.timer = sec30.ToString();
					listP.Add(plat);
                }
                if (t30_task.tag == "cube")
                {
                    auxv3 = new Vector3(pos30m.transform.position.x - 2.2f, pos30m.transform.position.y + 1.8f, pos30m.transform.position.z);
                    auxq = Quaternion.Euler(pos30m.transform.rotation.x, pos30m.transform.localEulerAngles.y + 90.0f, pos30m.transform.rotation.z);
                  plat =  Instantiate(p_transparent, new Vector3(pos30m.transform.position.x - 2.3f, pos30m.transform.position.y, pos30m.transform.position.z), pos30m.transform.rotation);
                    Instantiate(t_cube, auxv3, auxq);
					listP.Add(plat);
                }
                if (t30_task.tag == "tower")
                {
                    auxv3 = new Vector3(pos30m.transform.position.x - 2.2f, pos30m.transform.position.y + 1.8f, pos30m.transform.position.z);
                    auxq = Quaternion.Euler(pos30m.transform.rotation.x, pos30m.transform.localEulerAngles.y + 90.0f, pos30m.transform.rotation.z);
                  plat =  Instantiate(p_transparent, new Vector3(pos30m.transform.position.x - 2.3f, pos30m.transform.position.y, pos30m.transform.position.z), pos30m.transform.rotation);
                    Instantiate(t_hanoi, auxv3, auxq);
					listP.Add(plat);
                }
            }
            itemDB.list.Add(entry30);
        }
    }
}

[System.Serializable]
public class Stages
{
    public string level;
    public string task;
    public string platform;
    public string timer;
}

/*[System.Serializable]
public class SessionLog
{
    public string name;
    public string session;
    public string opt;
} */

[System.Serializable]
public class ItemDatabase
{
    public string name;
    public string session;
    public float time;
    public List<Stages> list = new List<Stages>();
    public string dificulty;
    public string immersiveness;
    public string nausea;
}