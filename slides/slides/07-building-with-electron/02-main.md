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

- Node.js and `npm install electron`
- Single JS entry point (`main.js`)
  - Wait for app
  - Create and load `BrowserWindow`

- Options for size, position, menus, dev tools, kiosk mode, etc.