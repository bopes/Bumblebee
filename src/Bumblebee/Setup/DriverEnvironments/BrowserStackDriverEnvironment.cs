using System;
using System.Configuration;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Bumblebee.Setup.DriverEnvironments
{
  public abstract class BrowserStackDriverEnvironment : IDriverEnvironment
  {
	public string Browser { get; set; }
    	private TimeSpan TimeToWait { get; set; }

	public BrowserStackDriverEnvironment(string browser, TimeSpan timeToWait)
	{
		Browser = browser;
		TimeToWait = timeToWait;
	}

    	public BrowserStackDriverEnvironment() : this("Firefox", TimeSpan.FromSeconds(5))
    	{
    	}

	public BrowserStackDriverEnvironment(string browser) : this(browser, TimeSpan.FromSeconds(5))
	{
	}

    	public BrowserStackDriverEnvironment(TimeSpan timeToWait) : this("Firefox", timeToWait)
    	{
    	}

    	public virtual IWebDriver CreateWebDriver()
    	{
		RemoteWebDriver driver;

		DesiredCapabilities capability = new DesiredCapabilities(
			this.Browser, 
			"", 
			new Platform(PlatformType.Any)
		);

		var BrowserStackUser = ConfigurationManager.AppSettings["browserstackuser"];

		var BrowserStackKey = ConfigurationManager.AppSettings["browserstackkey"];

		capability.SetCapability("browserstack.user", BrowserStackUser);

		capability.SetCapability("browserstack.key",  BrowserStackKey);

		driver = new RemoteWebDriver(
			new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
		);

		driver.Manage().Window.Maximize();

		driver.Manage().Timeouts().ImplicitlyWait(TimeToWait);

		return driver;
    	}
  }
}
