# AutoImplement

### Tired of implementing interfaces?
### Now you don't have to!

AutoImplement is a .NET runtime interface implementer.  The library is lightweight, implementation is fast,
and once implemented, the instances it generates perform the same as code you wrote and compiled in advance.

```csharp
	
    var implementer = AutoImplementer.GetImplementer();
	
	IMyInterface instance = implementer.Implement<IMyInterface>();
	
```


Roadmap
- [x] Gettable/settable properties
- [ ] Default values for properties
- [ ] Events
- [x] Methods (void or default value returns)
- [ ] Methods (Action/Func execution)
- [ ] Generic methods
