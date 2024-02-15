# Royal Library

## Description

The following code repository is a system for managing a basic book set
as part of a techincal assessment.

## Getting Started



### Dependencies

* Download and install any docker compliant CLI tool.
* For easiness you can download and install Docker Desktop or Rancher Desktop

### Installing

* Clone this repository into your local machine

### Executing program

* Open a command line in your SO
* Go to the project directory and run 

```
docker compose build --no-cache
docker compose up
```

* Open a browser tab and navigate to http://localhost:3000

### Running tests

* Download and install dotnet CLI from .NET website. Then run within the repo dir:

```
dotnet test
```

## Notes

Due to the fact that this is an app developed as per the sole pupose of demostrating
knowledge on certain areas, there are certain practices that were not implemented, but 
the Author usually use in real world scenarios like proper config in fe, the use of react query,
caching policies, unit testing, cors policies, auth, etc.

The FE is React/Typescript based.
It was built with CRA, although the author is aware that there are better tools for bundling
like Vite or NextJs.
MaterialUI was used for some UI components. 

I created a handy docker compose instead to probe knowledge in containerized apps.

Also added a basic test using Xunit, AutoFixture, Fluent Assertions and Mock
Also added all CRUD methods in BaseRepository class

To showcase knowledge on event driven design I added a RabbitMQ instance, and a 
MassTransit consumer with a sample message being sent on every book search for (any) further processing.


## Authors

Contributors names and contact info

Henry Lubel [Mail](mailto:henrylubel@gmail.com)

## Version History

* 0.1
    * Initial Release

## License

This project is for evaluation purposes only. No license will be issued.