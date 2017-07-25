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
