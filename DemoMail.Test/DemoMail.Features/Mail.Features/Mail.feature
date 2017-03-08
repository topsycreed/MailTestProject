Feature: Mail
	In order to save draft version of the email
	As a registered user
	I want to create and save simple email

Background: 
	Given I am on the mail site

@positive
Scenario: Succsesful login to mail site using parameterization method input
	Given I enter a mailbox login JohnDoe1990
		And I enter a mailbox domain @list.ru
		And I enter a mailbox password INeedSomePassword
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see my e-mail address JohnDoe1990@list.ru in the header of site

@positive
Scenario: Succsesful login to mail site using resources
	Given I enter a correct mailbox login
		And I enter a correct mailbox domain
		And I enter a correct mailbox password
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see my e-mail address JohnDoe1990@list.ru in the header of site

@positive
Scenario: Succsesful login to mail site using weakly-typed step data table
	Given I enter following parameters on Login page (weak)
		| field    | value             |
		| login    | JohnDoe1990       |
		| domain   | @list.ru          |
		| password | INeedSomePassword |
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see my e-mail address JohnDoe1990@list.ru in the header of site

@positive
Scenario: Succsesful login to mail site using strongly-typed step data table
	Given I enter following parameters on Login page (strong)
		| field    | value             |
		| login    | JohnDoe1990       |
		| domain   | @list.ru          |
		| password | INeedSomePassword |
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see my e-mail address JohnDoe1990@list.ru in the header of site

@positive
Scenario: Succsesful login to mail site using dynamic step data table
	Given I enter following parameters on Login page (dynamic)
		| field    | value             |
		| login    | JohnDoe1990       |
		| domain   | @list.ru          |
		| password | INeedSomePassword |
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see my e-mail address JohnDoe1990@list.ru in the header of site

@negative
Scenario Outline: Login to mail site with incorrect password
	Given I enter a correct mailbox login
		And I enter a correct mailbox domain
		And I enter a incorrect mailbox <password> password
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see error message Неверное имя пользователя или пароль. Проверьте правильность введенных данных. about invalid login or password

	Examples: 
	| password             |
	| INeedSomePassword1   |
	| NeedSomePassword     |
	| I_Need_Some_Password |
