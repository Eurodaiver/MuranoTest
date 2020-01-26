# Project Title

A web application that searches for user-defined words in three search engines: Yandex, Google, Bing. The list of search engines can be easily supplemented.

Search works by the following principle:
The result that comes first is written to the database and displayed on the page, 
responses from other services are ignored. The search result consists of the first 10 values returned by the service.

There is also a separate page with a search bar, which allows you to search the records stored in the database.

## Adding New Search Engines

To add a new search engine to the project, you need to create a class that implements the [ISearchEngine] interface and add an instance of this class to the [IndexAsync] function in the [HomeController].

## Getting Started

The sample instance is deployed on the Azure platform. It can be tested at the link http://

### Prerequisites

What things you need to install the software and how to install them

```
Give examples
```

### Installing

A step by step series of examples that tell you how to get a development env running

Say what the step will be

```
Give the example
```

And repeat

```
until finished
```

End with an example of getting some data out of the system or using it for a little demo

## Tests

The methods used in the application are covered by unit tests, which are in the solution along with the project.


## Deployment

Add additional notes about how to deploy this on a live system

## Built With

* [ASP.Net Core 3.0]() - Base platform
* [EntityFramework]() - Microsoft.EntityFrameworkCore.SqlServer
* [Json]() - Newtonsoft.Json nuget package used

## Versioning

## Authors

* **Alexey Vasilyev** - [Eurodaiver](https://github.com/Eurodaiver)


## License

This project is licensed under the MIT License 

