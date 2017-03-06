Feature: Mail
	In order to save draft version of the email
	As a registered user
	I want to create and save simple email

Scenario: Succsesful login to mail site
	Given I am on the mail site
		And I enter a mailbox login JohnDoe1990
		And I enter a mailbox domain @list.ru
		And I enter a mailbox password INeedSomePassword
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see my e-mail address JohnDoe1990@list.ru in the header of site