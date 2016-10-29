using System;

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
  }
}