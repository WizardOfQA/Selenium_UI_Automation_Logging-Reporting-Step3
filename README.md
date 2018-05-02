# Selenium_UI_Automation_Logging_Reporting (Extent Reports + Log4Net)
## Description:
On the top of Selenium UI Test Automation Framework with POM, we are ready to add log and report functionalities to our framework.
Log and report give us very valuable information for debugging. Extent Report fulfill both functionalities. 
Log can be written in multiple levels and it creates a beautiful HTML report.  When the tests are failed, a user can not only log them but also tak snapshots, so these will act as fingerprints in the framework. Html reports are interactive.
Since I don't control nor maintain these websites, some tests might be broken as these webistes are being updated. But as of 4/16/2018, every test in this framework works fine!!!  
This is the third part of the entire series of Selenium UI Test Automation.  

### Roadmap for Selenium UI Test Automation Series:
1> Selenium_UI_Automation Without POM - Manily Focus on Selenium API Functionalities  
2> Selenium_UI_Automation With POM - The Structure and Creating of POM  
**3> Selenium_UI_Automation With Logging and Reporting Functionalities.(Extent Report) - How to Logging and Reporting using Extent Reports in a Selenium framework**          
4> Selenium_UI_Automation With Behavior Driven Development(BDD) Using Specflow - How to implment BDD to the framework using Specflow.

I might add more series as needed to showcase UI Automation with Selenium.  

## Extent Reports
### Some Advantages of Using Extent Reports
* Responsive and beautiful UI
* Easy to read PIE chart.
* Provides dashboard for the whole test
* Multiple levels of logging functionality
* Screenshots can also be inserted to the report
* Host Name, OS, Author Name, Environment can be added.

## Log4Net
* Log4Net is one of the most popular and reliable logging software.
* There are many appender classes that are the output destination for your log messages.
* In our framework, I am using **RollingLogfileAppender**
* This is configured in log4net.configuration file. With our current configuration, the name of the file is "Orbitz.log", the file can grow up to 10MB. Once it reaches the 10MB, it creates another log file.
* We specify which appender will be used in <root> tag.
### Please note that we are loggging usinb both Extent Report and Log4Net, which are not usual. In a real life, you may want to use one of them. However, I am using both for "Demonstration" purpose.
  
## Sameple Test Cases Covered:
### Orbitz.com
* User_Can_Search_Vacation_Rental
* User_Can_Search_Rental_Car_With_Advanced_Options
* Test_To_Be_Failed **Please Note that this test case is failed intentionally to show the functionality of Extent Report**
Your Reports are available at C:/Orbitz_TestReport and your screenshots can be found in C:\ScreenShot

![image](https://user-images.githubusercontent.com/25840262/38799539-918c5ef8-4119-11e8-8976-aed42164251b.PNG)

**Extent Report**

![newreport1](https://user-images.githubusercontent.com/25840262/39160084-4424de6e-471e-11e8-9b50-97216aae72f1.PNG)

![newreport2](https://user-images.githubusercontent.com/25840262/39160087-47b37356-471e-11e8-8f6f-4a9fe16060ff.PNG)

![newreport3](https://user-images.githubusercontent.com/25840262/39160091-4a661248-471e-11e8-9276-3ff9e0940a5b.PNG)

**Log4Net**

![rollingappendersetup](https://user-images.githubusercontent.com/25840262/39160052-04108940-471e-11e8-8ce1-2f62e1e6270e.PNG)

![logcapture](https://user-images.githubusercontent.com/25840262/39160233-fa1189b6-471e-11e8-8c44-f1596fc76c09.PNG)
