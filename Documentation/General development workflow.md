# Development Workflow

The workflow is built around 3 stages: development, staging and release. These three stages have their own pipelines and restrictions, serving different purposes of the development and testing process and have their own corresponding branches within the repository. All needed resources for the workflow, excluding local environments, is contained within github and azure. All code must be merged into github using pull requests.



### Development

The development phase consists of the development repository branch and a CI pipeline. 

Code comitted to this branch will have to be reviewed by at least one member of the team other than the author of the code. 

The CI pipeline will make sure that the code builds and that all unit tests are run.

This branch will not be tested by the testing team.



### Staging

The staging phase consists of the staging repository branch, a CI and a CD pipeline.

Code comitted to this branch have to be reviewed by at least two members of the development team other than the author of the code.

The CI pipeline will make sure that the code builds and that all unit tests are run.

The CD containerizes the applications and pushes them to the azure container repository. The containers are than run in azure and are reachable on the internet. There are two containers; the API and the web client. The containers are marked "dev" in azure.

The CD pipeline results will be tested by the testing team. If results are rejected by the testing team, fixes will be made focusing on the development branch and then pushed to the staging branch for another round of testing. 



### Release

The release phase consists of the release repository branch, a CI and a CD pipeline.

Code comitted to this branch have to be reviewed by at least two members of the development team other than the author of the code and have gone through testing in the staging phase.

The CI pipeline will make sure that the code builds and that all unit tests are run.

The CD containerizes the applications and pushes them to the azure container repository. The containers are than run in azure and are reachable on the internet. There are two containers; the API and the web client. The containers are marked "release" in azure.

The result of this stage should be fully functioning and tested code, ready to be used by consumers. Before a release the whole team have to make sure that there is no untested or faulty code coming from the staging phase. The CI/CD pipelines also helps to make sure of that. 