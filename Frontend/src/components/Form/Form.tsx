import React from "react";
import { useForm } from "../../hooks/useForm";
import { Task } from "../../model/Task";
import { createGuid } from "../../util/Miscelanious";
import { useApi } from "../Api";
import "./Form.css";

const emptyValue: Task = {
  id: "",
  text: "",
  pending: true,
};

export const Form = () => {
  const { form, handleChange, setValue } = useForm<Task>(emptyValue);

  const { addTask } = useApi();

  const { text } = form;

  const onClick = (): void => {

    if(!text){
      return
    }

    const task: Task = {
      id: createGuid(),
      text: text,
      pending: true,
    };

    addTask(task);
    setValue("text", "");
  };

  return (
    <div className="form-container">
      <div className="form-input">
        <label className="form-label">Task:</label>
        <input type="text" className="form-text" name="text" value={text} onChange={handleChange} placeholder="Write your new task..." data-testid="txt_task" ></input>
      </div>
      <button className="form-button" onClick={onClick} data-testid="btn_add_task" >
        Add Task
      </button>
    </div>
  );
};
