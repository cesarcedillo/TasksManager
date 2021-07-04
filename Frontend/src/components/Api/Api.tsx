import React, { createContext, useContext, useEffect, useReducer } from "react";
import { Task } from "../../model/Task";
import sendRequest, { SendRequestType } from "../../util/SendRequest";
import { apiReducer } from "./Api.reducer";
import { IApiProps, IApiContext, IInitialStateApiContext } from "./Api.types";

const ApiContext = createContext<IApiContext>({
  addTask: (task: Task) => {},
  changeStatus: (id: string) => {},
  tasks: [],
});

const initialStateTasks: IInitialStateApiContext = {
  tasks: [
    // { id: "61695243-dfa7-40eb-8dea-195fd0f8c021", text: "Task 01", pending: true },
    // { id: "61695243-dfa7-40eb-8dea-195345f8c021", text: "Task 02", pending: true },
    // { id: "61695243-dfa7-40eb-8dea-195fd056c021", text: "Task 03", pending: true },
    // { id: "61695243-dfa7-40eb-8dea-195230f8c021", text: "Task 04", pending: true },
    // { id: "61695243-dfa7-40eb-8dea-195fd0f83121", text: "Task 05", pending: true },
    // { id: "61695243-dfa7-40eb-8dea-195fd312c021", text: "Task 06", pending: true },
    // { id: "61335243-dfa7-40eb-8dea-195fd0f8c021", text: "Task 07", pending: false },
    // { id: "61694443-dfa7-40eb-8dea-195345f8c021", text: "Task 08", pending: false },
    // { id: "61695255-dfa7-40eb-8dea-195fd056c021", text: "Task 09", pending: false },
    // { id: "66695243-dfa7-40eb-8dea-195230f8c021", text: "Task 10", pending: false },
    // { id: "61779543-dfa7-40eb-8dea-195fd0f83121", text: "Task 11", pending: false },
    // { id: "61699943-dfa7-40eb-8dea-195fd312c021", text: "Task 12", pending: false },
  ],
};

export const Api = (props: IApiProps) => {
  const [apiState, dispatch] = useReducer(apiReducer, initialStateTasks);

  const { tasks } = apiState;

  const changeStatus = async (id: string) => {
    const task = tasks.find((t: Task) => t.id === id)!;
    task.pending = !task.pending;
    await updateTask(task);
  };

  const loadData = async () => {
    try {
      const request: SendRequestType = {
        url: `${process.env.REACT_APP_DOMAIN}Task`,
        method: "GET",
        body: undefined,
      };

      const data = await sendRequest(request);

      dispatch({ type: "loadTasks", payload: data });
    } catch (error) {
      console.error(`Error getting task -- error:${error}`);
    }
  };

  const updateTask = async (task: Task) => {
    try {
      const request: SendRequestType = {
        url: `${process.env.REACT_APP_DOMAIN}Task`,
        method: "PUT",
        body: JSON.stringify(task),
      };

      await sendRequest(request);

      dispatch({ type: "updateTask", payload: task });
    } catch (error) {
      console.error(`Error updating task -- error:${error}`);
    }
  };

  const addTask = async (task: Task) => {
    try {
      const request: SendRequestType = {
        url: `${process.env.REACT_APP_DOMAIN}Task`,
        method: "POST",
        body: JSON.stringify(task),
      };

      await sendRequest(request);

      dispatch({ type: "addTask", payload: task });
    } catch (error) {
      console.error(`Error updating task -- error:${error}`);
    }
  };

  useEffect(() => {
    loadData();
  }, []);

  return (
    <ApiContext.Provider
      value={{
        addTask,
        changeStatus,
        tasks,
      }}
    >
      {props.children}
    </ApiContext.Provider>
  );
};

export const useApi = () => {
  return useContext(ApiContext);
};
