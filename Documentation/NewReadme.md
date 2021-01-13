# Knet - The Knowledge Sharing Network

## Course: Produce and Deliver Software

![Development API CI/CD - Build, test and then run in azure](https://github.com/PGBSNH19/project-g2/workflows/Development%20API%20CI/CD%20-%20Build,%20test%20and%20then%20run%20in%20azure/badge.svg) ![Development WEB CI/CD - Build, test and then run in azure](https://github.com/PGBSNH19/project-g2/workflows/Development%20WEB%20CI/CD%20-%20Build,%20test%20and%20then%20run%20in%20azure/badge.svg)

![Staging API CI/CD - Build, test and then run in azure](https://github.com/PGBSNH19/project-g2/workflows/Staging%20API%20CI/CD%20-%20Build,%20test%20and%20then%20run%20in%20azure/badge.svg) ![Staging Web CI/CD - Build, test and then run in azure](https://github.com/PGBSNH19/project-g2/workflows/Staging%20Web%20CI/CD%20-%20Build,%20test%20and%20then%20run%20in%20azure/badge.svg)

![Release API CI/CD - Build, test and then run in azure](https://github.com/PGBSNH19/project-g2/workflows/Release%20API%20CI/CD%20-%20Build,%20test%20and%20then%20run%20in%20azure/badge.svg) ![Release Web CI/CD - Build, test and then run in azure](https://github.com/PGBSNH19/project-g2/workflows/Release%20Web%20CI/CD%20-%20Build,%20test%20and%20then%20run%20in%20azure/badge.svg)

## Group 2

#### Development:

Hampus Kjellstrand, Benjamin Ytterström, Pontus Gillenäng, Andreas Brochs, Anton Norgren.

#### Testing:

Love Gruvberg, Aleks Edholm, Filip Sköldborg, Stefan Sandberg, Sanna K Lindqvist, Hamid Vafaye.



## Project Idea

Knowledge Net (KNet) is an application that matches Users that have a skill (teachers) with other users that want to learn that specific skill (students). Users will be able to create an account. During account creation, the users will specify which skills they are interested to teach/learn. The users can choose how they want to meet, online or on specified locations. The goal of the project is to create a simple way for people to connect and a network for people to meet and learn. The users will be able to advertise what skills they want to teach or learn.

- KNet is limited to being a skill sharing networking site. It will not supply the means to host a tutoring platform.
- KNet is not intended to be a social media platform, and therefore contact between users is defined by the users themselves and not by KNet.
- KNet is a non-profit organization and will not handle payments between users.
- KNet will accept donations from users.



<h2>Tech stack</h2>

#### Cloud Environment

Everything in this project, except running locally, is hosted in the cloud via Azure. Everything from database to website. The database is also hosted and run through Azure (unless specified running locally) and is set up there natively.



#### Client Project

- Blazor server side application.
- Communicates with REST-ful API through http-requests.
- Serves and shows web interface to users



#### Server/API project 

- SQL-server.
- Entity Framework Core.
- Runs on .Net 5.0
- Manages the database connection through repository/MVC architecture (without views).



#### Test project

- Runs on XUnit.

- Contains tests for API.



## Development Workflow

The workflow is built around 3 stages: development, staging and release. These three stages have their own pipelines and restrictions, serving different purposes of the development and testing process and have their own corresponding branches within the repository. All needed resources for the workflow, excluding local environments, is contained within github and azure. All code must be merged into the 3 mentioned branches using pull requests.



#### Development

The development phase consists of the development repository branch and a CI and CD pipeline. 

Code comitted to this branch will have to be reviewed by at least one member of the team other than the author of the code. 

The CI pipeline will make sure that the code builds and that all unit tests are run.

The CD containerizes the applications and pushes them to the azure container repository. The containers are than run in azure and are reachable on the internet. There are two containers; the API and the web client. The containers are marked "development" in azure. This is done for developing purposes and making sure things are running before entering the staging phase.

This branch will not be tested by the testing team.



#### Staging

The staging phase consists of the staging repository branch, a CI and a CD pipeline.

Code comitted to this branch have to be reviewed by at least two members of the development team other than the author of the code.

The CI pipeline will make sure that the code builds and that all unit tests are run.

The CD containerizes the applications and pushes them to the azure container repository. The containers are than run in azure and are reachable on the internet. There are two containers; the API and the web client. The containers are marked "staging" in azure.

The CD pipeline results for this branch will be tested by the testing team. If results are rejected by the testing team, fixes will be made focusing on the development branch and then pushed to the staging branch again for another round of testing. 



#### Release

The release phase consists of the release repository branch, a CI and a CD pipeline.

Code comitted to this branch have to be reviewed by at least two members of the development team other than the author of the code and must have gone through testing in the staging phase.

The CI pipeline will make sure that the code builds and that all unit tests are run.

The CD containerizes the applications and pushes them to the azure container repository. The containers are than run in azure and are reachable on the internet. There are two containers; the API and the web client. The containers are marked "release" in azure.

The result of this stage should be fully functioning and tested code, ready to be used by consumers. Before a release the whole team have to make sure that there is no untested or faulty code coming from the staging phase. The CI/CD pipelines also helps to make sure of that. 



#### Team workflow rules

- Code is documented **according to development practices**.
- Branches is named after main task, **not subtask**
  - Example branch name: “Set up API-endpoints for user”.
- Use commit messages:
  - <[Issue Nr]> <Where are changes located> - <What has changed/added/removed>
  - Example commit message. “*[G2-94] API. Controllers - Added GetUserById functionality to UserController*”.
- Move issue/story in Jira based on what has changed
- **Unit Test** - If possible
- **Integration Test** - If possible
- All code related to issue is **committed**, **pushed**, **checked in** and **built**.
- All time from should be logged from the developers.
- **Set remaining time** to 1 hour.
- If bugs are found or corrections are needed, **move back to todo** or **set Issue/Story to Done** in Jira and set the remaining time to 0.
- **Done-lead:** a team member who - along with the assignees concerned - defines a task as ‘tested and DONE’**.** 
  - Meaning: 
    - a task leaves the **in progress** state → and is forwarded to the **Ready for Test** state 
    - → the *task* is then pulled by testers into the state of **Testing** 
    - → once the tests are executed and reported; **Done-lead** and/or test assignee checks that - while executed - these tests covered the test environments (TM) necessary 
    - → the task is now *tested, done* and forwarded to the state of **DONE**.



## How to contribute to the project

Pull down the repository and start it up in your local environment.

By default, the project communicates with the database and API in Azure, so you will need to change some connection strings to truly run things locally.

Start out by going to "Startup.cs" file in the "KNet.Web" project. In the there the base Uri is setup for communicating with the API in the "ConfigureServices" method. Switch out the Uri strings for the one you want. Template strings are provided below the constructor.

```c#
namespace KNet.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        string stagingURI = @"http://group2api-staging.westus.azurecontainer.io/api/v1/";
        string releaseURI = @"http://group2api-release.westus.azurecontainer.io/api/v1/";
        string localURI = @"https://localhost:44360/api/v1/";
    
        public IConfiguration Configuration { get; }
    
        public void ConfigureServices(IServiceCollection services)
        {

#if DEBUG
            // To run locally, uncomment this line and comment out the one below, run in 				debug mode:
            // services.AddHttpClient("knetAPIClient", c => c.BaseAddress = new						   Uri(localURI));

            services.AddHttpClient("knetAPIClient", c => c.BaseAddress = new 						Uri(stagingURI));

#else
            services.AddHttpClient("knetAPIClient", c => c.BaseAddress = new 						Uri(releaseURI));
#endif
```



Next you need to have a file called "appsettings.json" located at the root of the KNet.API project. This file should not be pushed into the github repository. If not ignored, make sure it is in the .gitignore file.

In here, copy and paste this: 

```json
{  
    "ConnectionStrings": 
    {    
        "DefaultConnection": "Server=(localdb)\MSSQLLocalDB;Database=[YOUR DB NAME HERE];Trusted_Connection=True;MultipleActiveResultSets=true"  
    } 
}
```



After this is done you need to apply any migrations present by typing "update-database" in your package manager console inside visual studio. If no migrations are present, create a new one by typing "ad-migration [migration name]" instead and then running the "update-database" command.

Following these steps should net you with a project that is working locally. Remember that when taking things to Azure, the connections specified in the release mode parts of the different projects should contain the Azure container instance URI's.

It is also worth mentioning that without access to the Azure account where things are run, you can't do anything much, release-wise anyway. Either set up a new account and configure the project to use it instead or ask any account manager to give you access. 



## Documentation

- The API uses swagger, which can be viewed as documentation in and of itself. To access it, start up the API locally or go to any of the API container instances in Azure and add "/swagger" to the url.



## Resources and links

- [Jira](https://plushogskolan.atlassian.net/secure/RapidBoard.jspa?rapidView=11&projectKey=G2&selectedIssue=G2-116)

- [Confluence](https://plushogskolan.atlassian.net/wiki/spaces/G2/overview)

