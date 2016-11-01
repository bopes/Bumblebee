using System;

using OpenQA.Selenium.Remote;

namespace Bumblebee.Setup.DriverEnvironments
{
  public class BrowserStack : BrowserStackDriverEnvironment
  {
    public BrowserStack()
    {
    }

    public BrowserStack(TimeSpan timeToWait) : base(timeToWait)
    {
    }

	public BrowserStack(string browser) : base(browser)
	{
	}
  }
}