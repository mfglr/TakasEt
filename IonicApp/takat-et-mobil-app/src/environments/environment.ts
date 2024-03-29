// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  authService : "https://localhost:7166/api",
  conversationService : "https://localhost:7200/api",
  userService : "https://localhost:7267/api",
  messageHub : "https://localhost:7200/message",
  fileStockReaderService : "https://localhost:7014/api",
  fileStockWriterService : "https://localhost:7107/api"
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
