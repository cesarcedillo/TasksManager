import { Task } from "../../model/Task";

export interface IApiProps {
  children: any;
}

export interface IApiContext {
  addTask: (task: Task) => void;
  changeStatus: (id: string) => void;
  tasks: Task[];
}

export interface IInitialStateApiContext {
  tasks: Task[]  
}

export type ApiActionType = 
            { type: "addTask"; payload: Task } 
          | { type: "updateTask"; payload: Task } 
          | { type: "loadTasks"; payload: Task[]} 

          
