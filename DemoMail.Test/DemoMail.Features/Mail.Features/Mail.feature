Feature: Mail
	In order to save draft version of the email
	As a registered user
	I want to create and save simple email

Background: 
	Given I am on the mail site with Chrome browser

@positive @login
Scenario: Succsesful login to mail site using parameterization method input
	Given I enter a mailbox login JohnDoe1990
		And I enter a mailbox domain @list.ru
		And I enter a mailbox password INeedSomePassword
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see my e-mail address JohnDoe1990@list.ru in the header of site

@positive @login
Scenario: Succsesful login to mail site using resources
	Given I enter a correct mailbox login
		And I enter a correct mailbox domain
		And I enter a correct mailbox password
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see my e-mail address JohnDoe1990@list.ru in the header of site

@positive @login @not_thread_safe
Scenario: Succsesful login to mail site using resources and ScenarioContext (not thread safe) to share data between steps
	Given I enter a correct mailbox login with saving into ScenarioContext
		And I enter a correct mailbox domain with saving into ScenarioContext
		And I enter a correct mailbox password
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see my correct e-mail address in the header of site, using ScenarioContext

@positive @login @thread_safe
Scenario: Succsesful login to mail site using resources and ScenarioContext (thread safe) to share data between steps
	Given I enter a correct mailbox login with saving into ScenarioContext
		And I enter a correct mailbox domain with saving into ScenarioContext
		And I enter a correct mailbox password
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see my correct e-mail address in the header of site, using ScenarioContext

@positive @login
Scenario: Succsesful login to mail site using weakly-typed step data table
	Given I enter following parameters on Login page (weak)
		| field    | value             |
		| login    | JohnDoe1990       |
		| domain   | @list.ru          |
		| password | INeedSomePassword |
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see my e-mail address JohnDoe1990@list.ru in the header of site

@positive @login
Scenario: Succsesful login to mail site using strongly-typed step data table
	Given I enter following parameters on Login page (strong)
		| field    | value             |
		| login    | JohnDoe1990       |
		| domain   | @list.ru          |
		| password | INeedSomePassword |
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see my e-mail address JohnDoe1990@list.ru in the header of site

@positive @login
Scenario: Succsesful login to mail site using dynamic step data table
	Given I enter following parameters on Login page (dynamic)
		| field    | value             |
		| login    | JohnDoe1990       |
		| domain   | @list.ru          |
		| password | INeedSomePassword |
		And I select that I have not authentication remembering
	When I submit my login data
	Then I should see my e-mail address JohnDoe1990@list.ru in the header of site

@negative @login @invalid_login_or_password
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

@positive @draft
Scenario: Succesful saving draft e-mail
	Given I succesfully login to mail site
		And I select a new e-mail
		And I enter a whom of the message johndoe1990@list.ru
		And I enter a theme of the message Test
		And I enter a body of the message Hello, Mail World!
	When I submit saving my message
	Then I should see a confirmation of saving

@positive @draft
Scenario: Viewing draft e-mails after saving
	Given I succesfully login to mail site
		And I succesfully saving draft e-mail
	When I select drafts messages
	Then I should see a first message that equals my saved draft
