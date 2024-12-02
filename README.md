# Jeopardy

## Installation
- Download and extract the project
- Run the exe in the Builds Folder

## Setup
Once the program in installed and running, you can load a question set by clicking on the text box in the top left corner, and pasting in a json file of the questsions. This json document should be formatted as such:

    [
      {
        "Title": "100",
        "Prompt": "What is the value of π (pi) to two decimal places?",
        "Answer": "3.14",
        "Catagory": "Math",
        "Points": 100
      },
      {
        "Title": "Math - 200",
        "Prompt": "What is 12 squared?",
        "Answer": "144",
        "Catagory": "Math",
        "Points": 200
      },
      ...
    ]

After pasting in the contents, click the Load button to load the questions and begin the game. 

## Usage
To begin playing, add all team that will be participating into the system. To do this, click the "Add Team" button at the bottom of the window. From there, you can type in the name of the team by clicking into the text box. Please ensure to add all teams at the same time to avoid issues. 

To play, click on a question. This will open the answering screen, where the question will be displayed. Click again on the question to reveal the answer, and click again to return to the selection screen, removing that question from the options. Clicking the back button will return to the selection screen without removing the question from the pool. To add or remove points, click on the + or - buttons next to the team to be awarded. These buttons will add the point value of the most recently selected question to the team. You can also manually change the score by clicking on the point value of the team and typing in the intended point value. 

