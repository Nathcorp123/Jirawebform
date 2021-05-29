Feature: Test Jirawebform 
	Testing report for 3MJirawebform Application

@Aut
Scenario: Open Jirawebform application and Create Tickets for AUT
	Given Jirawebform application should be opened
	And Pass the securities
	When Create the tickets for AUT
	Then Close the Browser

@ENL
Scenario: Open Jirawebform application and Create Tickets for ENL project
	Given Open Jirawebform application
	And Pass the securities first
	When Create the tickets for ENL project
	Then Close the web Browser

@CCSS
Scenario: Open Jirawebform application and Create Tickets for CCSS project
	Given Open Jirawebform applications
	And Pass the securities cheks
	When Create the tickets for CCSS project
	Then Close the chrome Browser

@VSRM
Scenario: Open Jirawebform application and Create Tickets for VSRM project
	Given Open Jirwebform applications
	And  Pas the securities cheks
	When Creat the tickets for CCSS project
	Then Close the chrme Browser

@IAMExt
Scenario: Open Jirawebform application and Create Tickets for IAMext project
	Given open Jirwebform applications
	And  Pas The securities cheks
	When creat the tickets for IAMExt project
	| TextAlerts |
	|The remote server returned an error: (400) Bad Request.|
	Then close the chrome Browser

@PEAK
Scenario: Open Jirawebform application and Create Tickets for PEAK project
	Given open Jirwebform application
	And  Pas The securitis cheks
	When Creat the tickets for PEAK project
	Then Close the chrome Broser

@ITQM
Scenario: Open Jirawebform application and Create Tickets for ITQM project
	Given oPen Jirwebform application
	And  Pass The securitis cheks
	When Creat the tickets for ITQM project
	Then Close the chrome Brosers

@WEDPH
Scenario: Open Jirawebform application and Create Tickets for WEDPH
	Given Jirawebform application should be open
	And Pass the securities steps
	When Create the tickets for WEDPH
	| TextAlertwedph                                          |
	| The remote server returned an error: (400) Bad Request. |
	Then Closse the Browser

@VQDT
Scenario: Open Jirawebform application and Create Tickets for VQDT
	Given Jirawebform application should be opene
	And Pass the securities steps for Jirawebform
	When Create the tickets for VQDT Project
	| TextAlertVQDT                                          |
	| The remote server returned an error: (400) Bad Request. |
	Then Closese the Browser

@CGSS
Scenario: Open Jirawebform application and Create Tickets for CGSS
	Given Jirawebform application should be opened first
	And Pass the securities steps for Jirawebform web application
	When Create the tickets for CGSS Project
	| TextAlertCGSS                                          |
	| The remote server returned an error: (400) Bad Request. |
	Then Closese the web Browser