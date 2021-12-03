# MortoSweepstakesASP
Oficial Morto Sweepstakes Project repo

by Marcos de Gois Borges.

Project created for my ASP.NET classes at Georgian College, Barrie (ON), Canada. Computer Programming program.
Thanks Professor Rich Freeman for sharing your knowledge in such a great manner.

Using:  Microsoft Visual Studio 2019 Enterprise and Community Editions.
        Azure server and MSSQL database.
        GitHub for version control and continuous deployment to Azure Web App.
        ASP.NET
        C#
        Javascript
        HTML
        CSS
        MSSQL
        
The project was set to continuous deployment from Github to Azure Web App and it's live at: https://mortosweepstakes.azurewebsites.net
        
The project is a Sweepstake app where the users can view the teams in the competition, their groups, and the upcoming matches. They will be able to place their bets, edit them, and they will receive points depending on the oficial match final scores. There is a page containing all the rules for the sweepstake and how they will make points with their bets. The code should be able to prevent any bets from being placed or edited after a match starts. Also, the code will be computing the scores automatically after the oficial score is being posted.

From the admin view, we have the ability to modify the teams in the competition, modify their groups, and the Teams View should update dynamically. The admin can also add and modify the upcoming matches while the users should only be able see the information.

A Ranking View should show all the competitors (users) and their points, ordered by higher to lower points. The top 3 will be shown in a more focused and graphic manner.

I am also planning to build a user page where we can show all personal information and the user can edit this info. Maybe upload a poto.

The project has, at least so far, 3 models: Teams, Matches and Bets. But we will need Users as well. The Team models are not yet related to the Matches model. I am planning to connect them so it's easier to create the Matches by selecting the team that will play by retrieving the names from the Teams table. So, adding just the 2 teamId as Foreign Keys on the Matches table. 

Regarding the styling, I am using Bootstrap and my own classes as well.

For JS, we have Sorttable.js external file added.

To improve the appearance I implemented the use of Font Awesome Icons.
