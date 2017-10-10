# Pure OOP 

```cs
  new Application(
    new UserInterface(
      new ApplicationServices(
        new DomainServices(
          new UserRepository(),
          new ProductRepository(),
          new OrderRepository()
        )
      )
    )
  ).Run()
```

>Coming soon!