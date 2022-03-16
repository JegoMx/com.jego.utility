using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Jego.Utility;

public class FloatExtensionMethodsTests
{
    #region Map()

    [Test]
    public void Map5From0to10to0to100()
    {
        float unmappedNumber = 5;
        float mappedNumber = unmappedNumber.Map(0, 10, 0, 100);
        Assert.AreEqual(50f, mappedNumber);
    }

    [Test]
    public void Map12From0to1to0to10()
    {
        float unmappedNumber = 12f;
        float mappedNumber = unmappedNumber.Map(0, 1, 0, 10);
        Assert.AreEqual(120f, mappedNumber);
    }

    [Test]
    public void MapN5FromN4toN6toN40toN60()
    {
        float unmappedNumber = -5f;
        float mappedNumber = unmappedNumber.Map(-4f, -6f, -40f, -60f);
        Assert.AreEqual(-50f, mappedNumber);
    }

    #endregion

    #region MapClamped

    // A Test behaves as an ordinary method
    [Test]
    public void Map5From0to10to0to100Clamped()
    {
        float unmappedNumber = 5;
        float mappedNumber = unmappedNumber.MapClamped(0, 10, 0, 100);
        Assert.AreEqual(50f, mappedNumber);
    }

    [Test]
    public void Map12From0To10to0to100Clamped()
    {
        float unmappedNumber = 12f;
        float mappedNumber = unmappedNumber.MapClamped(0f, 10f, 0f, 100f);
        Assert.AreEqual(100f, mappedNumber);
    }

    [Test]
    public void Map80From0to100toN1To0Clamped()
    {
        float unmappedNumber = 80f;
        float mappedNumber = unmappedNumber.MapClamped(0f, 100f, -1f, 0f);
        Assert.AreEqual(-0.2f, mappedNumber);
    }

    #endregion
}
