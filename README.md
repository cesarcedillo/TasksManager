# Tasks Manager

## Backend

* RESTful API using .NET Core.
* The code have test coverage.
* It keep all information in memory.

## Frontend: 
* It implement a SPA using the ReactJs.
* It use Typescript

## User story 1
### Title
As a user, I want to be able to see my list of to-dos, so I can easily see my completed and pending 
tasks.
### Acceptance criteria
* It should be possible to see all tasks:
    * Each task will be represented by a simple text description.
    * Two main tasks groups: pending and completed tasks.
        * Depending on the type (completed vs pending) the task will be displayed on a different group.
* Initially, this list will be empty.

## User story 2
### Title
As a user, I want to be able to add new tasks, so I can have new to-dos in my list.
### Acceptance criteria
* The user should be able to enter a task description.
* The user should be able to add this previous description to his or her to-do list
* The added to-do will be displayed as a pending task

## User story 3
### Title
As a user, I want to be able to change the status existing tasks, so I can complete it or mark it as 
pending.
### Acceptance criteria
* The user should be able to pick a task and change its status:
    * If the task is pending it will become completed
    * If the task is completed it will become pending
* The to-do list should be updated accordingly, moving tasks between groups# TasksManager
