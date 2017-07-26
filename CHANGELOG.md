# 0.0.3-alpha (2017-07-26)

### Bug Fixes

* **mapper-string**: decouple string mapping from value types mapping as we don't want to get into a mapping a string to an int which might crash

### Features

* **mapper-value-type**: mapping primitive types between *value* and *nullable value* types

You can now do something like this:

```c#
[TestMethod]
public void DeepCopyTo_Int_To_NullableInt_DestinationCopied()
{
    int source = 5;
    
    int? destination = source.DeepCopyTo<int?>();

    Assert.AreEqual(5, destination);
}
```

```c#
[TestMethod]
public void DeepCopyTo_NullableInt_To_Int_DestinationCopied()
{
    int? source = 5;

    int destination = source.DeepCopyTo<int>();

    Assert.AreEqual(5, destination);
}
```


### Code Refactorings

* **mapper**: few renamings, delete comments, indent IfTheElse expression blocks for visibility
* **mapper-value-type**: move value type tests such as *Int*, *Guid*, *Enum* inside their own test files for better visibility and grouping

### Performance Improvements

* **mapper-collection**: remove the fetching of the destinationUnderlyingType while mapping arrays or lists as it was already fetched

### Test Coverage

* **mapper-value-type**: add *object -> value*, *object -> nullable value*, *value -> object*, *nullable value -> object* tests

# 0.0.2-alpha (2017-07-25)
* Change Target Framework Version to v4.5(net45) for better compatibility with older versionsof .NET(there is no need to migrate towards net461 in order to use Runtime.Mapper)

# 0.0.1-alpha (2017-07-13)
First working version is released. Its Api provides two public methods:

* DeepCopyTo<T>(destination)

```c#
public void Foo()
{
    Bar bar = new Bar();
    
    Bar newBar = bar.DeepCopyTo<Bar>();
}
```

* Map(source, destination)

```c#
public void Foo()
{
    Bar bar = new Bar() { Guid = Guid.NewGuid(), String = "string", Int = 123 };
    Bar newBar = new Bar();
    
    Mapper.Map(bar, newBar);
}
```

It supports a limited amount of mapping configuration(which are unit tested):
* mapping custom types
* mapping Arrays and Lists by having the source and destination of the same type
* mapping Arrays and Lists by having the source and destination of different types
* mapping source and destination of the same type
* mapping source and destination of different types
* mapping for aggregate types
* mapping primitive types
* mapping Enums
* mapping Dictionary
* mapping objects
* mapping derived types
