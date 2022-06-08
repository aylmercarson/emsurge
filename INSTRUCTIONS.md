# Instructions

## Scenario
You are presented with a solution that has been created by a Junior developer. Your task is to improve it and add additional behaviour requested by the stakeholders.

### Goals
Our goal with these exercises is to get a feeling about:
- Your communication skills, both written and spoken.
- Your ability to understand and modify existing code.
- Your discipline when refactoring existing code.
- How you write code.
- Your source control practices using Git.
- Your ability to prioritise tasks.

### Expectations
We expect you to:
- Be able to understand the code in the solution.
- Realise there are some issues with it.
- Be able to write down a succint but complete description of the issues (picture yourself writing an email to me proposing some improvements).
- Solve those issues.
- All the above whilst keeping a nice Git history that can be used to understand the history of the code and for troubleshooting.
- Understand relatively complex requirements written in English and extend the system accordingly.

## Exercise 1 - *Required* - Software Engineer Principles & Communication Skills
Please, write down a quick explanation of what are, in your opinion, the 3 most important issues with the current solution, in order of relative importance.

## Exercise 2 - *Required* - Refactoring Technique
Please, proceed to refactor the solution to solve the issues you mentioned in Exercise 1.

## Exercise 3 - *Required* - Replication of Existing Patterns in a Solution
Please, replicate the same functionality for animals. I.e. there should be a page showing a list of animals. Clicking on an animal should show the details of the animal.
An animal has the following properties:
- Id
- Species
- Subspecies

## Exercise 4 - *Highly* Recommended - Large Changes & Distributed Systems
Please, change the system so that it uses a file as the source of People and Animals. Pay particular attention to the Open/Closed principle.
You can choose whatever file format you prefer. The data in the file should match.

## Exercise 5 - *Bonus* -  Modelling Complex Business Logic
You have received the following request from our stakeholders. Modify the system so that it can cope with these new requirements.

1. Animals can be exclusively classified as Domestic or Wild.
1. They all can have an Owner.
1. An Owner must be a person in our system.
1. Domestic animals without an Owner are classified as abandoned.
1. Domestic animals with an Owner must have a Name.
1. Wild animals can have a name, but this is not mandatory.
1. The Details page for an animal needs to show their Name, Owner and Domestic/Wild status.
1. The Details page for an animal should show a list of all the People in the system. When a person is selected, the result of an Interaction between the animal and the person must be shown. Rules for these Interactions are as follows:
    1. A Domestic animal with an owner interacting with their owner results in "Relaxation".
    1. A Domestic animal with an owner interacting with any other person results in "Anxiety".
    1. An Abandoned Domestic animal interacting with a Person results in "Curiosity" with a probability of 40%, and "Fear" with a probability of 60%.
    1. A wild animal interacting with a person results in "Fear" with a probability of 80% and "Aggression" with a probability of 20%.

## Exercise 6 - *Bonus* - Design Validation
Think about how to extend the system so that the list of people and animals can be managed from the system, i.e. adding the ability to add new people and animals as well as edit existing ones.

## Important Notes
- The solution is built using:
    - Visual Studio Community 2022
    - .NET 6.0.
    - Razor Pages.
- If you prefer, feel free to reproduce the current solution in whatever .NET-based framework you're most comfortable with.
- You are free to use whatever tools you use when coding. That includes Google, StackOverflow, etc. There is no need to pretend you know every single detail :-)
- There is a delivery date, but no time limit for this task. Feel free to spend as little or much time as you wish on it.
- You can ask questions via whatever channel you prefer and is available for you to contact us. Those questions are part of the assignment. There are no bonus points for asking more or less. I.e.
    - It's OK if you can complete the assignment without asking any questions.
    - It's not OK to complete a task without being clear about what the requirements are.
- The exercise is designed to give an advantage to those who put more time in, but do feel free to stop at any point **after completing the mandatory** exercises.

## Next Steps
- Once you have completed the exercise, you will need to get your repository back to me, ideally making it available to me on GitHub. My GitHub account is rodolfograve.
- We will then arrange a pair-programming session of about 2 hours in which we will go through the outcome of this exercise. I will ask you questions about your changes. Finally, I will ask you to make an additional change in front of me.
