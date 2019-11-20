### Pages

```
@page "/"
@using BlazorDemo.Data
@inject UserData userData

<div class="row">
    <h1>Intro</h1>
</div>
<div class="row">
  <NavLink href="/upload" Match="NavLinkMatch.Prefix">Begin</NavLink>
</div>

@code {
    protected override void OnInitialized()
    {
        userData.Reset();
    }
}
```

Note:

- `@page 'about'`
- Standard razor syntax 
  - (variables, loops, conditionals, etc.)
- `@code` contains properties & logic
  - Optionally in code-behind file