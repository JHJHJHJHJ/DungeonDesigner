using UnityEngine;

public class Result : MonoBehaviour 
{
    int like = 0;
    int dislike = 0;

    

    public void AddLike()
    {
        like++;
    }

    public void AddDislike()
    {
        dislike++;
    }

    public int GetLike()
    {
        return like;
    }

    public int GetDislike()
    {
        return dislike;
    }
}