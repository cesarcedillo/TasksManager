import { Task } from "../../model/Task";
import { ApiActionType, IInitialStateApiContext } from "./Api.types";

export const apiReducer = (state: IInitialStateApiContext, action: ApiActionType) => {
  let { tasks } = state;

  switch (action.type) {
    case "addTask":
      return { ...state, tasks: tasks.concat([action.payload]) };
    case "updateTask":
      return { ...state, tasks: tasks.map((t: Task) => (t.id === action.payload.id ? action.payload : t)) };
    case "loadTasks":
      return { tasks: action.payload };
    default:
      return state;
  }
};
