using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour
{  
    public GameObject[] waves;    
    private int currentWave;
    private Manager manager;

    IEnumerator Start()
    {        
        if (waves.Length == 0)
        {
            yield break;
        }

        manager = FindObjectOfType<Manager>();

        while (true)
        {

            while(manager.IsPlaying() == false)
            {
                yield return new WaitForEndOfFrame();
            }

            // Waveを作成する
            GameObject g = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity);

            // WaveをEmitterの子要素にする
            g.transform.parent = transform;

            // Waveの子要素のEnemyが全て削除されるまで待機する
            while (g.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            // Waveの削除
            Destroy(g);

            // 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
            if (waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }

        }
    }
}
