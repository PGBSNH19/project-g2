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

"KNet" is an application that matches people that have a skill(teachers) with people that want to learn that specific skill(students). Users will be able to create an account. During account creation, the users will specify which skills they are interested to teach/learn. The users can choose how they want to meet, online or on specified locations. The goal of the project is to create simple way for people to connect and a network for people to meet and learn. The users will be able to advertise what skills they want to teach or learn.

"KNet" is limited to being a skill sharing networking site. It will not supply the means to host a tutoring platform.

## 2. Overall Description

### 2.1 User Needs

The application will have two different types of users; teachers and students. The teachers must be able to advertise what skills they are able to teach. The students must be able to explore the site for advertised skills that they want to learn. The students can advertise for skills that they want to learn, so that they can find tutors for that skill. 

### 2.2 Assumptions and Dependencies

Everyone that will use "KNet" must have access to Internet. We are dependent on users that want to teach their skill. We assume that the people that use our portal wants to teach and learn. We don't host any platform for the users to teach and learn, therefore we are dependent on external platforms for the users to connect or meet for tutoring purposes. 

## 3. System Features and Requirements

In this section are all the functional requirements for the project.

###       3.1 Functional Requirements

#### 3.1.1 Users

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
Feature: Post an advert
	Scenario: User posts an advert
		When the User clicks the create an advert button they will be navigated to the advert creation page
		Then the User fills in the required fields and clicks the post the advert button
		And the new post will be created and stored in the database and viewed on the website
```

```gherkin
Feature: Remove an advert
	Scenario: User removes an advert
		When the User clicks the delete button on their advert it will remove the advert from the website
		Then the advert will be deleted from the database
```

```gherkin
Feature: Choose an advert
	Scenario: Users chooses an advert
		When the User clicks the details for the advert and they will be navigated to the advert details page
		Then the User can read the advert details and decide either to learn the skill or go back and look for other adverts
		And if the User decide to learn the skill they can contact the User advertising the skill
```

####  3.1.2 Website

```gherkin
Feature: Landing page
	Scenario: User enters the website
		When the User enters the website they see a landing page with details of what the website is and contact information
		Then the User are asked to create an account to be able to enter the website
```

###       3.2 External Interface Requirements

###       3.3 System Features

###       3.4 Nonfunctional Requirements
