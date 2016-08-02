# AutoImplement

AutoImplement is a .NET runtime interface implementer.  The library is lightweight, implementation is fast,
and once implemented, the instances it generates perform the same as code you wrote and compiled in advance.

```csharp
	
    var implementer = AutoImplementer.GetImplementer();
	
	IMyInterface instance = implementer.Implement<IMyInterface>();
	
```

#### Roadmap
- [x] Gettable/settable properties *(2016/07/29)*
- [ ] Default values for properties
- [ ] Multiple sets of property default values, identified by key
- [x] Methods (void or default value returns)
- [ ] Methods (Action/Func execution)
- [ ] Events
- [ ] Events (OnEvent() via Action)
- [x] Generic interfaces
- [ ] Generic methods
- [ ] Indexers
- [ ] Randomized property default value selection
- [ ] Randomized property default value generation


### Default properties


```csharp

	public interface IInterface
	{
		[AutoImplementProperty(10)]
		int IntProperty {get; set;}
				
		[AutoImplementProperty("hello")]
		string StringProperty {get; set;}
	}
```
...

```csharp
	
	var instance = implementer.Implement<IInterface>();
	
	Assert.AreEqual(instance.StringProperty, "hello");
	// PASSES
```
