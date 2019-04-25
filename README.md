# Data Driven Builder Pattern Library
A small sample on how to create data objects in a fluent(ish) way for unit testing.

##Sample Builder Class
```csharp
public class AddressBuilder : BuilderBase<Address, AddressBuilder>
{
    public AddressBuilder WithDefaultTestValues()
    {
        _concreteObject = new Address()
        {
            Suburb = "Suburb",
            PostCode = "1234",
            StreetNumber = 88
        };

        return this;
    }

    public AddressBuilder WithAustralianAddress()
    {
        _concreteObject = new Address()
        {
            Suburb = "Perth",
            PostCode = "6000",
            StreetNumber = 22
        };

        return this;
    }

    public AddressBuilder WithSouthAfricanAddress()
    {
        _concreteObject = new Address()
        {
            Suburb = "Sandton",
            PostCode = "2066",
            StreetNumber = 11
        };

        return this;
    }
}
```

##Samples in Tests

```csharp
var builder = new EmployeeBuilder();

var actual = builder.WithEmployeeFromAustralia()
                    // mix things up a bit and add another address manually by instantiating a new AddressBuilder
                    .With(e => e.Addresses.Add(new AddressBuilder()
                                                        .WithSouthAfricanAddress()
                                                        .Build())
                            )
                    .Build();
```
---
```csharp
var builder = new EmployeeBuilder();

var actual = builder.WithEmployeeFromAustralia()
                .With<AddressBuilder>((e, addressBuilder) => e.Addresses.Add(addressBuilder
                                                                        .WithSouthAfricanAddress()
                                                                        .Build())
                                        )
                .Build();
```
---
```csharp
var builder = new EmployeeBuilder();

var actual = builder.WithEmployeeFromAustralia()
                    .AddSouthAfricanAddress()
                    .Build();
```
---