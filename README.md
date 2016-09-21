N-tier Architecture Sample
===

### What is it ?

This is an example of n-tier architecture applied to a web project.

### Points of interest

- 3 layers: Domain, Data Access Layer (Entity Framework), Business, Web app. (only the MVC Controller is used in this sample)
- the repository returns Customers entities
- the serice returns CustomerDatas objects (aggregate of Customer and other informations if needed)
- an implementation of IUnitOfWork is used to Add, Remove and Save entities to the repository
- AutoMapper is used to convert Customers to CustomerDatas (and reverse)
- Unity is used to inject dependencies through the constructors
- all methods are tested in the tests project (NUnit, Moq)

### Copyright and license

Code released under [the MIT license](https://github.com/twbs/bootstrap/blob/master/LICENSE).