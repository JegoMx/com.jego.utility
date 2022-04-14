using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Jego.Utility;

public class NumberFormatterTests : MonoBehaviour
{
    [Test]
    public void OneFormatTest()
    {
        string formatted = NumberFormatter.Format(1);
        Assert.AreEqual("1", formatted);
    }

    [Test]
    public void OneMillionFormatTest()
    {
        string formatted = NumberFormatter.Format(1000000);
        Assert.AreEqual("1,000,000", formatted);
    }

    [Test]
    public void HundredMillionFormatTest()
    {
        string formatted = NumberFormatter.Format(100000000);
        Assert.AreEqual("100,000,000", formatted);
    }

    [Test]
    public void OneFloatFormatTest()
    {
        string formatted = NumberFormatter.Format(1f);
        Assert.AreEqual("1", formatted);
    }

    [Test]
    public void OneMillionFloatFormatTest()
    {
        string formatted = NumberFormatter.Format(1000000f);
        Assert.AreEqual("1,000,000", formatted);
    }

    [Test]
    public void HundredMillionFloatFormatTest()
    {
        string formatted = NumberFormatter.Format(100000000.42f);
        Assert.AreEqual("100,000,000", formatted);
    }
}
