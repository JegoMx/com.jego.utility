using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Jego.Utility;

public class LayerMaskUtilityTests
{
    [Test]
    public void CreateLayerMaskWithDefaultAndCheckIfItContainsDefault()
    {
        LayerMask mask = new LayerMask();
        mask.value = LayerMask.GetMask("Default");
        int defaultLayerValue = LayerMask.NameToLayer("Default");

        bool maskContainsDefault = LayerMaskUtility.IsInLayerMask(defaultLayerValue, mask);

        Assert.IsTrue(maskContainsDefault);
    }
}
