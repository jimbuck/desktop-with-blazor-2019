### Main Process

```js
const {app, BrowserWindow} = require('electron');

let win;
app.on('ready', () => {
	win = new BrowserWindow({ width: 800, height: 600 });
	win.loadFile('index.html');
});
```

Note:

- Keep `let win;` to avoid garbage collection.
- Options for size, position, menus, dev tools, kiosk mode, etc.