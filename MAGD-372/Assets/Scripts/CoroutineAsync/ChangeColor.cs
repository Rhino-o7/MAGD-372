using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    
    [SerializeField] SpriteRenderer rend;
    [SerializeField] Color color1;
    [SerializeField] Color color2;
    [SerializeField] float duration;

    void Start(){
        
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            StartCoroutine(ShiftColorCoroutine(color1, duration));
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)){
            ShiftColor(color2, duration);
        }
    }

    public IEnumerator ShiftColorCoroutine(Color color, float duration){
        float time = 0;
        Color startCol = rend.color;
        while (time < duration){
            rend.color = Color.Lerp(startCol, color, time/duration);
            time += Time.deltaTime;
            yield return null;
        }
        Debug.Log("Coroutine Finished");
    }



    public async void ShiftColor(Color color, float duration){
        float time = 0;
        Color startCol = rend.color;
        while (time < duration){
            rend.color = Color.Lerp(startCol, color, time/duration);
            time += Time.deltaTime;
            await Task.Yield();
        }
        Debug.Log("Async Function Finished");
    }


}
