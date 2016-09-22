N-tier Architecture Sample
===

### What is it ?

This is an example of n-tier architecture applied to a web project.

### Points of interest

- 3 layers: Domain, Data Access Layer ([Entity Framework](http://www.entityframeworktutorial.net/EntityFramework6/introduction.aspx)), Business, Web app. (only the MVC Controller is used in this sample)
- the repository returns Customers entities
- the serice returns CustomerDatas objects (aggregate of Customer and other informations if needed)
- an implementation of IUnitOfWork is used to Add, Remove and Save entities to the repository
- [AutoMapper](https://github.com/AutoMapper/AutoMapper) is used to convert Customers to CustomerDatas (and reverse)
- [Unity](http://www.asp.net/mvc/overview/older-versions/hands-on-labs/aspnet-mvc-4-dependency-injection) is used to inject dependencies through the constructors
- all methods are tested in the tests project ([NUnit](http://www.nunit.org/), [Moq](https://github.com/Moq/moq4/wiki/Quickstart))

### Code Map generated with Visual Studio 2015

![Code Map](https://github.com/lionelrepellin/n-tier-architecture-sample/blob/master/CodeMap.png "Code Map")

### Copyright and license

Code released under [the MIT license](https://github.com/twbs/bootstrap/blob/master/LICENSE).