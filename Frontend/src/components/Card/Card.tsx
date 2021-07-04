import React from "react";
import "./Card.css";
import { ICardsProps } from "./Card.types";

export const Card = (props: ICardsProps) => {
  return (
    <div
      data-testid={props.name}
      className="card"
      onClick={() => {
        props.onClick(props.task.id);
      }}
    >
      <span>{props.task.text}</span>
    </div>
  );
};
