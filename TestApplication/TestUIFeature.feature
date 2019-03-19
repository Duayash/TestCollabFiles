Feature: TestUIFeature
	
Background: 
Given User logs in with crediantials
| Url | LoginId |  Password |
| https://recruit.app.testcollab.com/index.php/users/login  | duayash@gmail.com | 123456 |
And Switches to Account
| Account |
| Gmail - Yash |

@Ignore
Scenario Outline: Add Parent Test Suite
	Given User Clicks on Test Cases and then on Add Suite
	Then User adds the Suite with <Title> and <Description>

Examples: 
	      | Title             | Description               |
	      | Smoke Test Suite2  | This is parent Test suite |


@Ignore
Scenario Outline: Add Child Test Suite
	Given User Clicks on Test Cases and then on Add Suite
	Then User adds child Suite with <strTitle>, <strDescription> and <ParentTestSuite>

Examples: 
	      | strTitle   | strDescription            | ParentTestSuite    |
	      | TestSuite1 | This is child Test suite  | Smoke Test Suite   |


@Ignore
Scenario Outline: Quick Add Test Case
	Given User Clicks on Test Cases blue button and add details with <Title> and <TestSuiteName>
	
	
Examples: 
	      | Title								   | TestSuiteName     |
	      | This is test case of Smoke Test Suite1 | Smoke Test Suite1 |


@UI
Scenario Outline: Check if Tag Filter is working
	Given Using Tag Filter search the Test Case List using title <Title> and priority <Priority>
	
	
Examples: 
	      | Title                | Priority   |
	      | Check Email or phone |  Normal    |


		  
