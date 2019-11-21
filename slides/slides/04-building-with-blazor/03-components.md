### Components

```
@using BlazorDemo.Models

<div class="photo-stack">
    @foreach (var photo in Photos) {
        <img src="@photo.Path" class="rand@(rand.Next(0, 5))" />
    }
</div>

@code {
    private Random rand = new Random();
    [Parameter]
    public List<Photo> Photos { get; set; }
}
```

Note:

- Building blocks
- `@code` Properties used as attributes
  - Objects/primitives == data inputs
  - EventCallback<T> == event outputs
- Similar to Angular
- Code-behind also available
