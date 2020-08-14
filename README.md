# _Pierre's Treat Market_

#### _Add treats to this wonderful bakery, Aug 14, 2020_

#### By _**Ben White**_

## Description

_Allows a user to add treats and flavors to a bakery, as well as, view, edit and delete any current treats_

## Setup/Installation Requirements

Setting up the database:

  1. Either replace the variable in the appsettings.json file with your SQL password or create an EnvironmentVaribles.cs file in Models with this code:
    
    namespace BakeryMarket.Models
    {
      public class EnvironmentVariables
      {
        public static string Password = "[YOUR_SQL_PASSWORD_GOES_HERE]";
      }
    }

  2. Then run, in your terminal, `dotnet ef database update`

Software Requirements:

  1. This program utilizes .NET version 2.2, and requires this framework to be pre-installed:
      * Please go to https://dotnet.microsoft.com/download/dotnet-core/2.2 and install the SDK version 2.2 or
        greater patch version, but do not upgrade to a higher minor version number.

  2. Clone this repository onto your computer: https://github.com/...

  3. In your preferred terminal window, navigate into BakeryMarket.Solution/BakeryMarket using cd (i.e. cd
    desktop/BakeryMarket.Solution/BakeryMarket) and open the project with your preferred code editor.
  4. Run the following terminal command: `dotnet restore`

  5. To initiate this terminal program, run the command: `dotnet run`

## User Stories

* As a user, I want to be able to view treats and flavors, so I can which ones I would like.
* As a user, I want to be able to sign in, so I can create, edit and delete my own treats and flavors.
* As a user, I want to be able to add multiple flavors to my treats and vice versa, so I can add more variety

## Known Bugs

_No known bugs at this time_

## Support and contact details

_Ben White: bwhite2140outlook.com_

## Technologies Used

_C#/.NET, Entity Framework Core, AspNet Core_

### License

*MIT License*

Copyright (c) 2020 **_Ben White_**