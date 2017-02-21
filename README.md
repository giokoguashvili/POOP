# Pure OOP 

```
  new Application(
    new UserInterface(
      new ApplicationServices(
        new DomainServices(
          new UserRepository(),
          new ProductRepository()
        )
      )
    )
  ).Run()
```
