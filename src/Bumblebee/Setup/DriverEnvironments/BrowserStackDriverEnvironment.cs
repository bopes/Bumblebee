using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Bumblebee.Setup.DriverEnvironments
{
  public abstract class BrowserStackDriverEnvironment : IDriverEnvironment
  {
    private TimeSpan TimeToWait { get; set; }

    public BrowserStackDriverEnvironment() : this(TimeSpan.FromSeconds(5))
    {
    }

    public BrowserStackDriverEnvironment(TimeSpan timeToWait)
    {
      TimeToWait = timeToWait;
    }

    public virtual IWebDriver CreateWebDriver()
    {
      RemoteWebDriver driver;

      DesiredCapabilities capability = DesiredCapabilities.Firefox();

      capability.SetCapability("browserstack.user", "funemployed1");

      capability.SetCapability("browserstack.key", "k9LM791ZtS68HRmygG4i");

      driver = new RemoteWebDriver(
        new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
      );

      driver.Manage().Window.Maximize();

      driver.Manage().Timeouts().ImplicitlyWait(TimeToWait);

      return driver;
    }
  }
}
