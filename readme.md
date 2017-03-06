# MVC Web API using Google OAuth
This is a .NET MVC Web Api project that uses Google OAuth for authentication. Microsoft OWIN Api is used for authentication, and the front end is made of simple AJAX calls in a basic HTML page. 

## Google OAuth Setup Instructions
For google setup to work, you will need to go to [Google API Manager](https://console.developers.google.com/) and create a new credential for a Web Application. This will give you a **Client ID** and **Client Secret**. You will need to plug these into the **SecurityConfig** class. You will also need to make sure that you add your application URL under **Authorized redirect URIs** section inside the [Google API Manager](https://console.developers.google.com/). localhost links are acceptable, so if you want to just download this code and run it from within Visual Studio, you will need to enter http://localhost:<port>/signin-google under the Authorized redirect URIs section. 

## Front End
The front end is made up of a very simple HTML page that has bunch of AJAX calls to hit the Web API. You can see this code inside index.html. 

## Unit Tests
There is also a Unit Test project in the solution. 

## Integration Test
Integration Tests with Google OAuth are not included. You can mock to test, but since Google requires someone to click consent on an approval screen, you can use Selenium to write integration tests. 

