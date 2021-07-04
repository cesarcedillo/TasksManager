import React from "react";
import { Task } from "../../model/Task";
import { useApi } from "../Api";
import { Card } from "../Card";
import "./CardsList.css";
import { IListCardsProps } from "./CardsList.types";

export const ListCards = (props: IListCardsProps) => {
  const { changeStatus, tasks } = useApi();

  const _tasks = props.name === "pending"?tasks.filter((t:Task)=>t.pending):tasks.filter((t:Task)=>!t.pending);

  return (
    <div className="listCards_main">
      <span className="_title">{props.name}</span>
      <div data-testid={`${props.name}_list`} className="listCards_container">
        {_tasks.map((task : Task, index: number) => (
          <div key={`${props.name}_item_${index}`} className="listCards_item">
            <Card task={task} onClick={changeStatus} name={`${props.name}_item_${index}`} />
          </div>
        ))}
      </div>
    </div>
  );
};
