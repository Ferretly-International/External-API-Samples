# Readme

This project contains helper classes that can be used to interface with the Ferretly API.

Classes in the `Models` folder may not represent the latest version of the models. Please visit the API's Swagger docs to verify.

## Managing User Secrets

This project needs to have user secrets associated with it. This is where you'll store your Ferretly API key:

The secrets.json file should be like:

```
{
  "FerretlyApi": {
    "Headers": {
      "X-Api-Key": "<put your API key here>"
    }
  }
}
```