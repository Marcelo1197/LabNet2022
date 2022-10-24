// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiNorthwind: "https://localhost:44396",
  firebaseConfig: {
    apiKey: "AIzaSyBrLvG6sRD_5tdmCTwpM5t80aqNHEGFYCc",
    authDomain: "auth-northwind-app.firebaseapp.com",
    projectId: "auth-northwind-app",
    storageBucket: "auth-northwind-app.appspot.com",
    messagingSenderId: "195545104039",
    appId: "1:195545104039:web:cd0d1d6581ddba76faa582"
  },
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.
