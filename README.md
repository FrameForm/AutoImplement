# AutoImplement

AutoImplement is a .NET runtime interface implementer.  The library is lightweight, implementation is fast,
and once implemented, the instances it generates perform the same as code you wrote and compiled in advance.

```csharp
	
    var implementer = AutoImplementer.GetImplementer();
	
	IMyInterface instance = implementer.Implement<IMyInterface>();
	
```


### Default properties

Default properties can be defined via attributes, and their values assigned before your new instance is returned.

```csharp

	public interface IInterface
	{
		[AutoImplementProperty(10)]
		int IntProperty {get; set;}
				
		[AutoImplementProperty("hello")]
		string StringProperty {get; set;}
	}

	// ......
	
	var instance = implementer.Implement<IInterface>();
	
	Assert.AreEqual(instance.StringProperty, "hello");
	// PASSES
```

### Default property sets

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
	// PASSES
```


#### Roadmap
- [x] Gettable/settable properties *(2016/07/29)*
- [x] Default values for non Nullable<> properties
- [ ] Default values for Nullable<> properties
- [x] DateTime default values for properties
- [x] Multiple sets of property default values, identified by key
- [x] Methods (void or default value returns) *(2016/07/29)*
- [ ] Methods (Action/Func execution)
- [ ] Events
- [ ] Events (OnEvent() via Action)
- [x] Generic interfaces *(2016/07/29)*
- [ ] Generic methods
- [ ] Indexers
- [ ] Indexer default values defined by array
- [ ] Colletion property defaults defined by array
- [ ] Randomized default value selection within provided values
- [ ] Randomized default value generation