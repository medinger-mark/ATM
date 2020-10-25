# ATM Console App
## Synopsis
This app is a demonstration of how an ATM app could be created using a console app but written in a way it could be transformed into a web service or other app if needed.

`NOTE`: Use VS Code to execute this program

#

## Running the App
Open up a terminal and execute the command 

```dotnet run --project ./ATM.Console/ATMConsole.csproj```

#

## Using the App
With this app you have the following commands

`R` - Restocks the cash machine to the original pre-stock levels defined above

`W<dollar amount>` - Withdraws that amount from the cash machine (e.g. &quot;W $145&quot;)

`I<denominations>` - Displays the number of bills in that denomination present in the cash
machine (e.g. I $20 $10 $1)

`Q` - Quits the application

#

## Running the tests
Open up a terminal and execute the command 

```dotnet test ./ATM.Tests/ATMTests.csproj```

#

## Logs
// TODO: Figure out logging provider before this goes to production