# Software Requirements Specification

A **software requirements specification (SRS)** by group 2 in the course "Produce and Deliver Software" that includes in-depth descriptions of the project that will be developed.

[TOC]

## 1. Introduction

### 1.1 Purpose

The reason we're developing this project is for learning purposes and to know how software is developed and delivered. 

### 1.2 Intended Audience

People that wants to share their knowledge and people who wants to learn.

### 1.3 Intended Use

The use of this document will include software developers, testers and teachers. The document is written as a reference to understand the requirements of this project. It will also be used to gap a bridge between developers, teachers and testers. 

### 1.4 Scope

Knowledge Net (KNet) is an application that matches Users that have a skill (teachers) with other users that want to learn that specific skill (students). Users will be able to create an account. During account creation, the users will specify which skills they are interested to teach/learn. The users can choose how they want to meet, online or on specified locations. The goal of the project is to create simple way for people to connect and a network for people to meet and learn. The users will be able to advertise what skills they want to teach or learn.

* KNet is limited to being a skill sharing networking site. It will not supply the means to host a tutoring platform.
* KNet is not intended to be a social media platform, and therefore contact between users is defined by the users themselves and not by KNet.
* KNet is a non-profit organization and will not handle payments between users.
* KNet will accept donations from users.

  

## 2. Overall Description

### 2.1 User Needs

The application will have two different types of users; teachers and students. The teachers must be able to advertise what skills they are able to teach. The students must be able to explore the site for advertised skills that they want to learn. The students can advertise for skills that they want to learn, so that they can find tutors for that skill. 

### 2.2 Assumptions and Dependencies

Everyone that will use KNet must have access to Internet. We are dependent on users that want to teach their skill. We assume that the people that use our portal wants to teach and learn. We don't host any platform for the users to teach and learn, therefore we are dependent on external platforms for the users to connect or meet for tutoring purposes. 

## 3. System Features and Requirements

In this section are all the functional requirements for the project.

###       3.1 Functional Requirements

###       3.2 External Interface Requirements

**User:**

* Device with an Internet browser. 

* Internet connection. 

  

**KNet requirements:** 

* Hosting environment (Cloud service) 

* Docker 

* IDE For coding 

* Continuous Integration pipeline 

* Continuous Delivery pipeline 

* GitHub repository

* MSSQL-database

  

###       3.3 System Features

#### 3.3.1 Account

```gherkin
Feature: Create an account
	Scenario: User creates an account
		When the User clicks the create an account button they will be navigated to the account creation page
		Then the User fills in the required fields and clicks the create the account button
		And the new User account will be created and stored in the database
```

```gherkin
Feature: User login
	Scenario: User login to the website
		When the User enters their credentials they will get feedback if they entered correct details
		Then the User is navigated to the explorer page were they can search adverts
```

```gherkin
Feature: User logout
	Scenario: User logout from the website
		When the User clicks the logout button they will be logged out
		Then the User will be directed to the landing page
```

```gherkin
Feature: Edit user profile
    Scenario: the User has navigated to their profile page
        When a User edits a field in their biography
        Then clicks the save button
        And the new content will be saved
```

```gherkin
Feature: Subscribe to a category
	Scenario: The User clicks a checkbox in their profile
		When the User clicks save
		Then the User will be subscribed choosen category
		And the User gets notified by e-mail when a new advert is added to any of the choosen categories
```

#### **3.3.2** **Adverts**

```gherkin
Feature: Post an advert
	Scenario: User posts an advert
		When the User clicks the create-advert-button they will be navigated to the advert creation page
		Then the User fills in the required fields and clicks the post the advert button
		And the new post will be created and stored in the database and viewed on the website
```

```gherkin
Feature: Choose an advert
	Scenario: Users chooses an advert
		When the User clicks the details for the advert and they will be navigated to the advert details page
		Then the User can read the advert details and decide either to learn the skill or go back and look for other adverts
		And if the User decide to learn the skill they can contact information of the User advertising the skill
```

```gherkin
Feature: Search for skills filtered on specific categories
	Scenario: when a User clicks the search-box
		When a User chooses one or more categories 
		Then the user clicks the search-button
		And the resulting adverts will be filtered based on those choices and the search-text.
```

```gherkin
Feature: Show the advert detail screen    
	Scenario: the user is logged in to the website        
        When the User clicks on an advert anywhere on the page        
        Then a detail form (a modal) will show
        And the user will be able to see details about the advert
```

```gherkin
Feature: Flag advert    
	Scenario: The User believes the advert is bad for some reason       
        When the User clicks on the "flag advert" button       
        Then a detail form (a modal) will show
        And the user will be able to send a message about why they think the advert is 			bad
```

#### **3.3.3** My Adverts

```gherkin
Feature: The "My created Adverts" view
	Scenario: the User navigates to "My Adverts"
		When the User clicks the "My Adverts" button
		Then the Users adverts are shown
```

```gherkin
Feature: Create an advert
	Scenario: the User is navigated to "My Adverts"
		When the User clicks the create advert button
		Then a modal(?) is shown
		And the User fills in the required and/or optional fields
		And User clicks the save-button and the advert is stored
```

```gherkin
Feature: Remove an advert
	Scenario: the User is navigated to "My Adverts"
		When the User clicks the remove advert button
		Then the advert is deleted from the my adverts list and the advert-listing
```

```gherkin
Feature: Update an advert
	Scenario: the User is navigated to "My Adverts"
        When the User clicks the edit advert button inside of the detail screen
        Then the User is able to edit the advert fields
        And the User can click save-button
```

#### 3.3.4 Bookmarked Adverts

```gherkin
Feature: View Bookmarked Advert    
	Scenario: The User is navigated to their "Bookmarked Adverts"        
    	When the User clicks on an advert    
    	Then the advert shows up in a modal
```

```gherkin
Feature: Remove Bookmarked Advert    
	Scenario: The user removes one his/hers Bookmarked adverts.        
		When the user clicks the X in the top right corner of the advert        
		Then the advert is removed from the users list        
		And the list is updated
```

```gherkin
Feature: Remove All "Bookmarked Adverts"   
	Scenario: The User is navigated to their "Bookmarked Adverts"        
		When the User clicks the "Remove All Adverts"        
		Then all the saved adverts are deleted from the list
```

#### 3.3.4 Donations page

```gherkin
Feature: Donation page    
	Scenario: The User wants to donate to the "KNet" organization        
        When The User clicks the donate button        
        Then The User will be redirected to the organization PayPal-page
```

#### 3.3.5 Contact page

```gherkin
Feature: Contact page    
    Scenario: The User is navigated to the contact page        
        When the User has filled the contact forms        
        Then the User can click send and the form will be submitted
```

#### 3.3.6 Power User

```gherkin
Feature: Power User    
	Scenario: An advert or profile page is inappropriate or has inappropriate information
		When The User is logged in as a Power User        
		Then The Power User will be able to edit or remove information on any page
```

####  3.3.7 Website

```gherkin
Feature: Landing page
	Scenario: User enters the website
		When the User enters the website they see a landing page with details of what the website is and contact information
		Then the User are asked to create an account to be able to enter the website
```

###       

###       3.4 Nonfunctional Requirements
