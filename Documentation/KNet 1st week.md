# KNet 1st week

## User stories

Any one story shoud not be longer than 5 hours

**As a [type of user], I want [an action] so that [a benefit/a value]**

- As a *driver*, I want to *block badly behaved passengers* so *they are never shown me again*.
- As a *passenger*, I want to *link the credit card to my profile* so that *I can pay for a ride faster, easier and without cash*.
- As a *driver*, I want to *add photos of my car in my profile* so that *I can attract more users*.
- As a *passenger*, I want *several available drivers to be displayed* so that *I can choose the most suitable option for me*.

**Great User Stories always fit the INVEST set of criteria by Bill Wake:**

- **I**ndependent – they can be developed in any sequence and changes to one User Story don’t affect the others.
- **N**egotiable – it’s up for the team to decide how to implement them; there is no rigidly fixed workflow.
- **V**aluable – each User Story delivers a detached unit of value to end users.
- **E**stimable – it’s quite easy to guess how much time the development of a User Story will take.
- **S**mall – it should go through the whole cycle (designing, coding, testing) during one sprint.
- **T**estable – there should be clear acceptance criteria to check whether a User Story is implemented appropriately

## Sprint 1

* 

## Basic Db data

* Maybe 1-2 rows per table
* test PK/FK connections, did the migration create the database correctly?

## Product Owners Business priorities

* 

## Db Data/Initializer

### What tables do we need? 

* Entity
  * Id
  * CreationDate
* User
  * FirstName
  * LastName
  * Email
  * PhoneNumber
  * BookmarkedAdverts (Collection(Advert))
* Advert
  * UserId (FK)
  * CategoryId (FK)
  * Heading
  * Content
  * Location
  * Price (nullable)
  * StartDate
  * EndDate
  * IsDeleted
* AdvertPicture
  * AdvertId (FK)
  * UserId (FK)
* Categories
  * Music
  * Gaming
  * Etc.

* **Dev** - should contain all new features, used by devs and testers
* **Staging** - As close a representation of prod as possible
* **Production** - should be built from dev after testing (Time frame is per sprint?)

## Models

* 

## Branching

Github Flow: Commit often and try to keep the commits as small as possible.

* What branching structure?
* Use useful commit messages , <Issue Nr> <Where are changes located> - <What has changed/added/removed> 
  Eg: #1223 API.Controllers - Added GetUserById functionality to UserController.

## Documentation

* Introduktion till projekt i README-fil (i repo)
* BDD features, skriven i [Gherkin](https://cucumber.io/docs/gherkin/reference) används till att beskriva al funktionalitet i systemet, dissa är placerat i GitHub som .feature-filer (en fil per feature)
* En övergripande beskrivning av systemet, som besvara följande frågor:
  - Hur kommer man på gång med utveckling?
  - Hur kan man testa applikationen?
  - Vilka delar består systemet av? Och hur sitter dom ihop?
* API dokumentation, vilka endpoints finns där och hur använder man dom?
  - Kan vara en genererat Swagger dokumentation
  - Någon typ av API testbench skulle vara bra, eg en [PostMan](https://www.postman.com/)-fil eller [REST client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) (VSCode)
* Kost analys
  - Vad koster det att driva alla miljöer som som applikationen kör i?



## Questions Before Sprint 1:

* How much documentation? 
* Use confluence for documenting?
* What is meant with remaining time in definition of done?



lägg till "logga tid för devs"

och var testningen tar över

sätt alternativt någonting tillbaka till ToDo



Homeknapp

categories dropdown

create new ad knapp

user-knapp med dropdown

sökfält utan funktionallitet

filter knapparna 

footer med contact länk

ej ad feed



