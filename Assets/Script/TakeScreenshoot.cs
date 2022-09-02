using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshoot : MonoBehaviour
{
    public void TakeScreenshot()
    {
        StartCoroutine(takeSS());
    }

    private IEnumerator takeSS()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        //Mobile
        NativeGallery.SaveImageToGallery(texture, "Screenshots", "Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png");
    }

    public void shareScreenshot()
    {
        StartCoroutine(shareSS());
    }

    private IEnumerator shareSS()
    {
        yield return new WaitForEndOfFrame();
        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        texture.Apply();

        string path = Path.Combine(Application.persistentDataPath, "shared img.png");
        File.WriteAllBytes(path, texture.EncodeToPNG());

        Destroy(texture);

        new NativeShare().AddFile(path).SetSubject("My Screenshot").SetText("Lihat hasil ARku").Share();
    }
}
