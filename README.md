# Covid Passport

## Setup Instructions

If you would like to download the published version of the application then please follow these setup instructions to be able to edit, test and work on this project yourself. If you haven't already begin by installing Visual Studio and downloading the Project from GitHub.

#### Step 1:

Once you have opened the Project in Visual Studio if the packages haven't been automatically installed you must first do this:

1. Open the CovidPassportBDDTest and right click on Dependencies and click on manage Nuget packages.
2. From here click on browse and confirm the following packages have been installed:  "BoDi", "Cucumber.Messages", "Gherkin", "Google.Protobuf", "NUnit", "NUnit3TestAdapter", "Selenium.WebDriver", "Selenium.WebDriver.ChromeDriver", "SpecFlow", "SpecFlow.Internal.Json", "SpecFlow.Tools.MsBuild.Generation", "System.Configuration.ConfigurationManager", "System.Security.AccessControl", "System.Security.Permissions", "System.Security.Principal.Windows", and "System.ValueTuple" install both of these packages.

![image-20210910112716070](C:\Users\keaga\AppData\Roaming\Typora\typora-user-images\image-20210910112716070.png)

#### Step 2:

Once you have completed step 1, you can run the test suite using the test explorer tab provided by Visual Studio. This is where you will be able to test and view the results of all the features defined currently in the project. If you are not able to find the test explorer tab please use the following steps: 

1. Click view and select Test Explorer or use the ctrl+E,T.

![TestExplorerBDD](C:\Sparta\CovidPassport\Images\TestExplorerBDD.png)

