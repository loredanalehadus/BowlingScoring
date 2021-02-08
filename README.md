# American 10 Pin-Bowling Score
A .Net Core console application which, given a valid sequence of rolls for one line of American Ten-Pin Bowling, produces the total score for the game.

## Environment requirements
For Windows environment:
- .NET Core 3.1 runtime 
- Visual Studio _(optionally)_

More info about the runtime [here](https://docs.microsoft.com/en-us/dotnet/core/install/windows?tabs=net50#runtime-information).

## Running the application
Clone the repository locally and locate the files.

Open a Command Promt window and natigate to the solution folder (`\BowlingScoring` folder).


### Build
Run the following command:

```dotnet build```

### Test
Run the following command:

```dotnet test```

### Run the app
Navigate to `Bowling` folder, where the console project is located.

```cd Bowling```

and then run:

```dotnet run <input-file-path>```

e.g.: ```dotnet run ".\Resources\Input.csv"```

The application starts and shows the output:

```
Microsoft Windows [Version 10.0.18363.1256]
(c) 2019 Microsoft Corporation. All rights reserved.

C:\Users\<your-name-and-folder>\BowlingScoring>cd Bowling

C:\Users\<your-name-and-folder>\BowlingScoring\Bowling>dotnet run
| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |
|2, 3|5, 4|9, /|2, 5|3, 2|4, 2|3, 3|4, /|X   |3, 2   |
score: 90
```

## What does it solve

### Scoring
The American 10 Pin-Bowling rules are followed. More info can be found [here](https://www.topendsports.com/sport/tenpin/scoring.htm).

## Input
A default .csv file is located to `\Bowling\Resources` folder with the input of the application. The values represent the bowl throws in a bowling game.

```2, 3, 5, 4, 9, 1, 2, 5, 3, 2, 4, 2, 3, 3, 4, 6, 10, 3, 2```

## Output
The app prints a game summary and the score for the game in the following format
```
| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |
|roll1[, roll2]|roll1[, roll2]|...|roll1[, roll2][, roll3]|
score: score
```

Example output 1:
```
| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |
|-, 3|5, -|9, /|2, 5|3, 2|4, 2|3, 3|4, /|X   |X, 2, 5|
score: 103
```

Example output 2:
```
| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |
|7, 1|5, /|2, 7|4, /|-, 5|8, /|8, 1|4, 3|2, 4|5, 2   |
score: 91
```
