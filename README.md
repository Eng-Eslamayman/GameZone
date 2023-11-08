# Game Zone CRUD Operation MVC Project

Welcome to the Game Zone CRUD Operation MVC Project. This project is built using the Model-View-Controller (MVC) architectural pattern, and it allows you to manage games, their categories, descriptions, pictures, and supported devices. The project also integrates select2 and SweetAlert2 libraries to enhance the user experience.

![1](https://github.com/Eng-Eslamayman/GameZone/assets/106927185/80038be0-5741-45ad-828c-78a32c0636d8)
![2](https://github.com/Eng-Eslamayman/GameZone/assets/106927185/cfe37ab7-aafb-4de9-9164-b6c8aec88a64)
![3](https://github.com/Eng-Eslamayman/GameZone/assets/106927185/a25bc631-7a40-4a06-bb36-2f90264faf80)
![4](https://github.com/Eng-Eslamayman/GameZone/assets/106927185/5b4ee763-37f2-459c-9eb2-17e16704da12)

## Table of Contents

1. [Features](#features)
2. [Prerequisites](#prerequisites)
3. [Usage](#Usage)
4. [Dependencies](#dependencies)
	
## Features

- Display a list of games with their categories, descriptions, and pictures.
- Add new games to the database, specifying their category, description, picture, and supported devices.
- Edit existing games, modifying their details.
- Delete games from the database.
- Utilizes dependency injection for better maintainability and testability.
- Uses Bootswatch for a clean and responsive layout.
- Integrates select2 for enhanced category selection.
- Incorporates SweetAlert2 for user-friendly notifications.

## Dependencies

- .Net Core
- Entity Framework Core
- SQL Server 
- Bootswatch
- Select2
- SweetAlert2

## Usage

1. Visit the home page to view the list of games and their details.

2. To add a new game, click on the "Add Game" button and complete the required fields.

3. To edit an existing game, click on the "Edit" button next to the game and make the necessary changes.

4. To delete a game, click on the "Delete" button next to the game. You will receive a confirmation dialog using SweetAlert2.

## Prerequisites

Before getting started with the project, make sure you have the following prerequisites:

- .NET Core SDK (version 6.0 or higher) installed.
- Entity Framework Core.
- SQL Server or another database system to store the game data.
