# AutoImplement

AutoImplement is a .NET runtime interface implementer.  The library is lightweight, implementation is fast,
and once implemented, the instances it generates perform the same as code you wrote and compiled in advance.

```csharp
	
    var implementer = AutoImplementer.GetImplementer();
	
	IMyInterface instance = implementer.Implement<IMyInterface>();
	
```

### Default property values

Default properties values can be defined via attributes, and their values assigned before your new instance is returned.

```csharp

	public interface IInterface
	{
		[AutoImplementProperty(10)]
		int IntProperty {get; set;}
				
		[AutoImplementProperty("hello")]
		string StringProperty {get; set;}
		
		bool? NullableBoolProperty {get; set;}
		
		bool NonNullableBoolProperty {get; set;}
	}

	// ......
	
	var instance = implementer.Implement<IInterface>();
	
	Assert.AreEqual(instance.StringProperty, "hello");
	Assert.IsNull(instance.NullableBoolProperty);
	Assert.IsFalse(instance.NonNullableBoolProperty);
	// PASSES
```

### DateTime default property values

The same constructors available on the DateTime object are exposed for default properties via a special attribute.
```csharp

	public interface IBasicDateTimeInterface
    {
        [AutoImplementDateTimeProperty(2016, 01, 01)]
        DateTime DateTimeProp1 { get; set; }

        [AutoImplementDateTimeProperty(2017, 01, 01, 12, 0, 0)]
        DateTime DateTimeProp2 { get; set; }
    }
	
```


### Default property value sets

Multiple sets of default values can be defined, and the set selected when the instance is created.

```csharp

	[AutoImplementInterface(allowUnmappedMembers: false, memberSetKeys: "set1", "set2", "set3")]
	public interface ISetInterface
	{
		[AutoImplementProperty("set1", 100)]
		[AutoImplementProperty("set2", 500)]
		[AutoImplementProperty("set3", 0)]
		int IntProperty {get; set;}
				
		[AutoImplementProperty("set1", "INSERT")]
		[AutoImplementProperty("set2", "UPDATE")]
		[AutoImplementProperty("set3", "DELETE")]
		string StringProperty {get; set;}
	}

	// ......
	
	var instance = implementer.Implement<ISetInterface>("set3");	
	Assert.AreEqual(instance.StringProperty, "DELETE");
	
	instance = implementer.Implement<ISetInterface>("set2");	
	Assert.AreEqual(instance.StringProperty, "UPDATE");
	
	instance = implementer.Implement<ISetInterface>();	
	Assert.IsNull(instance.StringProperty);	
	
	// PASSES
```

### Generic interfaces

Interfaces with generic type parameters are supported, including constraints.

```csharp

	public interface IGenInterface<T1, T2>
	where T1 : struct, T2 : new()
	{
		T1 PropT1 {get; set;}
		T2 PropT2 {get; set;}
	}
	// ......
	
	var instance = implementer.Implement<IGenInterface<char, int>();
	instance.PropT1 = 'a';
	instance.PropT2 = 100;
```


#### Roadmap
- [x] Gettable/settable properties *v0.0.1*
- [x] Default values for non Nullable<> properties *v0.0.2*
- [x] Default values for Nullable<> properties *v0.0.2*
- [x] DateTime default values for properties *v0.0.2*
- [x] Multiple sets of property default values, identified by key *v0.0.2*
- [x] Methods (void or default value returns) *v0.0.1*
- [ ] Methods (Action/Func execution)
- [ ] Events
- [ ] Events (OnEvent() via Action)
- [x] Generic interfaces *v0.0.1*
- [ ] Generic methods
- [ ] Indexers
- [ ] Indexer starting values defined by array
- [ ] Indexer definable backing collection and size
- [ ] Collection property defaults defined by array
- [ ] Randomized default value selection within provided values
- [ ] Randomized default value generation