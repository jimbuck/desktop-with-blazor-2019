#### Main Process

- Entry point
- Node.js file
- Primary process

#### Renderer Process
- Per window
- Uses IPC to communicate with Main
- Full access to Node.js runtime

Note:

- IPC only needed in particular situations.