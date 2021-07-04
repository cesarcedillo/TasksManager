import React from "react";
import { Api } from "../components/Api";
import { Form } from "../components/Form";
import { ListCards } from "../components/CardsList";
import "./Tasks.css";

export const Tasks = () => {
  return (
    <Api>
      <h1> TASKS </h1>
      <hr></hr>
      <div className="view-tasks-container">
        <div className="view-tasks-form">
          <Form />
        </div>
        <div className="view-tasks-lists">
          <ListCards name="pending" />
          <ListCards name="completed" />
        </div>
      </div>
    </Api>
  );
};
