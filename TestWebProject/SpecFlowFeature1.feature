Feature: User authentication
	In order to use mail account
	As an available user
	I want to to log in

Background: 
    Given User goes to start url
@mytag
Scenario Outline: Login in mail account
	Given User navigate to the Login page
    When User input <username> and <password> 
	Then User goes to the Inbox page
Examples: 
| username | password |
|  mentoringqa2017@gmail.com     |    mentoring2017      |
