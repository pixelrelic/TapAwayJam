using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class CustomEffectsManager : MonoBehaviour
{
    public static CustomEffectsManager instance;

    public MMFeedbacks blockHitFeedback;
    public MMFeedbacks blockDestoryFeedback;
    public MMFeedbacks newBlockCameFeedback;
    public MMFeedbacks rocketHitFeedback;
    public MMFeedbacks rocketMovingFeedback;
    public MMFeedbacks rocketLandedInSlotFeedback;

    private void Awake()
    {
        instance = this;
    }


    public void PlayBlockHitEffect()
    {
        blockHitFeedback?.PlayFeedbacks();
    }

    public void PlayBlockDestroyEffect()
    {
        blockDestoryFeedback?.PlayFeedbacks();
    }
    public void PlayNewBlockCameEffect()
    {
        newBlockCameFeedback?.PlayFeedbacks();
    }

    public void PlayRocketHitEffect()
    {
        rocketHitFeedback?.PlayFeedbacks();
    }

    public void PlayRocketMovingEffect()
    {
        rocketMovingFeedback?.PlayFeedbacks();
    }

    public void PlayRocketLandedInSlotEffect()
    {
        rocketLandedInSlotFeedback?.PlayFeedbacks();
    }


}
