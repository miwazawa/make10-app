using UnityEngine;
using UnityEngine.UI;

public class SendNumber : MonoBehaviour
{
    public GameObject Button;
    MakeAnswer script;

    void Start()
    {
        var makeanswer = GameObject.Find("MakeAnswer_Button");
        script = makeanswer.GetComponent<MakeAnswer>();

    }

    public void Send_number()
    {
        if (script.num_idx < 4)
        {
            switch (this.name)
            {
                case "1":
                    script.four_num.Add(1);
                    script.num_idx++;
                    break;
                case "2":
                    script.four_num.Add(2);
                    script.num_idx++;
                    break;
                case "3":
                    script.four_num.Add(3);
                    script.num_idx++;
                    break;
                case "4":
                    script.four_num.Add(4);
                    script.num_idx++;
                    break;
                case "5":
                    script.four_num.Add(5);
                    script.num_idx++;
                    break;
                case "6":
                    script.four_num.Add(6);
                    script.num_idx++;
                    break;
                case "7":
                    script.four_num.Add(7);
                    script.num_idx++;
                    break;
                case "8":
                    script.four_num.Add(8);
                    script.num_idx++;
                    break;
                case "9":
                    script.four_num.Add(9);
                    script.num_idx++;
                    break;
                default:
                    break;
            }
        }else
        {
            switch (this.name)
            {
                case "1":
                    script.four_num.RemoveAt(script.four_num.Count - 1);
                    script.four_num.Add(1);
                    break;
                case "2":
                    script.four_num.RemoveAt(script.four_num.Count - 1);
                    script.four_num.Add(2);
                    break;
                case "3":
                    script.four_num.RemoveAt(script.four_num.Count - 1);
                    script.four_num.Add(3);
                    break;
                case "4":
                    script.four_num.RemoveAt(script.four_num.Count - 1);
                    script.four_num.Add(4);
                    break;
                case "5":
                    script.four_num.RemoveAt(script.four_num.Count - 1);
                    script.four_num.Add(5);
                    break;
                case "6":
                    script.four_num.RemoveAt(script.four_num.Count - 1);
                    script.four_num.Add(6);
                    break;
                case "7":
                    script.four_num.RemoveAt(script.four_num.Count - 1);
                    script.four_num.Add(7);
                    break;
                case "8":
                    script.four_num.RemoveAt(script.four_num.Count - 1);
                    script.four_num.Add(8);
                    break;
                case "9":
                    script.four_num.RemoveAt(script.four_num.Count - 1);
                    script.four_num.Add(9);
                    break;
                default:
                    break;
            }
        }
                
    }


}
