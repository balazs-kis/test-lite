<img src="https://raw.githubusercontent.com/balazs-kis/test-lite/master/Logo/logo-title.png" width="50%">

Test Lite is a small library for writing well-structured, clear-cut 3A tests.

[![Build Status](https://travis-ci.org/balazs-kis/test-lite.svg?branch=master)](https://travis-ci.org/balazs-kis/test-lite)
[![Coverage Status](https://coveralls.io/repos/github/balazs-kis/test-lite/badge.svg?branch=master)](https://coveralls.io/github/balazs-kis/test-lite?branch=master)
[![Nuget](https://img.shields.io/nuget/v/TestLite)](https://www.nuget.org/packages/TestLite)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![pull requests: welcome](https://img.shields.io/badge/pull%20requests-welcome-brightgreen)](https://github.com/balazs-kis/redis-lite/fork)


## Purpose

Test Lite helps to enforce the 3A pattern for unit tests. Each test can be written in the following format: `Test.Arrange().Act().Assert()`. The fluent API makes it possible to define test methods as expression-bodied members.


## Usage

The `Arrange` method expects a function which returns the unit under test, and optionally some additional parameter(s). If additional parameters are present, the return type should be a value tuple, e.g. `return (underTest, parameter);`. If no arrangement is needed, the Arrange method can be called without any parameters.

The `Act` method expects a function which takes the arguments determined by the previous `Arrange` method, and returns a result. This result, again, can be a value tuple if multiple return values are needed. Any exception thrown be the function passed to `Act` will be catched can be validated later.

The `Assert` method has two overloads. One of them takes a validator function, which can be used to declare assertions. In this case the input type is an `ActResult` class. The other variant is parameterless and can be used to chain validation methods. A generic `Validate` method can also be chained to run custom validations on the result. In this case the input is not an `ActResult` instanse, but the value passed from the `Act` method.


## Exapmles

A simple test case which only validates if the Act section did not threw any exception (using [Fluent Assertions](https://fluentassertions.com/)):
```csharp
[TestMethod]
MyTestCase() => Test
    .Arrange(() => new MyClass())
    .Act(underTest => underTest.InstanceMethod())
    .Assert(result => result.IsSuccess.Should().BeTrue("This basic operation should succeed"));
```

The same test case with chained assertion:
```csharp
[TestMethod]
MyTestCase() => Test
    .Arrange(() => new MyClass())
    .Act(underTest => underTest.InstanceMethod())
    .Assert().IsSuccess("This basic operation should succeed");
```

A test case checking if the operation threw the expected exception (using [Fluent Assertions](https://fluentassertions.com/):
```csharp
[TestMethod]
MyTestCase() => Test
    .Arrange(() => new MyClass())
    .Act(underTest => underTest.InstanceMethod(10))
    .Assert(result => 
    {
        result.IsFailure.Should()
            .BeTrue("The array should be smaller than 10");

        result.Exception.Should()
            .BeAssignableTo<IndexOutOfRangeException>("The array should be smaller than 10");
    });
```

The same test case with chained assertion:
```csharp
[TestMethod]
MyTestCase() => Test
    .Arrange(() => new MyClass())
    .Act(underTest => underTest.InstanceMethod(10))
    .Assert().ThrewException<IndexOutOfRangeException>("The array should be smaller than 10");
```

A test case checking if the operation returnedw the expected value (using [Fluent Assertions](https://fluentassertions.com/):
```csharp
[TestMethod]
MyTestCase() => Test
    .Arrange(() => new MyClass())
    .Act(underTest => underTest.InstanceMethod(42))
    .Assert(result => 
    {
        result.IsSuccess.Should()
            .BeTrue("This basic operation should succeed");

        result.Value.Should()
            .Be(42, "The output should be equal to the input");
    });
```

The same test case with chained assertion (using [Fluent Assertions](https://fluentassertions.com/):
```csharp
[TestMethod]
MyTestCase() => Test
    .Arrange(() => new MyClass())
    .Act(underTest => underTest.InstanceMethod(42))
    .Assert()
        .Validate(result => result.Should().Be(42, "The output should be equal to the input"));
```
