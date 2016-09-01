Feature: Contact Us Page
  As an end user
  I want a contact us page
  So that I can find out more about QAWorks exciting services!!

Scenario Outline: Valid Submission
Given I am on the QAWorks Site
Then I should be able to contact QAWorks with the following information: <name> and <email> and <message>
Examples: 
| name     | email                | message                                   |
| j.Bloggs | j.Bloggs@qaworks.com | please contact me I want to find out more |

#these tests will fail as designed.
Scenario Outline: Invalid Submission
Given I am on the QAWorks Site
Then I receive a valid error message when I enter Incorrect data such as: <name> and <email> and <message>
Examples: 
| name     | email    | message                                   |
| j.Bloggs | j.Bloggs | please contact me I want to find out more |
|          |          |                                           |
